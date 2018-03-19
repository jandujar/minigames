using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class soilder_show : MonoBehaviour {


    
     int WalkStepsofWay;
     bool Walk_back;

    void OnTriggerEnter(Collider collision)
    {
      
        if (collision.gameObject.tag == "way_point")
        {
            if(!Walk_back)
            {
                currentPathPoint += 1;
            }
            else
            {
                currentPathPoint -= 1;
            }

            if(currentPathPoint+1 == WalkStepsofWay) { Walk_back = true; }




            // get a new walk way on the end

            if (currentPathPoint == 0 && Walk_back)
            {

                Debug.Log("Endded path and begin new one now");

                wait_time_for_new_path = false;
                Walk_back = false;
            }


        }
    }
   



    void Start ()
    {

      
        
      

        if (gameObject.tag == "wehrmacht_a")
        {

            GameObject Path_to_weapon_meshes = GameObject.Find(gameObject.name+"/Wehrmacht_soilder_A");

            k98 = Path_to_weapon_meshes.transform.Find("K98").gameObject;
            MG42 = Path_to_weapon_meshes.transform.Find("MG42").gameObject;
            FlammenWerfer = Path_to_weapon_meshes.transform.Find("Flammenwerfer").gameObject;
            Luger = Path_to_weapon_meshes.transform.Find("Luger_P08").gameObject;
            MP40 = Path_to_weapon_meshes.transform.Find("MP40").gameObject;
            PanzerFaust = Path_to_weapon_meshes.transform.Find("Panzerfaust_launcher").gameObject;
            PanzerSchreck = Path_to_weapon_meshes.transform.Find("PanzerSchreck").gameObject;
            STG44 = Path_to_weapon_meshes.transform.Find("STG44").gameObject;

        }
        if (gameObject.tag == "wehrmacht_b")
        {

            GameObject Path_to_weapon_meshes = GameObject.Find(gameObject.name + "/Wehrmacht_soilder_B");

            k98 = Path_to_weapon_meshes.transform.Find("K98").gameObject;
            MG42 = Path_to_weapon_meshes.transform.Find("MG42").gameObject;
            FlammenWerfer = Path_to_weapon_meshes.transform.Find("Flammenwerfer").gameObject;
            Luger = Path_to_weapon_meshes.transform.Find("Luger_P08").gameObject;
            MP40 = Path_to_weapon_meshes.transform.Find("MP40").gameObject;
            PanzerFaust = Path_to_weapon_meshes.transform.Find("Panzerfaust_launcher").gameObject;
            PanzerSchreck = Path_to_weapon_meshes.transform.Find("PanzerSchreck").gameObject;
            STG44 = Path_to_weapon_meshes.transform.Find("STG44").gameObject;

     
        }

        if (gameObject.tag == "wehrmacht_c")
        {

            GameObject Path_to_weapon_meshes = GameObject.Find(gameObject.name + "/Wehrmacht_soilder_C");

            k98 = Path_to_weapon_meshes.transform.Find("K98").gameObject;
            MG42 = Path_to_weapon_meshes.transform.Find("MG42").gameObject;
            FlammenWerfer = Path_to_weapon_meshes.transform.Find("Flammenwerfer").gameObject;
            Luger = Path_to_weapon_meshes.transform.Find("Luger_P08").gameObject;
            MP40 = Path_to_weapon_meshes.transform.Find("MP40").gameObject;
            PanzerFaust = Path_to_weapon_meshes.transform.Find("Panzerfaust_launcher").gameObject;
            PanzerSchreck = Path_to_weapon_meshes.transform.Find("PanzerSchreck").gameObject;
            STG44 = Path_to_weapon_meshes.transform.Find("STG44").gameObject;
            
        }

        if (gameObject.tag == "schutzstaffel_a")
        {

            GameObject Path_to_weapon_meshes = GameObject.Find(gameObject.name + "/SchutzStaffel_A");

            k98 = Path_to_weapon_meshes.transform.Find("K98").gameObject;
            MG42 = Path_to_weapon_meshes.transform.Find("MG42").gameObject;
            FlammenWerfer = Path_to_weapon_meshes.transform.Find("Flammenwerfer").gameObject;
            Luger = Path_to_weapon_meshes.transform.Find("Luger_P08").gameObject;
            MP40 = Path_to_weapon_meshes.transform.Find("MP40").gameObject;
            PanzerFaust = Path_to_weapon_meshes.transform.Find("Panzerfaust_launcher").gameObject;
            PanzerSchreck = Path_to_weapon_meshes.transform.Find("PanzerSchreck").gameObject;
            STG44 = Path_to_weapon_meshes.transform.Find("STG44").gameObject;

        }

        if (gameObject.tag == "schutzstaffel_b")
        {

            GameObject Path_to_weapon_meshes = GameObject.Find(gameObject.name + "/SchutzStaffel_B");

            k98 = Path_to_weapon_meshes.transform.Find("K98").gameObject;
            MG42 = Path_to_weapon_meshes.transform.Find("MG42").gameObject;
            FlammenWerfer = Path_to_weapon_meshes.transform.Find("Flammenwerfer").gameObject;
            Luger = Path_to_weapon_meshes.transform.Find("Luger_P08").gameObject;
            MP40 = Path_to_weapon_meshes.transform.Find("MP40").gameObject;
            PanzerFaust = Path_to_weapon_meshes.transform.Find("Panzerfaust_launcher").gameObject;
            PanzerSchreck = Path_to_weapon_meshes.transform.Find("PanzerSchreck").gameObject;
            STG44 = Path_to_weapon_meshes.transform.Find("STG44").gameObject;

        }

        weaponSwap = StartCoroutine(SwitchWeapons());


    }

     float WalkSpeed;
     bool AlreadyPath;
     bool Ready_to_walk;
     Transform WayPointToPath;
     List<Transform> Paths_in_wayPoint = new List<Transform>();
    public Transform Way_point_menu;
    public NavMeshAgent agent;
     int currentPathPoint;
    public Animator anim;

    public bool wait_time_for_new_path;

	void FixedUpdate ()
    {
        if(!wait_time_for_new_path)
        {
            WalkStepsofWay = 0;
            currentPathPoint = 0;
            wait_time_for_new_path = true;
            agent.speed = 0;
            Ready_to_walk = false;
            AlreadyPath = false;
            Paths_in_wayPoint.Clear();
        }

        if (!AlreadyPath)
        {
            // Search way to walk on
           
            AlreadyPath = true;
            int Ways_to_choosing = Way_point_menu.childCount;
            
            int RandomWay = UnityEngine.Random.Range(0, 3);

            Transform WayPointToPath = Way_point_menu.GetChild(RandomWay);
            
            // Get all ways to walk on

            int Ways_in_path = WayPointToPath.childCount;


            Paths_in_wayPoint.Add(WayPointToPath);
            WalkStepsofWay += 1;

            for (int i = 0; i < Ways_in_path;)
            {
                Paths_in_wayPoint.Add(WayPointToPath.GetChild(i));
                WalkStepsofWay++;
                i ++;
            }
            Ready_to_walk = true;
        }


        if (Ready_to_walk)
        {
            agent.destination = Paths_in_wayPoint[currentPathPoint].transform.position;
            agent.speed = 1.7f;
            anim.SetInteger("Status_walk", 1);

        }


    }


    GameObject FlammenWerfer;
    GameObject Luger;
   GameObject MP40;
    GameObject STG44;
    GameObject PanzerFaust;
    GameObject PanzerSchreck;
    GameObject k98;
     GameObject MG42;

    

     int weaponIndex;
     string CurrentAnimationName;
    Coroutine weaponSwap;

    IEnumerator SwitchWeapons()
    {

        yield return new WaitForSeconds(0.1f);


        if(weaponIndex == 0)
        {
            //Luger

           
                CurrentAnimationName = "Status_LugerP08";
                Luger.SetActive(true);
                MP40.SetActive(false);
                STG44.SetActive(false);
                k98.SetActive(false);
                MG42.SetActive(false);
                PanzerFaust.SetActive(false);
                PanzerSchreck.SetActive(false);
                FlammenWerfer.SetActive(false);
         
            
            

        }
        if (weaponIndex == 1)
        {
            //Mp40

            Luger.SetActive(false);
            MP40.SetActive(true);
            STG44.SetActive(false);
            k98.SetActive(false);
            MG42.SetActive(false);
            PanzerFaust.SetActive(false);
            PanzerSchreck.SetActive(false);
            FlammenWerfer.SetActive(false);
            CurrentAnimationName = "status_MP40";
        }
        if (weaponIndex == 2)
        {
            //Stg44

            Luger.SetActive(false);
            MP40.SetActive(false);
            STG44.SetActive(true);
            k98.SetActive(false);
            MG42.SetActive(false);
            PanzerFaust.SetActive(false);
            PanzerSchreck.SetActive(false);
            FlammenWerfer.SetActive(false);
            CurrentAnimationName = "Status_stg44";
        }
        if (weaponIndex == 3)
        {
            //K98

            Luger.SetActive(false);
            MP40.SetActive(false);
            STG44.SetActive(false);
            k98.SetActive(true);
            MG42.SetActive(false);
            PanzerFaust.SetActive(false);
            PanzerSchreck.SetActive(false);
            FlammenWerfer.SetActive(false);
            CurrentAnimationName = "status_k98";
        }
        if (weaponIndex == 4)
        {
            //MG42

            Luger.SetActive(false);
            MP40.SetActive(false);
            STG44.SetActive(false);
            k98.SetActive(false);
            MG42.SetActive(true);
            PanzerFaust.SetActive(false);
            PanzerSchreck.SetActive(false);
            FlammenWerfer.SetActive(false);
            CurrentAnimationName = "Status_MG42";
        }
        if (weaponIndex == 5)
        {
            //Panzerfaust

            Luger.SetActive(false);
            MP40.SetActive(false);
            STG44.SetActive(false);
            k98.SetActive(false);
            MG42.SetActive(false);
            PanzerFaust.SetActive(true);
            PanzerSchreck.SetActive(false);
            FlammenWerfer.SetActive(false);
            CurrentAnimationName = "Status_panzerfaust";
        }
        if (weaponIndex == 6)
        {
            //PanzerSchreck

            Luger.SetActive(false);
            MP40.SetActive(false);
            STG44.SetActive(false);
            k98.SetActive(false);
            MG42.SetActive(false);
            PanzerFaust.SetActive(false);
            PanzerSchreck.SetActive(true);
            FlammenWerfer.SetActive(false);
            CurrentAnimationName = "Status_panzerschreck";
        }
        if (weaponIndex == 7)
        {
            //Flammenwerfer

            Luger.SetActive(false);
            MP40.SetActive(false);
            STG44.SetActive(false);
            k98.SetActive(false);
            MG42.SetActive(false);
            PanzerFaust.SetActive(false);
            PanzerSchreck.SetActive(false);
            FlammenWerfer.SetActive(true);
            CurrentAnimationName = "Flammenwerfer_status";
        }

        // idle
        
        anim.SetInteger(CurrentAnimationName, 1);
        if(weaponIndex == 7)
        {
            anim.SetInteger(CurrentAnimationName, 1);
        }
        if (weaponIndex == 6)
        {
            anim.SetInteger(CurrentAnimationName, 2);
        }
        if (weaponIndex == 5)
        {
            anim.SetInteger(CurrentAnimationName, 2);
        }

        yield return new WaitForSeconds(4);
        // aim
        anim.SetInteger(CurrentAnimationName, 2);

        yield return new WaitForSeconds(4);
        // reload
        anim.SetInteger(CurrentAnimationName, 3);

        yield return new WaitForSeconds(8);
        // ALL to Null to avoid animation mixes
        anim.SetInteger(CurrentAnimationName, 0);




        if (weaponIndex < 8)
        {
            weaponIndex+=1;
        }
        else
        {
            weaponIndex = 0;
        }
        weaponSwap = StartCoroutine(SwitchWeapons());
    }



}
