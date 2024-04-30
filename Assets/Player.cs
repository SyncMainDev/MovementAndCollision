using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float m_acceleration = 150; // Meters per second
    public float m_turnSpeed = 150; // Degrees per second
    private Rigidbody m_rigidBody = null;
    // Start is called before the first frame update
    void Start()
    {
        // Cache off the rigidbody component, so we only have to call GetComponent once, and not every Update tick
        m_rigidBody = GetComponent<Rigidbody>();
        if (m_rigidBody != null)
            Debug.Log("We're ready!");
        else
            Debug.LogError($"No Rigidbody component found on Player: {name}");
    }

    // Update is called once per frame
    void Update()
    {
        // Get current rotation as Euler angles (Degrees of rotation for X, Y, and Z axes)
        Vector3 rotation = m_rigidBody.rotation.eulerAngles;
        rotation.x = 0;
        rotation.z = 0;
        // Rotate right and/or left around Y
        if (Input.GetKey(KeyCode.D))
        {
            rotation.y += m_turnSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rotation.y -= m_turnSpeed * Time.deltaTime;
        }
        // Set the rotation that we calculated
        m_rigidBody.rotation = Quaternion.Euler(rotation);
        
        // Accelerate forwards and/or backwards
        if (Input.GetKey(KeyCode.W))
        {
            m_rigidBody.AddForce(transform.forward * m_acceleration * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_rigidBody.AddForce(transform.forward * -m_acceleration * Time.deltaTime);
        }

        // Check if we're currently moving forwards or backwards.
        bool forward = Vector3.Dot(m_rigidBody.velocity, transform.forward) > 0;

        // Reapply all velocity in the new facing direction (or in the opposite direction if our velocity is negative.
        m_rigidBody.velocity = m_rigidBody.velocity.magnitude * transform.forward * (forward ? 1.0f : -1.0f);
    }
}
