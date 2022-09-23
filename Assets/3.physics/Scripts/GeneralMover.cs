using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralMover : MonoBehaviour
{
    private enum MOvementMOde
    {
        velocity =0, 
        acceleration
    }


    private MyVector Displacement;
    public MyVector velocity;
    public float speed;
    [SerializeField] private MOvementMOde movemenMode;
    [SerializeField] private Transform Target; 
    [SerializeField] private MyVector position;
    [SerializeField] private MyVector aceleracion;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;

    }
   
    // Update is called once per frame
    void Update()
    {
        aceleracion.Draw(position, Color.green);
        position.Draw(Color.blue);
        aceleracion *= 0;
        velocity.Draw(position, Color.red);
        switch (movemenMode)
        {
            case MOvementMOde.velocity:
                velocity = Target.position - transform.position;
                velocity.Normalize();
                velocity *= speed;
                break;
            case MOvementMOde.acceleration:
                aceleracion = Target.position - transform.position;
                break;
        }
        Move();
    }
    public void Move()
    {
        // Displacement =velocity*Time.deltaTime;
        Displacement = velocity * Time.deltaTime;
        velocity = velocity + aceleracion * Time.deltaTime;
        position = position + Displacement;

        transform.position = position;
    }
  }
