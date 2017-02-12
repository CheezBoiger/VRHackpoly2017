using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshDeformer : MonoBehaviour {
	// The Deforming mesh.
	public Mesh DeformingMesh { get; set; }
	public Vector3[] OriginalVertices { get; set; }
	public Vector3[] DisplacedVertices { get; set; }

	private Vector3[] VertexVelocities;

	// Use this for initialization
	void Start () {
		DeformingMesh = GetComponent<MeshFilter>().mesh;
		OriginalVertices = DeformingMesh.vertices;
		DisplacedVertices = new Vector3[OriginalVertices.Length];
		for (uint i = 0; i < OriginalVertices.Length; ++i) {
			DisplacedVertices[i] = OriginalVertices[i];
		}
		VertexVelocities = new Vector3[OriginalVertices.Length];

		Randomize();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void Randomize() {
		float velocity = 0.0f;
		float accel = 9.8f;		
		for (uint i = 0; i < DisplacedVertices.Length; ++i) {
			DisplacedVertices[i].y += velocity;
			DisplacedVertices[i].z += velocity;
			//DisplacedVertices[i].x += OriginalVertices[i].x;
			//DisplacedVertices[i].Normalize();
			velocity = velocity + accel * Time.deltaTime;
			Debug.Log("Vertex Displaced: " + DisplacedVertices[i]);
			Debug.DrawLine(OriginalVertices[i], DisplacedVertices[i], Color.blue, 40f);

		}
		DeformingMesh.vertices = DisplacedVertices;
		DeformingMesh.RecalculateNormals();	
	}

	void UpdateVertex(int i) {
	}

	// Perform deforming force.
	public void AddDeformingForce(Vector3 point, float Force) {
	}


}
