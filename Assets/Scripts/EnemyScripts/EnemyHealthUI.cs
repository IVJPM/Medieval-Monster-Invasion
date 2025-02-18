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
        // Might have to use the Enemy Spawn Manager to grab EnemyHealth game objects
        if (ScoreTracker.scoreCount < 2)
        {
            healthSlider.maxValue = 5;
        }
        else
        {
            healthSlider.maxValue = 20;
        }

        healthSlider.value = enemyHealth.GetEnemyHealth();
    }
}
