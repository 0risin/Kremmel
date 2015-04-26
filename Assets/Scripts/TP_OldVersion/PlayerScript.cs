using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	//player vars
	public float PlayerMoveSpeed = 5.0f; //determines PLAYER SPEED
	public float PlayerRotationSpeed = 100.0f;
	public float PlayerJumpSpeed = 15.0f;
	public float PlayerFallSpeed = 20.0f;


	//game objects
	Transform PlayerTransform;
	Quaternion PlayerQuaternion = new Quaternion();
	Vector3 GroundMovement;
	Vector3 PlayerMovement;
	Vector3 AirMovement;

	CharacterController PlayerController; //easy access to the Objects (PLAYERS) CHARACTER CONTROLLER
	Camera Cam; 

	void Start () {
		PlayerController = GetComponent<CharacterController> (); //easy access to the Objects (PLAYERS) CHARACTER CONTROLLER
		Cam = Camera.main;

	}


	void Update () {
		MovePlayer ();
		}

	void MovePlayer(){

		//transform.Rotate (0,Input.GetAxis("Horizontal")*playerRotationSpeed*Time.deltaTime,0); //Insted of walking sideways, rotate by Horizontal-Axis (Horizontal-Axis from playerController.Move has to be deleted to prevent interference!
	
		/*moves PLAYER and its ROTATION HORIZONTAL and VERTICAL along the X-AXIS and Y-AXIS*/

		GroundMovement = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));

        GroundMovement = Cam.transform.TransformDirection(GroundMovement);

		//Gravity and Jumping
		if (!PlayerController.isGrounded) {
			AirMovement += new Vector3 (0, -PlayerFallSpeed * Time.deltaTime, 0);	
		} else {
			AirMovement.y=0;
			if(Input.GetButtonDown("Jump")){
				AirMovement.y=PlayerJumpSpeed;
			}
		}

		GroundMovement *= PlayerMoveSpeed;
		PlayerMovement = AirMovement + GroundMovement;

        PlayerController.Move(GroundMovement*Time.deltaTime);

		if (GroundMovement != Vector3.zero) {
			transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle (transform.localRotation.eulerAngles.y, Quaternion.LookRotation (GroundMovement).eulerAngles.y, 200.0f * Time.deltaTime);
		}
}
	

}