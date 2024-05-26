using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Stamina stamina;

    private void Start()
    {
        animator = GetComponent<Animator>();
        stamina = GetComponent<Stamina>();
    }

    private void Update()
    {
        bool isStamina = stamina.currentStamina > 0;
    
        bool isRunning = isStamina && !Input.GetKey(KeyCode.LeftControl) && (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift));
        
        animator.SetBool("IsRunning", isRunning);
        
        bool isSittingWithMove = Input.GetKey(KeyCode.LeftControl) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D));
        animator.SetBool("IsSittingWithMove", isSittingWithMove);
        
        bool isWalking = !isStamina || (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)));
        animator.SetBool("IsWalking", isWalking);
    
        bool isSitting = Input.GetKey(KeyCode.LeftControl) && !(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D));
        animator.SetBool("IsSitting", isSitting);
    }
}