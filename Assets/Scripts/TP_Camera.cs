using UnityEngine;
using System.Collections;

public class TP_Camera : MonoBehaviour {

    //Instance of this Script (TP_Camera class)
    public static TP_Camera Instance;
    
    //GameObject to look at
    public Transform TargetLookAtGameObjectTransformOnly;

    void Start()
    {

    }
    
    void Awake () {
        //assign class to var
        Instance = this;
       
	}
	
	void Update () {
	    
	}
    public static void UseExcistingOrCreateNewMainCamera(){
        
        //instance var of MainCamera
        GameObject tempCamera;
        //instance  var of TargetLookAt GameObject
        GameObject targetLookAtVar;
        //instance  var of class(?)
        TP_Camera myCamera;

        //check if MainCamera excists if so assign Camera-GameObject to tempCamera var
        if(Camera.main!= null){
            
            tempCamera = Camera.main.gameObject;
        }
        else
        {
            //else make a new GameObject called "Main Camera" and assign to tempCamera
            tempCamera = new GameObject("MainCamera");
            //Add a camera to component
            tempCamera.AddComponent<Camera>();
            //Tag it as "MainCamera" (unity practice)
            tempCamera.tag = "MainCamera";

        }
        //Add TP_Camera a class to tempCamera
        tempCamera.AddComponent<TP_Camera>();
        //TP_Camera class var is getting TP_Camera class from tempCamera (why?)
        myCamera = tempCamera.GetComponent<TP_Camera>()as TP_Camera;

        //find gameobj TargetLookAt and assign to targetLookAt var
        targetLookAtVar = GameObject.Find("targetLookAt") as GameObject;
        //if not excistant make a new one, assign it and place it at (0,0,0)
        if (targetLookAtVar == null)
        {
            targetLookAtVar = new GameObject("targetLookAt");
            targetLookAtVar.transform.position = Vector3.zero;
        }
        //finally take the transform from the TargetLookAt var and tell THIS class to assign it to its TargetLookAtGameObjectTransformOnly(...)
        myCamera.TargetLookAtGameObjectTransformOnly = targetLookAtVar.transform;
}
}
