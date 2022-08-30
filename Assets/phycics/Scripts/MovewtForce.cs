using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovewtForce : MonoBehaviour
{
    [SerializeField] private MyVector position;
    
    [SerializeField] private MyVector force;
    [SerializeField] private MyVector wind;
    [SerializeField] private float mass = 1;
    [SerializeField] private MyVector velocity;
    [SerializeField] private MyVector aceleracion;
    private MyVector Displacement;
   
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;

    }
    private void FixedUpdate()
    {
        aceleracion *= 0f;
        ApplyForce(force);
        ApplyForce(wind);
        Move();
    }
    // Update is called once per frame
    void Update()
    {
        aceleracion.Draw(position, Color.green);
        position.Draw(Color.blue);
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
         }
         if (position.y < -5 || position.y > 5)
         {
             position.y = Mathf.Sign(position.y) * 5;
             velocity.y *= -1;
         }
        
        transform.position = position;


    }
    void ApplyForce(MyVector force)
    {
        aceleracion += force / mass;
    }
}
