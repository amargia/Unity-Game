using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] private string m_name;
    [SerializeField] private string m_id;

    public string GetName()
    {
        return m_name;
    }

    public string GetID()
    {
        return m_id;
    }
}
