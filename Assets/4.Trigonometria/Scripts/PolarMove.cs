using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarMove : MonoBehaviour
{
    [Header("speed controles")]
    [SerializeField]
    MyVector polarCoord;
    [SerializeField]
    float angularSpeed;
    [SerializeField]
    float randialSpeed;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        polarCoord.radius += randialSpeed * Time.deltaTime;
        polarCoord.angle += angularSpeed * Time.deltaTime;
        transform.position = polarCoord.FromPolarToCartes();

    }
}
