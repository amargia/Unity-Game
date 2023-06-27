using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float initialTime;
    [SerializeField] private int bulletSpeed;
    private float currentTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (MainCharacter.characterHealth > 0)
            {
                MainCharacter.characterHealth -= 10;
                Destroy(this.gameObject);
            }
            else if (MainCharacter.characterHealth <= 0)
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                MainCharacter.characterHealth = 100;
            }
            Debug.Log($"Vida Main Character: {MainCharacter.characterHealth}");
        }
        else if (other.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
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
