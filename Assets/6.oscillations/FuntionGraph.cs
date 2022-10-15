using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuntionGraph : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject m_pointprefab;
    [SerializeField] private int m_totalSamplePoint = 10;
    [SerializeField] private float separation=0.5f;
    [SerializeField] private GameObject[] m_points;
    public GameObject sphere1;
    void Start()
    {
        m_points = new GameObject[m_totalSamplePoint];
        for (int i=0;i< m_totalSamplePoint;i++)
        {
            m_points[i]= Instantiate(m_pointprefab, transform);

        }
    }
    private void Update()
    {
        /* sphere1 =transform.GetChild(0).gameObject;
         sphere1.transform.position=new Vector3(sphere1.transform.position.x,0,0);
        */
        for (int i = 0; i < m_totalSamplePoint; i++)
        {
            var NewPoint = m_points[i];
            Vector3 currePosition = NewPoint.transform.position;
            currePosition.x = i * separation;
            currePosition.y = Mathf.Sin(currePosition.x+Time.time);
            NewPoint.transform.localPosition = currePosition;

        }
    }


}
