using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVelocity : MonoBehaviour
{
    [SerializeField] private MyVector position;
    [SerializeField] private MyVector aceleracion;
     private MyVector Displacement;
     private MyVector velocity;
    [SerializeField] private int state=0 ;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Displacement.Draw(position,Color.red);
        position.Draw(position,Color.blue);
        Move();
        velocity.Draw(position,Color.red);

    }
    public void Move()
    {
        // Displacement =velocity*Time.deltaTime;
        Displacement = velocity * Time.deltaTime;
        velocity = velocity +aceleracion*Time.deltaTime;
        position = position + Displacement;
      

        if (position.x<-5 || position.x>5)
        {
            position.x = Mathf.Sign(position.x)*5;
            velocity.x*= -1;
        }
        if (position.y < -5 || position.y > 5)
        {
            position.y = Mathf.Sign(position.y) * 5;
            velocity.y*= -1;
        }
        transform.position = position;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (state)
            {
                case 0://derecha
                    aceleracion.x = -aceleracion.y;
                    velocity.y = 0;
                    aceleracion.y *= 0;
                    state = 1;
                    break;
                case 1://arriba
                    aceleracion.y = aceleracion.x;
                    velocity.x = 0;
                    aceleracion.x *= 0;
                    state = 2;
                    break;
                case 2://izq
                    aceleracion.x= -aceleracion.y;
                    velocity.y = 0;
                    aceleracion.y *= 0;
                    state = 3;
                    break;
                case 3://abajo
                    aceleracion.y = aceleracion.x;
                    velocity.y = 0;
                    aceleracion.y *= 0;
                    state = 1;
                    break;
            }
        }
       
    }
}
