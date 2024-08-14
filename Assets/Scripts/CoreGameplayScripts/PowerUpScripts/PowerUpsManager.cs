using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsManager : MonoBehaviour
{
    public static PowerUpsManager instance;

    [SerializeField] List<GameObject> powerUpPrefabList = new List<GameObject>();

    [SerializeField] int powerUpPrefabIndex;

    [SerializeField] int spawnPowerUpChance;
    
    void Awake()
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

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SpawnPowerUp(Vector3 spawnPosition)
    {
        powerUpPrefabIndex = Random.Range(0, powerUpPrefabList.Count); //Setting the index to a random number between 0 and the max List number of objects
        Instantiate(powerUpPrefabList[powerUpPrefabIndex], spawnPosition, transform.rotation); //Instantiating the game object in the list at the index randomly generated above
    }

    public int ChanceToSpawnPowerUp()
    {
        spawnPowerUpChance = Random.Range(0, 5);
        return spawnPowerUpChance;
    }
}
