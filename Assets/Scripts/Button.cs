using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public UnityEvent OnButtonPressed;
    public UnityEvent OnButtonReleased;
    private bool m_isPressed = true;

    public void PressButton()
    {
        if(m_isPressed)
        {
            OnButtonPressed?.Invoke();
            m_isPressed = false;
        } else
        {
            OnButtonReleased?.Invoke();
            m_isPressed = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PressButton();
        }
    }
}
