using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MainCharacter : PlayableCharacter
{
    [SerializeField] private Vector3 localScale;
    [SerializeField] private int m_scoreToAdd;
    [SerializeField] private GameObject WinScreen;
    public static float characterHealth = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chocolate"))
        {
            //if (characterHealth < 100)
            //{
            //    characterHealth += 20;
            //} else if (characterHealth >= 100)
            //{
            //    characterHealth = 100;
            //}
            WinScreen.SetActive(true);
            GameManager.Instance.AddScore(m_scoreToAdd);
            Time.timeScale = 0;
            Destroy(other.gameObject);
        }
    }

    public override void KillCharacter()
    {
        animator.SetTrigger("Die");
    }

    // Update is called once per frame
    private void Update()
    {
        currentTimeToShoot -= Time.deltaTime;

        var shooter = Input.GetKeyDown(KeyCode.K);
        if (shooter && currentTimeToShoot <= 0)
        {
            Shoot();
        }
        Move();
    }
}