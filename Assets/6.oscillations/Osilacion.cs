using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Osilacion : MonoBehaviour
{

    Vector3 inicialposicion;
    [Range(0, 10f)] [SerializeField] float Displasmer = 1;
    [SerializeField] private float Period = 3;
    [SerializeField] private float Alcance = 3;
    [SerializeField] private bool diagonal = false;

    void Start()
    {
        inicialposicion = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        float rhu = 2;
        //Period = (2f * Mathf.PI * (Time.time * Period));
        rhu = Mathf.Sin(4f * Time.time)+ Mathf.Sin(2f * Time.time)+Mathf.Sin(1f * Time.time)+ Mathf.Sin(4f * Time.time);
       // transform.position = inicialposicion +( Vector3.right)*((Mathf.Sin((2f * Mathf.PI * (Time.time / Period))) * Alcance));
       if (diagonal)
       {
             transform.position = inicialposicion+ new Vector3(1,1,1)* rhu * Alcance;
       }
       else
       {
           transform.position = inicialposicion + Vector3.right * rhu * Alcance;
        }
      
        //transform.position = inicialposicion + Vector3.up * rhu * Alcance;
        //   transform.position = new Vector3(transform.position.x + (Mathf.Sin(Time.time), transform.position.y,0,);
    }
}
