using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportable : MonoBehaviour
{
    private Rigidbody m_Body;
    private float m_Speed;

    private void Awake()
    {
        m_Body = GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        m_Speed = m_Body.velocity.magnitude;
    }

    public void AddForce(Vector3 direction, float impulse, float multiply)
    {
        m_Body.velocity = Vector3.zero;
        m_Body.AddForce(direction * m_Speed * multiply + direction * impulse, ForceMode.VelocityChange);
    }
}
