using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour {

	public void moveUp(){
		this.transform.Rotate (-90, 0, 0, Space.World);
	}
}
