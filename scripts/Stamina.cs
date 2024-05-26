using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Stamina : MonoBehaviour
{
    public float maxStamina = 100f; 
    public float currentStamina;
    public float staminaRegenRate = 5f;
    public float staminaDrainRate = 20f;

    void Start()
    {
        currentStamina = maxStamina; 
    }

    public void DrainStamina(float amount)
    {
        currentStamina -= amount * Time.deltaTime;
        currentStamina = Mathf.Max(currentStamina, 0);
    }

    public void RegenStamina(float amount)
    {
        currentStamina += amount * Time.deltaTime;
        currentStamina = Mathf.Min(currentStamina, maxStamina);
    }
}