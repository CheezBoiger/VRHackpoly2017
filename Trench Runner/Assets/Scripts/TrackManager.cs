using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackManager : MonoBehaviour
{
	public GameObject nextLeftWall;
	public GameObject nextRightWall;
	public GameObject nextPlane;
	public GameObject currentLeftWall;
	public GameObject currentRightWall;
	public GameObject currentPlane;

	public GameObject startMenu;

	private Queue<GameObject> tracks = new Queue<GameObject>();
	private Queue<GameObject> leftWall = new Queue<GameObject>();
	private Queue<GameObject> rightWall = new Queue<GameObject>();

	public Queue<GameObject> Tracks
	{
		get{return tracks;}
		set{tracks = value;}
	}

	private bool firstGame = true;


	public GameObject nextPillar;
	public GameObject currentPillar;

	private Queue<GameObject> pillar = new Queue<GameObject>();

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

	private static TrackManager instance;

	public static TrackManager Instance
	{
		get
		{ 
			if(instance == null)
			{
				instance = GameObject.FindObjectOfType<TrackManager> ();
			}	
			return instance; 
		}
	}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////Start
	void Start ()
	{
		pillar.Enqueue (currentPillar);
		createPillar (37);
		spawnPillar (19);

		createTrack (1);
		tracks.Enqueue (currentPlane);
		leftWall.Enqueue (currentLeftWall);
		rightWall.Enqueue (currentRightWall);
		SpawnTrack ();
		spawnPillar (19);
	}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////Track
	void createTrack(int amount)
	{
		for(int i=0; i<amount; i++)
		{
			tracks.Enqueue(Instantiate(nextPlane));
			leftWall.Enqueue (Instantiate(nextLeftWall));
			rightWall.Enqueue (Instantiate(nextRightWall));
		}
	}
		
	public void SpawnTrack()
	{
		GameObject temp = tracks.Dequeue ();
		temp.transform.position = currentPlane.transform.GetChild (0).transform.GetChild (0).position;
		tracks.Enqueue(temp);
		currentPlane = temp;

		GameObject tempL = leftWall.Dequeue ();
		tempL.transform.position = currentLeftWall.transform.GetChild (0).transform.GetChild (0).position;
		leftWall.Enqueue(tempL);
		currentLeftWall = tempL;

		GameObject tempR = rightWall.Dequeue ();
		tempR.transform.position = currentRightWall.transform.GetChild (0).transform.GetChild (0).position;
		rightWall.Enqueue(tempR);
		currentRightWall = tempR;
	}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////Pillars
	public void createPillar(int amount)
	{
		for (int i = 0; i < amount; i++) 
		{
			pillar.Enqueue (Instantiate (nextPillar));
		}
	}

	public void spawnPillar()
	{
	}

	public void spawnPillar(int amount)
	{
		for(int i = 0;i<amount;i++)
		{
			GameObject temp = pillar.Dequeue ();
			temp.transform.position = currentPlane.transform.GetChild (0).transform.GetChild (1).position;

			Vector3 tempD = new Vector3 (Random.Range(-9.4f,9.4f),0.001f,26.26f);
			for(int j = 0;j<i;j++)
			{
				Vector3 reset = new Vector3 (0.0f,0.0f,temp.transform.position.z);
				temp.transform.position = reset;
				temp.transform.position = temp.transform.position + tempD;
			}
			pillar.Enqueue(temp);
			currentPillar = temp;
		}
	}

	public void playGame()
	{
		Time.timeScale = 1;
		startMenu.SetActive (false);
		Cursor.lockState = CursorLockMode.Locked;

	}

	public void resetGame()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
		
}
