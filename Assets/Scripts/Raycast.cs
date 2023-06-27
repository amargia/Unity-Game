using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private Transform raycastPoint;
    [SerializeField] private float raycastDistance;
    [SerializeField] private LayerMask raycastLayer;
    [SerializeField] private float rayShootingForce;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            DoRaycast();
        }
    }

    private void DoRaycast()
    {
        bool raycastHit = Physics.Raycast(raycastPoint.position, raycastPoint.forward, out RaycastHit rayHit, raycastDistance, raycastLayer);
        Debug.Log($"I'm hitting {rayHit.collider.name}");

        if (raycastHit && rayHit.rigidbody != null)
        {
            rayHit.rigidbody.AddForceAtPosition(transform.forward * rayShootingForce, rayHit.point, ForceMode.Impulse);
        } 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(raycastPoint.position, raycastPoint.position + raycastPoint.forward * raycastDistance);
    }
}
