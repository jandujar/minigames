using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AssetsBundleManager: Singleton < AssetsBundleManager > {
	// Default storage folders for different platforms      
	public
	const string WIN_AB_PATH = "Windows/";
	public
	const string OSX_AB_PATH = "OSX/";
	public
	const string LINUX_AB_PATH = "Linux/";


	private class AssetBundleRef {
		public AssetBundle assetBundle = null;
		public bool persistAcross = false;
	};

	[SerializeField]
	private bool _dontDestoyOnLoad = true; /* Shall this object persist accross scenes? */
	private string ab_path = WIN_AB_PATH; /* Path to be used when loading AssetBundles, inside StreamingAssets */
	private Dictionary < string,
	AssetBundleRef > m_dictAssetBundleRefs; /* To keep track of all loaded AssetBundles */

	private Dictionary < string,
	AssetBundleRef > dictAssetBundleRefs {
		get {
			if (m_dictAssetBundleRefs == null) {
				m_dictAssetBundleRefs = new Dictionary < string, AssetBundleRef > ();
			}
			return m_dictAssetBundleRefs;
		}
	}
	private void Awake() {
		if (_dontDestoyOnLoad) {
			DontDestroyOnLoad(gameObject); // Persist across scenes
		}

		OnInitialize();
	}

	public void OnInitialize() {
		m_dictAssetBundleRefs = new Dictionary < string, AssetBundleRef > ();
		// Define the loading path depending on the current platform.
		// NOTE: Please be aware that you might be using diferent paths names
		//       the paths below are just the default ones

		#if UNITY_STANDALONE_WIN
			ab_path = WIN_AB_PATH;
		#elif UNITY_STANDALONE_OSX
			ab_path = OSX_AB_PATH;#
		#elif UNITY_STANDALONE_LINUX
			ab_path = LINUX_AB_PATH;#
		#endif
	}

	/// <summary>
	/// Have we loaded the AssetBunde before?
	/// </summary>
	/// <param name="ab_name">AssetBundle name</param>
	/// <returns> True if the assetbundle have been loaded before </returns>
	public bool IsAssetBundleLoaded(string ab_name) {
		if (dictAssetBundleRefs == null || dictAssetBundleRefs.Count == 0)
			return false;

		return dictAssetBundleRefs.ContainsKey(ab_name);
	}

	/// <summary>
	/// Unload all loaded AssetBundles and clean and remove them from the list
	/// </summary>
	/// <param name="includePersistent"> Shall we include persistent AssetBundles </param>
	public void CleanUp(bool includePersistent = false) {
		// Loop through all bundles in the dictionary, and unload the AssetBundle
		foreach(var key in dictAssetBundleRefs.Keys) {
			if (!dictAssetBundleRefs[key].persistAcross || includePersistent) {
				dictAssetBundleRefs[key].assetBundle.Unload(true);
				dictAssetBundleRefs.Remove(key);
			}
		}

		if (includePersistent) // Remove all entries on the asset bubdle list
		{
			dictAssetBundleRefs.Clear();
		}

	}

	/// <summary>
	/// Load the requested Assetbundle asynchronously using a local Coroutine
	/// </summary>
	/// <param name="ab_name"> Asset Bundle name to be loaded ( it should be include in the assetbundles folder) </param>
	/// <param name="async_callback"> Callback once the load process is finished (if not null)</param>
	/// <param name="persist"> Does this AssetBundle persist accross scenes? </param>
	public void LoadAbSyncLocally(string ab_name, Action async_callback = null, bool persist = false) {
		StartCoroutine(LoadABAsync(ab_name, async_callback, persist));
	}

	/// <summary>
	/// Coroutine to load the requested assetbundle asynchronously
	/// </summary>
	/// <param name="ab_name"> Asset Bundle name to be loaded ( it should be include in the assetbundles folder) </param>
	/// <param name="async_callback"> Callback once the load process is finished (if not null)</param>
	/// <param name="persist"> Does this AssetBundle persist accross scenes? </param>
	/// <returns> Coroutine </returns>
	public IEnumerator LoadABAsync(string ab_name, Action async_callback, bool persist = false) {
		if (!dictAssetBundleRefs.ContainsKey(ab_name)) // Is it loaded already?
		{
			var bundleLoadRequest = AssetBundle.LoadFromFileAsync(Path.Combine(Application.streamingAssetsPath, ab_path + ab_name));
			yield
			return bundleLoadRequest;
			var myLoadedAssetBundle = bundleLoadRequest.assetBundle;

			if (myLoadedAssetBundle == null) {
				Debug.Log("Failed to load AssetBundle!");
				yield
				return null;
			}

			// If everything went fine, include it in our AssetBundles list
			AssetBundleRef abRef = new AssetBundleRef() {
				assetBundle = myLoadedAssetBundle,
				persistAcross = persist
			};

			dictAssetBundleRefs.Add(ab_name, abRef);
		}

		if (async_callback != null)
			async_callback();
	}

	/// <summary>
	/// Load the requested AssetBundle synchronously. Calling this method will freeze everything else as it is executed on 
	/// the main thread. If you want your bundle to be loaded in the background, please use LoadABAsync (coroutine) or
	/// LoadAbSyncLocally
	/// </summary>
	/// <param name="ab_name"> Asset Bundle name to be loaded ( it should be include in the assetbundles folder) </param>
	/// <param name="persist"> Does this AssetBundle persist accross scenes? </param>
	/// <returns> True if the AssetBundle has been loaded correctly </returns>
	public bool LoadAB(string ab_name, bool persist = false) {
		try {
			// If the AssetBundles list already contains the requested AssetBundle, just return true
			if (dictAssetBundleRefs.ContainsKey(ab_name))
				return true;

			// Load the AssetBundle from the StreamingAssets + platform folder 
			AssetBundle myLoadedAssetBundle = AssetBundle.LoadFromFile(
				Path.Combine(Application.streamingAssetsPath, ab_path + ab_name));

			if (myLoadedAssetBundle == null) {
				Debug.Log("Failed to load AssetBundle!");
				return false;
			}

			// If everything went fine, include it in our AssetBundles list
			AssetBundleRef abRef = new AssetBundleRef() {
				assetBundle = myLoadedAssetBundle,
				persistAcross = persist
			};

			dictAssetBundleRefs.Add(ab_name, abRef);
			return true;
		} catch (Exception e) {
			Debug.Log("Error while loasing synch AssetBundle: " + ab_name + ", error: " + e.Message);
			return false;
		}
	}

	/// <summary>
	/// Function to find an scene inside an asset bundle and returns its path. Should be used as follows:
	/// AssetsBundleManager.Instance.GetScenePathFromAB("scenes", "intro");
	/// Be Aware that the following code only works if there are no scene names that contain each other. For 
	/// example it wont work if you have MainMenu and MainMenuArt scenes in the same bundle
	/// </summary>
	/// <param name="ab_name">AssetBundle name that contains the scene to be loaded</param>
	/// <param name="scene_name">Scene name to find in the given asset bundle</param>
	/// <returns> String containing the reuested scene path inside the AssetBundle </returns>
	public string GetScenePathFromAB(string ab_name, string scene_name) {
		// if we haven't load before the AssetBundle, will return null
		if (!dictAssetBundleRefs.ContainsKey(ab_name) || dictAssetBundleRefs.Count == 0)
			return "";

		string scene_path = "";
		try {
			AssetBundleRef abRef = dictAssetBundleRefs[ab_name];

			// Get all scenes contained on this assetbundle, and loop to find the requested scene
			string[] scenePaths = abRef.assetBundle.GetAllScenePaths();
			for (var i = 0; i < scenePaths.Length; ++i) {
				if (scenePaths[i].Contains(scene_name))
					scene_path = scenePaths[i];
			}
		} catch (Exception e) {

			Debug.Log("Error while looking for the scene " + scene_name + " inside the assetbundle " + ab_name + ", error: " + e.Message);
			return scene_path;
		}
		return scene_path;
	}

	/// <summary>
	/// Function to load a list of objects of the same time from the loaded asset bundles. Should be usded as follows:
	/// AssetsBundleManager.Instance.LoadAssetFromAB<TextAsset>("localization", new string[] { "english.xml" });
	/// </summary>
	/// <typeparam name="T"> Type of objects to be loaded </typeparam>
	/// <param name="ab_name"> Asset bundle that conatins the assets we would like to load </param>
	/// <param name="obj_names"> All objects names that will be loaded </param>
	/// <returns> Returns the requested object instance from inside the AssetBunndle</returns>
	public T[] LoadAssetFromAB < T > (string ab_name, string[] obj_names)
		where T: UnityEngine.Object {
		// if we haven't load before the AssetBundle, will return null
		if (!dictAssetBundleRefs.ContainsKey(ab_name) || dictAssetBundleRefs.Count == 0)
			return null;

		// Create a new array of elements with the same size of the prefabs to be loaded
		T[] assets = new T[obj_names.Length];
		try {
			AssetBundleRef abRef = dictAssetBundleRefs[ab_name];

			// Loop through all prefabs to be loaded
			for (var i = 0; i < obj_names.Length; ++i) {
				assets[i] = abRef.assetBundle.LoadAsset < T > (obj_names[i]);
			}
		} catch (Exception e) {
			Debug.Log("Error while loading and asset from AssetBundles, error: " + e.Message);
			return assets;
		}

		return assets;
	}
}