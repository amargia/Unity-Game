using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private int rotationSpeed;

    private void Look()
    {
        var diffVector = target.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(diffVector.normalized);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Look();
    }
}
