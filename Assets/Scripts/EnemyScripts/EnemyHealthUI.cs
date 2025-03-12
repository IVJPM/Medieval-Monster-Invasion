using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealthUI : MonoBehaviour
{
    public Slider healthSlider;
    EnemyHealth enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GetComponentInParent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = enemyHealth.GetEnemyHealth();
    }
}
