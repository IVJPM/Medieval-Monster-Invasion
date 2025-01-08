using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleePowerUp : MonoBehaviour
{
    public static event EventHandler OnMeleePowerUp;

    public float destroyTimer;

    void Update()
    {
        destroyTimer += Time.deltaTime;
        if (destroyTimer > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out PlayerController player))
        {
            OnMeleePowerUp?.Invoke(this, EventArgs.Empty);
        }
        Destroy(gameObject);
    }
}
