using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{

    Vector3 offectdefault;


    // Update is called once per frame
    private void Start()
    {
        offectdefault = transform.position;
        Debug.Log(offectdefault);
    }
    void Update()
    {
        Vector4 mousworldposition = getmoverspace();
        Vector3 a = (Vector3)mousworldposition -transform.position;
        float radians = Mathf.Atan2(a.y, a.x);
        rotatez(radians);



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
        transform.rotation = Quaternion.Euler(0.0f,0.0f,radians*Mathf.Rad2Deg);
    }
}
