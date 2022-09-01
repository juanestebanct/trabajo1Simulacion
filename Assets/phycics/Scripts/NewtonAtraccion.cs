using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewtonAtraccion : MonoBehaviour
{
    [SerializeField] private MyVector aceleracion;
    [SerializeField] private MyVector velocity;
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
      
        MyVector r = target.transform.position - transform.position;
        float rMagnitud = r.magnitude;
        float Mass = target.mass * mass;
        MyVector f = r.normalize *((Mass /rMagnitud*rMagnitud));
        ApplyForce(f);
        f.Draw(transform.position,Color.blue);
        //limite de velocidad 
       
    }
    public void Move()
    {
        // Displacement =velocity*Time.deltaTime;

        velocity = velocity + aceleracion * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime;
        if (velocity.magnitude > 10)
        {
            velocity.Normalize();
            velocity *= 10;
        }


        transform.position = position;


    }
    void ApplyForce(MyVector force)
    {
        aceleracion += force * (1f / mass);
        Move();
    }
}
