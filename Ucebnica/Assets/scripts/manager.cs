using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class manager : MonoBehaviour
{

    public int blocksCount = 0;
    public int blocksRight = 0;

    public int level = 1;

    [SerializeField] GameObject spawner;

    float waiterTick = 0;
    float waiter = 2;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(spawner);
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
            waiterTick += Time.deltaTime;
            if(waiterTick>= waiter)
            {

            }
        }
        else
        {
            waiterTick = 0;
        }



        GameObject.Find("LVLCOUNTER").GetComponent<TextMeshPro>().text = "LVL"+GameObject.Find("Spawner").GetComponent<Spawner>().level;
    }
}
