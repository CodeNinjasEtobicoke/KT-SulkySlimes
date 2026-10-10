using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    // Update is called once per frame
    public Vector3 clickStartLocation;
    public Vector3 launchVector;
    public float launchForce;
    public Transform slimeTransform;
    public Rigidbody slimeRigidBody;


    public Vector3 originalSlimePosition;
    public Quaternion originalSlimeRotation;

    // Start is called before the first frame update
    void Start()
    {
        originalSlimePosition = slimeTransform.position;
        originalSlimeRotation = slimeTransform.rotation;
        
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickStartLocation = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseDifference = clickStartLocation - Input.mousePosition;
            Debug.Log(mouseDifference);
            launchVector = new Vector3(
                mouseDifference.y * 1f,
                mouseDifference.y * 0.7f,
                mouseDifference.x * -1.5f
               );
            slimeTransform.position = originalSlimePosition - launchVector / 400;
            launchVector.Normalize();
            //slimeTransform.position = originalSlimePosition - launchVector / 400; 
        }
        if (Input.GetMouseButtonUp(0))
        {
            slimeRigidBody.isKinematic = false;
            slimeRigidBody.AddForce(launchVector * launchForce);
        }
    }
}
