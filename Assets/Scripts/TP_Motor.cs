using UnityEngine;
using System.Collections;

public class TP_Motor : MonoBehaviour {

    public static TP_Motor Instance;

    public float MoveSpeed = 10.0f;

    public Vector3 MoveVector { get; set; }

	void Awake () {
        Instance = this;
	}

    public void UpdateMotor()
    {
        
        ProcessMotion();
        SnapAlignCharacterWithCamera();
	}

    void ProcessMotion()
    {
        // transoform MoveVector relative to WorldSpace, then normalize if >1
        MoveVector = TP_Camera.Instance.TargetLookAtGameObjectTransformOnly.transform.TransformDirection(MoveVector);

        //MoveVector = transform.TransformDirection(Camera.main.Transform);
        if (MoveVector.magnitude > 1)
        {
            MoveVector = Vector3.Normalize(MoveVector);
        }
        // MoveVector*MoveSpeed*Time.deltaTime
        MoveVector *= MoveSpeed * Time.deltaTime;
        // Move Character in WorldSpace
        TP_Controller.CharacterController.Move(MoveVector);
    }
    void SnapAlignCharacterWithCamera()
    {
        if (MoveVector.x != 0 || MoveVector.z != 0)
        {
           //transform.rotation = Quaternion.Euler(transform.eulerAngles.x,Camera.main.transform.eulerAngles.y,transform.eulerAngles.z);
          transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.localRotation.eulerAngles.y, Quaternion.LookRotation(MoveVector).eulerAngles.y, 200.0f * Time.deltaTime);
            Debug.Log(Camera.main.transform.eulerAngles.y);
        }
    }
}
