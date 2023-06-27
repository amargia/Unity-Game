using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum EnemyTypes
//{
//    Enemy1,
//    Enemy2
//}
public class Enemy3 : MonoBehaviour
{
    //[SerializeField] private EnemyTypes enemyType;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToChase = 10f;
    [SerializeField] private int moveSpeed;
    [SerializeField] private int rotationSpeed;

    private void Look()
    {
        var diffVector = target.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(diffVector.normalized);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
    }


    private void Chase()
    {
        var diffVector = target.position - transform.position;

        if (distanceToChase > diffVector.magnitude && diffVector.magnitude > 2f)
        {
            //transform.LookAt(target);
            //Quaternion newRotation = Quaternion.LookRotation(diffVector.normalized);
            //transform.rotation = newRotation;

            Quaternion newRotation = Quaternion.LookRotation(diffVector.normalized);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
            Move(diffVector.normalized);
        }
    }

    private void Move(Vector3 playerDirection)
    {
        transform.position += playerDirection * moveSpeed * Time.deltaTime;
    }
    private void getEnemyType(EnemyTypes enemyType)
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //getEnemyType(enemyType);
    }
}
