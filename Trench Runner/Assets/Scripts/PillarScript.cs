using UnityEngine;
using System.Collections;

public class PillarScript : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Debug.Log ("pillar trigger");
			TrackManager.Instance.spawnPillar ();
			Player.Instance.damage ();
		}
	}
}
