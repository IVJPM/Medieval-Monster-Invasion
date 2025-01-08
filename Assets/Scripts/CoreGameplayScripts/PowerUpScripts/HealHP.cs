using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealHP : MonoBehaviour
{
    [SerializeField] int healthRestorationAmount;

    public float destroyTimer;

    void Update()
    {
        destroyTimer += Time.deltaTime;
        if (destroyTimer > 10)
        {
            Destroy(gameObject);
        }
    }

    public int RestoreHPAmount()
    { 
        return healthRestorationAmount;
    }
}
