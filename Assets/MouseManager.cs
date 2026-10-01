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


    // Start is called before the first frame update
    void Start()
    {
        
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
            launchVector = new Vector3(
                mouseDifference.x * 1f,
                mouseDifference.y * 1.2f,
                mouseDifference.z * 1.5f
               );
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
