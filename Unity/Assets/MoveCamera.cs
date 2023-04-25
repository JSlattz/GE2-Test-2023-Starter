using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject cameraTarget;
    public Vector3 cameraTargetPosition;
    public Transform boidRotation;

    bool cameraTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        {
            mainCamera = Camera.main.gameObject;
            cameraTargetPosition = cameraTarget.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        cameraTargetPosition = cameraTarget.transform.position;
        if(cameraTriggered == true)
        {
            mainCamera.transform.position = cameraTargetPosition;
            transform.LookAt(boidRotation); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if(other.tag == "CT")
        {
            cameraTriggered = true;
            Debug.Log("Camera Triggered");
        }
        
    }
}
