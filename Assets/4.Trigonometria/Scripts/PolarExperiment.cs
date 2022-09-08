using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarExperiment : MonoBehaviour
{
    [SerializeField] float angleDeg;
    [SerializeField] float radio;
    [SerializeField] float speed=5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MyVector polar = polarcartesian(angleDeg,radio);
        Debug.DrawLine(Vector3.zero, polar);
        angleDeg = angleDeg+speed*Time.deltaTime;
    }
    private MyVector polarcartesian(float angleDeg,float radio)
    {
        float x = Mathf.Cos(angleDeg * Mathf.Deg2Rad);

        float y = Mathf.Sin(angleDeg * Mathf.Deg2Rad);

        return new MyVector(x* radio, y* radio);
    }
}
