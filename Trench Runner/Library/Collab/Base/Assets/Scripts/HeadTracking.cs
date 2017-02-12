using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class HeadTracking : MonoBehaviour {
	private Player player;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Position = " + InputTracking.GetLocalPosition(VRNode.CenterEye));
        Debug.Log("Rotation = " + InputTracking.GetLocalRotation(VRNode.CenterEye));
		
	}
}
