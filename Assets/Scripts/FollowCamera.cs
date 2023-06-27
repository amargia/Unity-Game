using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject camera1Object;
    [SerializeField] private GameObject camera2Object;
    // Start is called before the first frame update
    void Start()
    {
        camera1Object.SetActive(true);
        camera2Object.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            AlternateCameras();
        }
    }

    private void AlternateCameras()
    {
        camera1Object.SetActive(!camera1Object.activeSelf);
        camera2Object.SetActive(!camera2Object.activeSelf);
    }
}
