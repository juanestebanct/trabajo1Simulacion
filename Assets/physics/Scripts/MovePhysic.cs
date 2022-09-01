using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePhysic : MonoBehaviour
{
   
    [SerializeField] private float gravity;
    [SerializeField] private float mass =0.1f;
    [SerializeField] private MyVector velocity;  
    [SerializeField] private MyVector wind    ;
    private MyVector position;
    private MyVector aceleracion;
    private MyVector Displacement;
    public MyVector friction;
    [Range(0, 1)] [SerializeField] float dampingFactor =1;
    
    public float N;
    public float frictioncoefficienci=0.5f;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;

    }
    private void FixedUpdate()
    {
      
         N = -mass * gravity;

        MyVector weight = new MyVector(0, mass * gravity);
        friction = velocity.normalized * frictioncoefficienci * N *-1;
        friction.Draw(position, Color.yellow);
        aceleracion *= 0f;
      
        ApplyForce(weight);
        ApplyForce(friction);
        ApplyForce(wind);
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
            velocity.y*= dampingFactor;

        }

        transform.position = position;


    }
    void ApplyForce(MyVector force)
    {
        aceleracion += force * (1f / mass);
    }
}
