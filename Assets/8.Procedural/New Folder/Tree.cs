using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private GameObject BrancherPrefab;
    [SerializeField] private int maxDepth = 3;
    [SerializeField] private float min_Randon;
    [SerializeField] private float max_Randon;
    private Queue<GameObject> frontier = new Queue<GameObject>(new Queue<GameObject>());
    private Queue<GameObject> newBranches = new Queue<GameObject>();
    
   private  int currenBranches = 0;
    void Start()
    {
        GameObject root = Instantiate(BrancherPrefab, transform);
        root.name = "brancj[root]";
        frontier.Enqueue(root);
        GenerateTree();
    }
    private GameObject createBranch(GameObject prevBranch, float rotation )
    {

        GameObject branch = Instantiate(BrancherPrefab, transform);
        branch.transform.position = prevBranch.transform.position + prevBranch.transform.up;
        branch.transform.rotation = prevBranch.transform.rotation * Quaternion.Euler(0f, 0f, rotation);
        return branch;
    }
    private void GenerateTree()
    {
        if (currenBranches >= maxDepth)
        {
            return;
        }
        currenBranches++;

        // 1. crea los eleventos  
        while (frontier.Count > 0)
        {
            var prevRoot = frontier.Dequeue();

            // Add a pair of branches to the current root
            var leftBranch = createBranch(prevRoot, Random.Range(min_Randon, max_Randon));
            var rightBranch = createBranch(prevRoot, -Random.Range(min_Randon, max_Randon));

            //colocar las ramas en la cola 
            newBranches.Enqueue(leftBranch);
            newBranches.Enqueue(rightBranch);
        }

        // 2. Create a new queue using the stored elements
        int branches = newBranches.Count;
        for (int i = 0; i < branches; i++)
        {
            frontier.Enqueue(newBranches.Dequeue());
        }

        // 2.2 Go to (1) again
        GenerateTree();
    }
}
