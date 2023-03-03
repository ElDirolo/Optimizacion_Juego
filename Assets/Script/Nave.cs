using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    private CharacterController controller;
    
    public float horizontalMove;
   
    public float verticalMove;
    
    public float speed = 5;


    public Transform proyectilSpawn;

    public int bulletType;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        verticalMove = Input.GetAxis("Vertical");
        horizontalMove= Input.GetAxis("Horizontal");
        
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fuego");
            bulletType = 0;
            GameObject proyectilBall = PoolManager.Instance.GetPooledBullet(bulletType, proyectilSpawn.position, proyectilSpawn.rotation);
            proyectilBall.SetActive(true);
        }

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
            {
            Destroy(this.gameObject);
        }
    }
    void FixedUpdate()
    {
        controller.Move(new Vector3(horizontalMove, 0, verticalMove) * speed);
    }

    void Disparo()
    {

    }
}
