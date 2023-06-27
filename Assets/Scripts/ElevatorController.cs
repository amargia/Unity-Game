using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private Button m_button;
    private static readonly int Up = Animator.StringToHash("Up");

    private void Update()
    {
        m_button.OnButtonPressed.AddListener(ElevatorRise);
        m_button.OnButtonReleased.AddListener(ElevatorDown);
    }

    public void ElevatorRise()
    {
        m_animator.SetBool(Up, false);
    }

    public void ElevatorDown()
    {
        m_animator.SetBool(Up, true);
    }
}
