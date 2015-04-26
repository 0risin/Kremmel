using UnityEngine;
using System.Collections;

public class ThirdPCamScript : MonoBehaviour {

	//cam vars
	private float RotSpeedX = 25.0f;
	private float RotSpeedY = 12.5f;
	public float RotSettingX = 5.0f;
	public float RotSettingY = 5.0f;
	public bool InvertX=true;
	public bool InvertY=false;

	//game obj
	GameObject LCamFocus ;
	GameObject RCamFocus ;
	GameObject LCamSocket ;
	GameObject RCamSocket;
	GameObject ThirdPCamRig;
	GameObject Pivot;
	Camera Cam;

	// Use this for initialization
	void Start () {
		Cam = Camera.main;

		LCamSocket = GameObject.FindGameObjectWithTag("LCamSocket");
		RCamSocket= GameObject.FindGameObjectWithTag("RCamSocket");
		ThirdPCamRig= GameObject.FindGameObjectWithTag("ThirdPCamRig");
		Pivot = GameObject.FindGameObjectWithTag("Pivot");
	}
	
	// Update is called once per frame
	void Update () {
		moveCamera ();
	}
	void moveCamera(){


		Pivot.transform.Rotate (InvertY ? Input.GetAxis ("Mouse Y") : -Input.GetAxis ("Mouse Y") * RotSpeedY * RotSettingY * Time.deltaTime, 0, 0);
		transform.Rotate (new Vector3(0,InvertX?Input.GetAxis("Mouse X"):-Input.GetAxis("Mouse X")*RotSpeedX*RotSettingX*Time.deltaTime,0));

	}
}
