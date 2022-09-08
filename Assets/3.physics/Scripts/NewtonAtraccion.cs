using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewtonAtraccion : MonoBehaviour
{
    
    [SerializeField] private MyVector velocity;
    private MyVector aceleracion;
    MyVector position;
    public NewtonAtraccion target;
    public float mass=1f;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }
    private void FixedUpdate()
    {
        aceleracion *= 0f;

        MyVector r = target.transform.position - transform.position;
        float rMagnitud = r.magnitude;
        float Mass = target.mass * mass;
        float Scalarpart = (Mass)/(rMagnitud * rMagnitud);
        MyVector f = r.normalize * Scalarpart;
        ApplyForce(f);
      
        f.Draw(transform.position,Color.blue);
        Move();
        //limite de velocidad 

    }
    public void Move()
    {
        // Displacement =velocity*Time.deltaTime;

        velocity = velocity + aceleracion * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime;
        transform.position = position;
        if (velocity.magnitude > 5)
        {
            velocity.Normalize();
            velocity *= 5;
        }


        


    }
    void ApplyForce(MyVector force)
    {
        aceleracion += force * (1f / mass);
       
    }
}
