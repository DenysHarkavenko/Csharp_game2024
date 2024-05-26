using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    public float jumpForce = 5f;
    private bool isJumping = false; 
    private Rigidbody rb; 

    public GameObject MainMenu;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        transform.Translate(direction * Time.deltaTime);
    }

    public void Rotate(float speed)
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }

    public void Jump()
    {
        if (!isJumping)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.VelocityChange);
            isJumping = true; 
        }
    }

    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isJumping = false; 
        }
    }

    public void OnClickContinue()
    {
        MainMenu.SetActive(false);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); 
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}