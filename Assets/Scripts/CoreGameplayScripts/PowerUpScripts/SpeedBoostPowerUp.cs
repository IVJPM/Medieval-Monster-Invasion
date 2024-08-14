using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPowerUp : MonoBehaviour
{
    public float speedBoost {  get; private set; }
    public bool boosted;
    public float destroyTimer;
    private void Update()
    {
        destroyTimer += Time.deltaTime;
        if(destroyTimer > 10)
        {
            Destroy(gameObject);
        }
    }

    public float BoostPlayerSpeed(float speed)
    {
        if(boosted == false)
        {
            boosted = true;
            speedBoost = speed;
        }
        return speedBoost;
    }
}
