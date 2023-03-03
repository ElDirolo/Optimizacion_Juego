using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [System.Serializable]

    public class Pool
    {

        public string ProyectilName;

        public GameObject objeto;

        public int numero;

        public List<GameObject> pooledBullets;
    }

    public List<Pool> bulletsList;

    public static PoolManager Instance;

    public Transform[] locationPoints;
    public int locationIndex = 0;

    void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        GameObject bullet;
        foreach (Pool pool in bulletsList)
        {
            GameObject parent = new GameObject(pool.ProyectilName);

            for (int i = 0; i < pool.numero; i++)             //
            {
                bullet = Instantiate(pool.objeto);
                bullet.transform.SetParent(parent.transform);
                bullet.SetActive(false);
                pool.pooledBullets.Add(bullet);
            }
        }


        locationIndex = Random.Range(0, locationPoints.Length);
    }

    public GameObject GetPooledBullet(int bulletType, Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < bulletsList[bulletType].numero; i++)              //
        {
            if (!bulletsList[bulletType].pooledBullets[i].activeInHierarchy)
            {
                GameObject objectToSpwan;
                objectToSpwan = bulletsList[bulletType].pooledBullets[i];
                objectToSpwan.transform.position = position;
                objectToSpwan.transform.rotation = rotation;
                return objectToSpwan;
            }
        }
        return null;

    }

    void OnDrawGizmos()
    {
        foreach (Transform point in locationPoints)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(point.position, 1);
        }
    }

    public void Randomize()
    {
        locationIndex = Random.Range(0, locationPoints.Length);
    }
}
