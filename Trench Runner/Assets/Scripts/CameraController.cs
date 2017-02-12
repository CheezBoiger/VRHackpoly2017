using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{

	public GameObject player;

	private Vector3 offset;

	private Camera cam;

	void Start ()
	{
		offset = transform.position - player.transform.position;

		cam = Camera.main;
		Cursor.lockState = CursorLockMode.None;
	}

	void LateUpdate ()
	{
		Vector3 playerTemp = player.transform.position;
		playerTemp.x = 0.0f;

		transform.position = (playerTemp + offset);

	}
}