using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAllEnemies : MonoBehaviour
{
    GameObject[] enemiesToDestroy; 
    void Start()
    {
        
    }

    void Update()
    {
        enemiesToDestroy = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(enemiesToDestroy.Length);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (enemiesToDestroy.Length > 0)
            {
                for (int i = 0; i < enemiesToDestroy.Length; i++)
                {
                    Destroy(enemiesToDestroy[i]);
                }
                ScoreTracker.scoreCount += enemiesToDestroy.Length; //Keep outside 'for' loop to avoid increasing score by [i] squared
            }
           Destroy(gameObject);
        }
    }
}
