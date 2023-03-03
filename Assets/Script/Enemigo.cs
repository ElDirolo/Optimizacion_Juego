using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    /*
    public Transform[] locationPoints;
    public int locationIndex = 0;
    public bool outEnemy = false;
    private int bulletType;

    void Start()
    {
        locationIndex = Random.Range(0, locationPoints.Length);
    }
    void Update()
    {
        transform.position += transform.forward * 20 * Time.deltaTime;

        if(outEnemy == true)
        {
            Debug.Log("funciona");
            this.gameObject.SetActive(false);
            outEnemy = false;
            Respawn();
        }    
        

    }


       void OnBecameInvisible()
       {
        Debug.Log("funciona");
        this.gameObject.SetActive(false);
       }

    void OnTriggerEnter(Collider collider)
    {
        outEnemy = true;
        locationIndex = Random.Range(0, locationPoints.Length);
    }

    void OnDrawGizmos()
    {
        foreach (Transform point in locationPoints)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(point.position, 1);
        }
    }

    void Respawn()
    {
        bulletType = 1;
        GameObject Enemigo = PoolManager.Instance.GetPooledBullet(bulletType, locationPoints[locationIndex].position, locationPoints[locationIndex].rotation);
        Enemigo.SetActive(true);
    }

    */


    private int bulletType;
    public bool outEnemy = false;

    void Update()
    {
        transform.position += transform.forward * 20 * Time.deltaTime;

        if (outEnemy == true)
        {
            this.gameObject.SetActive(false);
            outEnemy = false;
            Respawn();
        }


    }

    void Respawn()
    {
        bulletType = 1;
        GameObject Enemigo = PoolManager.Instance.GetPooledBullet(bulletType, PoolManager.Instance.locationPoints[PoolManager.Instance.locationIndex].position, PoolManager.Instance.locationPoints[PoolManager.Instance.locationIndex].rotation);
        Enemigo.SetActive(true);
        PoolManager.Instance.Randomize();
    }
    void OnTriggerEnter(Collider collider)
    {
        outEnemy = true;
    }
    void OnBecameInvisible()
    {
        outEnemy = true;
    }
}
