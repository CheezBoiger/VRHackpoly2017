using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.VR;

public class VRInteractiveItem : MonoBehaviour {
	public event System.Action OnClick;
	public event System.Action OnDown;
	public event System.Action OnUp;
	public event System.Action OnDoubleClick;
	public event System.Action OnCancel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(InputTracking.GetLocalRotation(VRNode.CenterEye).eulerAngles);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit)) {
		  
		}
	}
}
