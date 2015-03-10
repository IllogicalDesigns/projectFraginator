using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {
	public GameObject myHeadGroup;					//The rotating group for our y axis isolation
	public float myXSens = 250f;					//the X multiplication for sensitivity
	public float myYSens = 250f;					//the Y multiplication for sensitivity
	public float myCameraYLock = 50f;				//double it for how far it moves
	public bool invertY = false;					//should we invert Y axis
	public bool mouseHidden = false;				//is the mouse locked and hidden
	private float rotateX;							//Private X roatation value
	private float rotateY;							//Private Y roatation value
	
	// Update is called once per frame
	void Update () {
		rotateX = Input.GetAxis ("Mouse X") * myXSens;			//get our rotation value for our X axis
		if (invertY) 											//our we inverting our Y
			rotateY = Input.GetAxis ("Mouse Y") * myYSens;		//get our rotation value for our Y axis
		 else 
			rotateY = Input.GetAxis ("Mouse Y") * -myYSens;		//get our rotation value for our Y axis (inverted)
		
	}

	void FixedUpdate () {
		transform.Rotate(transform.up * rotateX * Time.deltaTime);					//This will rotate our main body
		myHeadGroup.transform.Rotate(Vector3.right * rotateY * Time.deltaTime);		//This will rotate our head isolated from our body
	}
}
