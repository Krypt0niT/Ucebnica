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
    [SerializeField] List<GameObject> levels = new List<GameObject>();

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

                Destroy(GameObject.FindObjectOfType<Spawner>().gameObject);
                if(level< 8)
                {
                    level++;
                    blocksCount = 0;
                    Instantiate(spawner);
                }
                else
                {
                    level = 1;
                    blocksCount = 0;
                    Instantiate(spawner);
                }
                waiterTick = 0;
            }
        }
        else
        {
            waiterTick = 0;
        }



        GameObject.Find("LVLCOUNTER").GetComponent<TextMeshPro>().text = "LVL"+level;

        for (int i = 0; i < levels.Count; i++)
        {
            
                levels[i].SetActive(false);
        }

        levels[level-1].SetActive(true);
    }

}
