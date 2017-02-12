using UnityEngine;
using System.Collections;

public class PlaneScript : MonoBehaviour 
{
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			Debug.Log ("trigger");
			TrackManager.Instance.SpawnTrack ();
			TrackManager.Instance.spawnPillar (19);
		}
	}
}
