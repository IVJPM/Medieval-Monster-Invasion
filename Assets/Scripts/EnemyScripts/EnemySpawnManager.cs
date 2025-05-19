using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawnManager : MonoBehaviour
{
    [Header("Lists")]
    [SerializeField] List<GameObject> enemyPrefabs = new List<GameObject>();

    [SerializeField] Transform playerTarget;
    [SerializeField] int spawnIndex;
    [SerializeField] int randomeRangeX;
    [SerializeField] int randomeRangeZ;
    [SerializeField] float spawnDelay;
    [SerializeField] float spawnInterval;

    Vector3 potentialSpawnPosition;
    Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), spawnDelay, spawnInterval);
        DontDestroyOnLoad(gameObject); //Will have to change this to either a singleton, or some other method of ensuring one of these is in each scene at a time
    }

    private void SpawnEnemy()
    {
        spawnIndex = Random.Range(0, enemyPrefabs.Count);

        spawnPosition = new Vector3(Random.Range(playerTarget.position.x - randomeRangeX, playerTarget.position.x + randomeRangeX),
        0, Random.Range(playerTarget.position.z - randomeRangeZ, playerTarget.position.z + randomeRangeZ));
 
        if(NavMesh.SamplePosition(spawnPosition, out NavMeshHit hit, 5.0f, NavMesh.AllAreas))
        {
            potentialSpawnPosition = hit.position;
            Instantiate(enemyPrefabs[spawnIndex], potentialSpawnPosition, enemyPrefabs[spawnIndex].transform.rotation);
        }
    }
}
