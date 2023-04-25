using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject cameraTarget;
    public GameObject boid;
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
            
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            cameraTriggered = false;
            boid.GetComponent<Boid>().enabled = true;
            boid.GetComponent<BoidFPSController>().enabled = false;
            mainCamera.GetComponent<FPSController>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if(other.tag == "CT")
        {
            cameraTriggered = true;
            transform.LookAt(boidRotation);
            boid.GetComponent<Boid>().enabled = false;
            boid.GetComponent<BoidFPSController>().enabled = true;
            mainCamera.GetComponent<FPSController>().enabled = false;
            Debug.Log("Camera Triggered");
        }
        
    }
}
