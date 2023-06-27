using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] m_spawnEnemy;

    private void Awake()
    {
        m_spawnEnemy = new Enemy[2];
    }
}
