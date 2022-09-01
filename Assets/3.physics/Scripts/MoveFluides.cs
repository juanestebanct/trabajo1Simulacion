using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFluides : MonoBehaviour
{

 
    [SerializeField] private MyVector velocity;
    [SerializeField] private MyVector wind;
    [Range(0, 1)] [SerializeField] float dampingFactor = 1;

    [Header("movimiento agua ")]
    [SerializeField]  bool useFluidFriccion =false;
    [SerializeField] float waterDragCoefficient;
    [SerializeField] float frontalArea;
    [SerializeField] float gravity;
    [SerializeField] float mass = 0.1f;
    [SerializeField] MyVector weight;
    [SerializeField] MyVector dragForce;


    public float frictioncoefficienci = 0.5f;
    private MyVector position;
    private MyVector aceleracion;
    private MyVector Displacement;
    public MyVector friction;
    public float N;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        frontalArea = transform.localScale.x;

    }
    private void FixedUpdate()
    {
        aceleracion *= 0f;
        
        N = -mass * gravity;
        weight = new MyVector(0, mass * gravity);
        friction.Draw(position, Color.yellow);
        dragForce = -(0.5f) * (velocity.magnitude * velocity.magnitude)* frontalArea*waterDragCoefficient*velocity.normalize;


        if (position.y<1 && useFluidFriccion)
        {
            ApplyForce(dragForce);
        }
        else
        {
          
            friction = velocity.normalized * frictioncoefficienci * N * -1;
        }
        ApplyForce(weight);
        ApplyForce(friction);
        ApplyForce(wind);

        //aply fluido 

        Move();
    }
    // Update is called once per frame
    void Update()
    {
        velocity.Draw(position, Color.red);
    }
    public void Move()
    {
        // Displacement =velocity*Time.deltaTime;

        velocity = velocity + aceleracion * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime;

        if (position.x < -5 || position.x > 5)
        {
            position.x = Mathf.Sign(position.x) * 5;
            velocity.x *= -1;
            velocity.x *= dampingFactor;


        }
        if (position.y < -5 || position.y > 5)
        {
            position.y = Mathf.Sign(position.y) * 5;
            velocity.y = -velocity.y;
            velocity.y *= dampingFactor;

        }

        transform.position = position;


    }
    void ApplyForce(MyVector force)
    {
        aceleracion += force * (1f / mass);
    }
}
