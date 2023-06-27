using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayableCharacter : Entity
{

    [SerializeField] private Vector3 position;
    [SerializeField] public Animator animator;
    [SerializeField] private PlayableCharacterData characterData;

    [SerializeField] public EnemyTypes enemyType;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToChase = 10f;
    [SerializeField] private Bullet bulletToShoot;
    [SerializeField] private EnemyBullet enemyBullet;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private Transform shootingParent;
    [SerializeField] private float timeToShoot = 0.5f;
    public float currentTimeToShoot;
    public void Move()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        transform.position += (transform.forward * moveVertical + transform.right * moveHorizontal) * characterData.characterSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * characterData.characterRotationSpeed, Space.Self);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * characterData.characterRotationSpeed, Space.Self);
        }
    }

    public void Look()
    {
        var diffVector = target.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(diffVector.normalized);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * characterData.characterRotationSpeed);
        if (distanceToChase > diffVector.magnitude && diffVector.magnitude > 2f)
        {
            EnemyShoot();
        }
    }
    public void Chase()
    {
        var diffVector = target.position - transform.position;

        if (distanceToChase > diffVector.magnitude && diffVector.magnitude > 2f)
        {
            Quaternion newRotation = Quaternion.LookRotation(diffVector.normalized);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * characterData.characterRotationSpeed);
            EnemyMove(diffVector.normalized);
            EnemyShoot();
        }
    }

    public void EnemyShoot()
    {
        timeToShoot -= Time.deltaTime;
        if (timeToShoot <= 0) { 
            currentTimeToShoot = timeToShoot;
            Instantiate(enemyBullet, shootingPoint.transform.position, shootingPoint.transform.rotation);
            timeToShoot = 1;
        }
    }

    public void Shoot()
    {
        currentTimeToShoot = timeToShoot;
        Instantiate(bulletToShoot, shootingPoint.transform.position, shootingPoint.transform.rotation);
    }

    public void EnemyMove(Vector3 playerDirection)
    {
        transform.position += playerDirection * characterData.characterSpeed * Time.deltaTime;
    }

    public void getEnemyType(EnemyTypes enemyType)
    {
        switch (enemyType)
        {
            case EnemyTypes.Enemy1:
                Chase();
                break;
            case EnemyTypes.Enemy2:
                Look();
                break;
        }
    }

    public int Heal()
    {
        if (characterData.characterHealth >= 100)
        {
            characterData.characterHealth = 100;
        }
        else
        {
            characterData.characterHealth += 15;
        }
        return characterData.characterHealth;
    }
    public int TakeDamage()
    {
        if (characterData.characterHealth > 0 && characterData.characterHealth <= 100)
        {
            characterData.characterHealth -= 15;
        }
        else
        {
            characterData.characterHealth = 0;
        }
        return characterData.characterHealth;
    }

    public abstract void KillCharacter();
}
