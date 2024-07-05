using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectilesManagement : MonoBehaviour
{
    [SerializeField] float shootVelocity;

    Rigidbody arrowRB;
    Vector3 spawnPoint;
    Vector3 powerUpSpawnPoint;
    
    void Start()
    {
        arrowRB = GetComponent<Rigidbody>();
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //powerUpSpawnPoint = transform.position;

        if (transform.parent == null)
        {
            transform.Translate(Vector3.forward * shootVelocity * Time.deltaTime);
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        else if(transform.parent != null)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        if (Vector3.Distance(spawnPoint, transform.position) > 70f)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        ShootBow.OnBowShot += ShootBow_OnBowshot;
    }

    private void OnDisable()
    {
        ShootBow.OnBowShot -= ShootBow_OnBowshot;
    }

    private void ShootBow_OnBowshot(object sender, System.EventArgs e)
    {
        transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            ScoreTracker.scoreCount++;
            if(PowerUpsManager.instance.ChanceToSpawnPowerUp() == 4)
            {
                PowerUpsManager.instance.SpawnPowerUp(new Vector3(other.transform.position.x, other.transform.position.y + .75f, other.transform.position.z));
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
