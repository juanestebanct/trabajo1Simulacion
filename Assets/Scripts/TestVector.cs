using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVector : MonoBehaviour
{

    [SerializeField]
    private MyVector myFirstVector;

    [SerializeField]
    private MyVector mySecondVector;
    [SerializeField]
    private MyVector mySecondVectorV1;
    [SerializeField]
    private MyVector mySecondVectorV2;
    [Range(-1f, 1f), SerializeField] float relativeDistance;
 
    void Start()
    {/*
        //MyVector obj = new MyVector(5,5);
        MyVector sumResult = myFirstVector + mySecondVector;
        myFirstVector.Sum(mySecondVector);
        Debug.Log(sumResult.x);
        Debug.Log(sumResult.y);

        MyVector resResult = myFirstVector - mySecondVector;
        myFirstVector.sub(mySecondVector);
        Debug.Log(resResult.x);
        Debug.Log(sumResult.y);

        MyVector relsultMult = myFirstVector * 2;
        */
        //Vector2 a = Vector2.left;
        //Vector2 b = Vector2.down;
        //Vector2 c = a + b;
        MyVector other = new MyVector(5,4);
        Debug.DrawLine((Vector3)other,Vector3.down,Color.red);

    }


    // Update is called once per frame
    void Update()
    {
        mySecondVectorV1.Draw(Color.blue);
        mySecondVectorV2.Draw(Color.red);

        MyVector diff = (mySecondVectorV2 - mySecondVectorV1) * relativeDistance;
        diff.Draw(mySecondVectorV1, Color.yellow);


        MyVector Lerp = (mySecondVectorV1 + diff);
        //var a = mySecondVectorV1.Lerp(diff, relativeDistance);
        Lerp.Draw(Color.green);
        //a.Draw(Color.green);


    }
}
