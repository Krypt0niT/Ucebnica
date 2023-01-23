using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{

    public int blocksCount = 0;
    public int blocksRight = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        blocksRight = 0;
        for (int i = 0; i < blocksCount; i++)
        {
            if (FindObjectsOfType<block>()[i].right)
            {
                blocksRight++;
            }
        }
        if (blocksRight == blocksCount)
        {
            print("WIN");
        }
    }
}
