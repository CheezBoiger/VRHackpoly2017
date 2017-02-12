using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class HeadTracking : MonoBehaviour {
    private Quaternion rotationWatch;
    private float temp;
    private float tempCompare;
    public GameObject player;
    private Rigidbody rb;

    // Use this for initialization
    void Start () {
		rotationWatch = InputTracking.GetLocalRotation(VRNode.CenterEye);
        temp = rotationWatch.eulerAngles.x;

        rb = player.GetComponent<Rigidbody>();
        Time.timeScale = 0;
    }

    public float getHeadX()
    {
        return InputTracking.GetLocalRotation(VRNode.CenterEye).eulerAngles.x;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Position = " + InputTracking.GetLocalPosition(VRNode.CenterEye));
        Debug.Log("Rotation = " + InputTracking.GetLocalRotation(VRNode.CenterEye));
        /*
		tempCompare = InputTracking.GetLocalRotation(VRNode.CenterEye).eulerAngles.x;

        if (tempCompare > temp)
        {
            moveRight();
        }
        if(temp < tempCompare)
        {
            moveLeft();
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.4f, 9.4f), transform.position.y, transform.position.z);
		*/
    }


    public void moveLeft()
    {
        //float moveHorizontal = InputTracking.GetLocalRotation(VRNode.CenterEye).eulerAngles.x;
        //Vector3 movement = new Vector3(-moveHorizontal, 0.0f, 0);

        //rb.velocity = (movement);
    }

    public void moveRight()
    {
        //float moveHorizontal = InputTracking.GetLocalRotation(VRNode.CenterEye).eulerAngles.x;
        //Vector3 movement = new Vector3(-moveHorizontal, 0.0f, 0);

        //rb.velocity = (movement);
    }
}
