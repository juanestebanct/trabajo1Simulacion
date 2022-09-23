using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GeneralMover))]
public class LookAtDireccion : MonoBehaviour
{
    GeneralMover MOvimiento;
    MyVector m_direction;
    float radians;
    // Start is called before the first frame update
    void Start()
    {
        MOvimiento = GetComponent<GeneralMover>();
    }

    // Update is called once per frame
    void Update()
    {
        m_direction = MOvimiento.velocity;
        radians = Mathf.Atan2(m_direction.y, m_direction.x);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }
}
