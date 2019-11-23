using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal m_OtherPortal;
    public Transform m_Spawner;
    public float m_Impulse = 5.0f;
    public float m_Multiply = 1.0f;
    public Vector3 m_Direction = Vector3.forward;
    public bool m_Active = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!m_Active) return;
        if (m_OtherPortal == null) return;
        if (!m_OtherPortal.m_Active) return;

        var direction = m_OtherPortal.m_Spawner.TransformDirection(m_OtherPortal.m_Direction);

        other.transform.position = m_OtherPortal.m_Spawner.position;
        other.transform.rotation = Quaternion.LookRotation(direction);

        Teleportable teleportable = other.GetComponent<Teleportable>();
        teleportable.AddForce(direction, m_Impulse, m_Multiply);
    }
}
