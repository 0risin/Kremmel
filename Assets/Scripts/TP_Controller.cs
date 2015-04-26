using UnityEngine;
using System.Collections;

public class TP_Controller : MonoBehaviour {

    public static CharacterController CharacterController;
    public static TP_Controller Instance;
    public float deadzone = 0.05f;

	void Awake () {
        CharacterController = GetComponent("CharacterController") as CharacterController;
        Instance = this;
        //tell TP_Camera class to start Method v-below-v
        TP_Camera.UseExcistingOrCreateNewMainCamera();
	}
	
	void Update () {
        if (Camera.main == null)
            return;
        GetLocomotionInput();
        TP_Motor.Instance.UpdateMotor();
	}

    void GetLocomotionInput()
    {
        TP_Motor.Instance.MoveVector = Vector3.zero;

        if (Input.GetAxis("Vertical") > deadzone || Input.GetAxis("Vertical") < -deadzone)
        {
            TP_Motor.Instance.MoveVector += new Vector3(0, 0, Input.GetAxis("Vertical"));
            }
        if (Input.GetAxis("Horizontal") > deadzone || Input.GetAxis("Horizontal") < -deadzone)
        {
            TP_Motor.Instance.MoveVector += new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        }


    }
}
