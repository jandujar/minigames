using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    [SerializeField]
    float scrollingSpeed = 1f;

    float verticalSize = 0f;

    RectTransform tr;

    // Use this for initialization
    void Start () {
        Text text = GetComponent<Text>();
        TextGenerator generator = new TextGenerator();
        tr = GetComponent<RectTransform>();
        string[] folders = Directory.GetDirectories("Assets/Scenes/");
        string creditsText = "";

        for (int i = 0; i < folders.Length; i++)
        {
            if (File.Exists(folders[i] + "/Readme.md"))
            {
                StreamReader reader = new StreamReader(folders[i] + "/Readme.md");
                creditsText = creditsText + reader.ReadToEnd();
                creditsText += "\n\n";
            }
            else if (File.Exists(folders[i] + "/Readme.txt"))
            {
                StreamReader reader = new StreamReader(folders[i] + "/Readme.txt");
                creditsText = creditsText + reader.ReadToEnd();
                creditsText += "\n\n";
            }
        }
        
        generator.Populate(creditsText, text.GetGenerationSettings(new Vector2(1250f, 10000f)));
        verticalSize = generator.rectExtents.height;
        text.text = creditsText;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = tr.position;
        pos.y += scrollingSpeed * Time.deltaTime;
        tr.position = pos;

        if (Input.GetButtonDown("Fire1"))
            SceneManager.LoadScene("Menu_Luka");

        /*if (pos.y > verticalSize)
            SceneManager.LoadScene("Menu_Luka");*/

    }
}
