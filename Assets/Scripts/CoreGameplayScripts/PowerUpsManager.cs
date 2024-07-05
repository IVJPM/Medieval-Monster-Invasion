using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsManager : MonoBehaviour
{
    public static PowerUpsManager instance;

    [SerializeField] List<GameObject> powerUpPrefabList = new List<GameObject>();

    [SerializeField] int powerUpPrefabIndex;

    [SerializeField] int spawnPowerUpChance;
    
    void Start()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnPowerUp(Vector3 spawnPosition)
    {
        powerUpPrefabIndex = Random.Range(0, powerUpPrefabList.Count);
        Instantiate(powerUpPrefabList[powerUpPrefabIndex], spawnPosition, transform.rotation);
    }

    public int ChanceToSpawnPowerUp()
    {
        spawnPowerUpChance = Random.Range(0, 5);
        return spawnPowerUpChance;
    }
}
