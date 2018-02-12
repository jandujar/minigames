using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSlider : MonoBehaviour {

    [SerializeField] private Game ga;
    private Slider sl;


	// Use this for initialization
	void Start () {
        sl = GetComponent<Slider>();
        sl.minValue = 0f;
        sl.maxValue = ga.max_power;
	}
	
	// Update is called once per frame
	void Update () {
        if (ga.state != Game.GameState.Playing)
            return;

        if ((Input.GetKey(KeyCode.Space) || InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON1)) && ga.power < ga.max_power)
        {
            ga.power = ga.power + (ga.max_power / 3f) * Time.deltaTime;
            sl.value = ga.power;
        }
        else if (ga.power > 0)
        {
            ga.Launch();
        }
	}
}
