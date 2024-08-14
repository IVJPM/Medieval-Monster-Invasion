using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] PlayerHealth playerHealth;

    void Start()
    {
        
    }

    void Update()
    {
        healthSlider.value = playerHealth.GetPlayerHealth();
    }
}
