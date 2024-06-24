using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectilesManagement : MonoBehaviour
{
    [SerializeField] float shootVelocity; 

    Rigidbody arrowRB;
    Vector3 spawnPoint;
    
    void Start()
    {
        arrowRB = GetComponent<Rigidbody>();
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
