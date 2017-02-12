using System.Collections;
using System.Collections.Generic;
using UnityEngine.VR;
using UnityEngine;

public class MeshInput : MonoBehaviour {
	public float Force = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			HandleInput();

	}

	/// <summary>
	/// Handles the input. This detects areas where the mouse is going to manip the
	/// mesh. We will use the randomizer to handle this instead.
	/// </summary>
	void HandleInput() {
		Ray inputRay = new Ray(transform.position, Camera.main.transform.forward);
		Debug.DrawRay(inputRay.origin, inputRay.direction, Color.green, 30f);
		RaycastHit hit;
		if (Physics.Raycast(inputRay, out hit)) {
			Debug.DrawLine(inputRay.origin, inputRay.direction, Color.blue, 30f);
			MeshDeformer deformer = hit.collider.GetComponent<MeshDeformer>();
			if (deformer) {
				Vector3 point = hit.point;
				deformer.AddDeformingForce(point, Force);

			}
		}
	}
}
