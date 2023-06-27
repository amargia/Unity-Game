using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int bulletDamage;
    [SerializeField] private float initialTime = 5f;
    private float currentTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) 
        {
            if (Enemy.enemyHealth > 0)
            {
                Enemy.enemyHealth -= 20;
                Destroy(this.gameObject);
            } else if (Enemy.enemyHealth == 0)
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                Enemy.enemyHealth = 100;
            }
            Debug.Log($"Vida enemigo: {Enemy.enemyHealth}");
        } 
        else if (other.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
    private void Speed()
    {
        bulletSpeed = 3;
    }

    private void Awake()
    {
        currentTime = initialTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += bulletSpeed * Time.deltaTime * transform.forward;

        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}