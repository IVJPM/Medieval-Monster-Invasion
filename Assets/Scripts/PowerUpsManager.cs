using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsManager : MonoBehaviour
{
    public static PowerUpsManager instance;

    [SerializeField] List<GameObject> powerUpPrefabList = new List<GameObject>();

    private GameObject powerUpObject;
    // Start is called before the first frame update
    void Start()
    {
        powerUpObject = powerUpPrefabList[powerUpPrefabList.Count];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPowerUp(Transform spawnPosition)
    {
        //OnSpawnPowerUp?.Invoke(this, EventArgs.Empty);
        Instantiate(powerUpObject, spawnPosition);
    }
}
