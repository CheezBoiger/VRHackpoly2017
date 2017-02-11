using System.Collections;
using System.Collections.Generic;
using UnityEngine.VR;
using UnityEngine;

public class VREnabled : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.V)) {
			VRSettings.enabled = !VRSettings.enabled;
			Debug.Log("Changed VRSettings.enabled to: " + VRSettings.enabled);
		}
	}
}
