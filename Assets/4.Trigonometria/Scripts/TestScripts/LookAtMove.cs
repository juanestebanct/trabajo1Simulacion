using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMove : MonoBehaviour
{

    Vector3 offectdefault;
    [SerializeField] Vector3 velocity;
    [SerializeField]Vector3 posicion;
    [SerializeField] Vector3 aceleracion;
    [SerializeField] float speed; 

    // Update is called once per frame
    private void Start()
    {
        offectdefault = transform.position;
        Debug.Log(offectdefault);
    }
    void Update()
    {
        Vector4 mousworldposition = getmoverspace();
        Vector3 a = (Vector3)mousworldposition - transform.position;
      

        Vector3 direcion = a.normalized;
        velocity = speed * direcion;


       
        posicion = new Vector3(velocity.x, velocity.y,0);
    
        float radians = Mathf.Atan2(a.y+ velocity.y, a.x+ velocity.x);
        rotatez(radians);  
        velocity = velocity + aceleracion * Time.deltaTime;  
        posicion = posicion + velocity * Time.deltaTime;


       
        transform.position += posicion;


    }

    private Vector4 getmoverspace()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5f);
        Vector4 wordppos = camera.ScreenToWorldPoint(screenPos);
        return wordppos;
    }

    private void rotatez(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
       

        //aceleracion = Target.position - transform.position;
    }
}
