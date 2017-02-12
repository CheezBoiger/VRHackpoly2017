using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.VR;

public class Player : MonoBehaviour 
{
	public float mouseSensitivity;
	public float speed;		//starting speed. set it to 0
	public float hardSpeed;
	public float acceleration;
	public float lives;

	public float secondStageAcceleration;

	public GameObject menu;
	public GameObject topLiveScore;
	public GameObject playButton;

	private Rigidbody rb;
	Camera mainCam;

	private int liveScore = 0;
	public Text scoreText;
	public Text menuScoreText;
	public Text menuHighScoreText;

	private float minimum = -9.4f;
	private float maximum = 9.4f;

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

	private static Player instance;

	public static Player Instance
	{
		get
		{ 
			if(instance == null)
			{
				instance = GameObject.FindObjectOfType<Player> ();
			}	
			return instance; 
		}
	}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		Time.timeScale = 0;
	}

	void Update()
	{
		
		if(lives <= 0)
		{
			die ();
		}
		if(lives > 0 && Time.timeScale != 0)
		{
			++liveScore;
			scoreText.text = liveScore.ToString ();
			if(speed<hardSpeed)
			{
				speed = speed + acceleration * Time.deltaTime;
			}		
			else
			{
				speed = speed + secondStageAcceleration * Time.deltaTime;
			}
		}


		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, minimum, maximum), transform.position.y, transform.position.z);
		//Camera.main.transform.position = transform.position;
		Debug.Log(transform.position);

	}


	void FixedUpdate ()
	{
		float moveHorizontal = InputTracking.GetLocalPosition(VRNode.CenterEye).x * 100;	
		//float moveHorizontal = Input.GetAxis ("Mouse X") * mouseSensitivity * Time.deltaTime;
		float zMove = speed * Time.deltaTime;
		Vector3 movement = new Vector3 (moveHorizontal, transform.position.y, transform.position.z + zMove);
		//rb.velocity = movement;
		rb.MovePosition(transform.position);
		transform.position = movement;
		Debug.Log("zMove: " + zMove);
	}

	public void damage()
	{
		lives -= 1;
	}

	public void die()
	{
		GameOver ();
		speed = 0;
		topLiveScore.SetActive (false);
		menu.SetActive (true);
		Cursor.lockState = CursorLockMode.None;
	}

	private void GameOver()
	{

		menuScoreText.text = liveScore.ToString ();

		int bestScore = PlayerPrefs.GetInt ("BestScore", 0);

		if (liveScore > bestScore) 
		{
			PlayerPrefs.SetInt("BestScore",liveScore);
		}

		menuHighScoreText.text = PlayerPrefs.GetInt ("BestScore", 0).ToString ();
	}
}