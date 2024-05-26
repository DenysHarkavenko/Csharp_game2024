using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera; 
    public float sensitivity = 100.0f; 
    public Transform playerBody;
    
    private float xRotation = 0.0f;
    
    void Start()
    {
        firstPersonCamera.enabled = true;
        thirdPersonCamera.enabled = false;
    }
    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            
            firstPersonCamera.enabled = !firstPersonCamera.enabled;
            thirdPersonCamera.enabled = !thirdPersonCamera.enabled;
        }
    
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
    
        xRotation -= mouseY;
    
       
        if (firstPersonCamera.enabled)
        {
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            firstPersonCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
        else
        {
            xRotation = Mathf.Clamp(xRotation, -30f, 30f);
            thirdPersonCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
    
       
        playerBody.Rotate(Vector3.up * mouseX);
    }
}