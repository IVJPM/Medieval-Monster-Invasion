using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyPrefabs = new List<GameObject>();
    [SerializeField] Transform playerTarget;
    [SerializeField] int spawnIndex;
    [SerializeField] int randomeRangeX;
    [SerializeField] int randomeRangeZ;
    [SerializeField] float spawnDelay;
    [SerializeField] float spawnInterval;
    Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), spawnDelay, spawnInterval);
    }

    private void SpawnEnemy()
    {
        spawnIndex = Random.Range(0, enemyPrefabs.Count);

        spawnPosition = new Vector3(Random.Range(playerTarget.position.x - randomeRangeX, playerTarget.position.x + randomeRangeX),
        0, Random.Range(playerTarget.position.z - randomeRangeZ, playerTarget.position.z + randomeRangeZ));

        Instantiate(enemyPrefabs[spawnIndex], spawnPosition, enemyPrefabs[spawnIndex].transform.rotation);
    }
}
