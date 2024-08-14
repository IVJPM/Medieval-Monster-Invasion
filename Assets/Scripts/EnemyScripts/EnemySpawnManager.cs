using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [Header("Lists")]
    [SerializeField] List<GameObject> enemyPrefabs = new List<GameObject>();
    [SerializeField] List<Transform> spawnBoundaries = new List<Transform>();

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
        DontDestroyOnLoad(gameObject); //Will have to change this to either a singleton, or some other method of ensuring one of these is in each scene at a time
    }

    private void SpawnEnemy()
    {
        spawnIndex = Random.Range(0, enemyPrefabs.Count);

        spawnPosition = new Vector3(Random.Range(playerTarget.position.x - randomeRangeX, playerTarget.position.x + randomeRangeX),
        0, Random.Range(playerTarget.position.z - randomeRangeZ, playerTarget.position.z + randomeRangeZ));

        Instantiate(enemyPrefabs[spawnIndex], spawnPosition, enemyPrefabs[spawnIndex].transform.rotation);

        for(int i = 0; i < spawnBoundaries.Count; i++)
        {
            for(int j = 0; j < spawnIndex; j++)
            {
                if (Vector3.Distance(enemyPrefabs[spawnIndex].transform.position, playerTarget.transform.position) >= Vector3.Distance(spawnBoundaries[i].position, playerTarget.transform.position))
                {
                    Debug.LogWarning("Enemy Out Of Bounds");
                    enemyPrefabs[i].transform.position = spawnBoundaries[i].position;
                }
            }
        }
    }
}
