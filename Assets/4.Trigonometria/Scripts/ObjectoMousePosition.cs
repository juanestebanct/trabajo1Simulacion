using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectoMousePosition : MonoBehaviour
{
    // Start is called before the first frame update
 
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        getmoverspace();
    }
    private void getmoverspace()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5f);
        Vector4 wordppos = camera.ScreenToWorldPoint(screenPos);
        transform.position = wordppos;
    }
}
