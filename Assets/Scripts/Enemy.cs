using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyTypes
{
    Enemy1,
    Enemy2
}
public class Enemy : PlayableCharacter
{
    public static int enemyHealth = 100;

    public override void KillCharacter()
    {
        animator.SetTrigger("Die");
    }

    // Update is called once per frame
    void Update()
    {
        getEnemyType(enemyType);
    }
}
