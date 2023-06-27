using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdder : MonoBehaviour
{
    [SerializeField] private int m_scoreToAdd;

    private void Start()
    {
        GameManager.Instance.AddScore(m_scoreToAdd);
    }

    private void Update()
    {

    }
}
