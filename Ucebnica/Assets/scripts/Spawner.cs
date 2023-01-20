using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] List<GameObject> spawns = new List<GameObject>();
    [SerializeField] List<Material> colors = new List<Material>();
    [SerializeField] List<GameObject> spawnPoints = new List<GameObject>();

    [SerializeField] TextMeshPro Code;
    bool codeWrite = true;

    void Start()
    {
       
        for (int color = 0; color < colors.Count; color++)
        {
            colors[color].color = new Color(Random.Range(0.2f, 1), Random.Range(0.2f, 1), Random.Range(0.2f, 1), 255);

        }
        List<GameObject> spawned = new List<GameObject>();
        for (int pick = 0; pick < colors.Count; pick++)
        {
            GameObject rnd = spawnPoints[(int)Random.Range(0, spawnPoints.Count)];
            spawns[pick].transform.position = spawnPoints[(int)Random.Range(0, spawnPoints.Count)].transform.position  + new Vector3(Random.Range(-1.5f, 1.5f),0, Random.Range(-1.5f, 1.5f));
        }


        string[] lines = System.IO.File.ReadAllLines("Assets/sources/input.txt");


        foreach (string line in lines)
        {

            print(line);

            if (line == "--")
            {
                codeWrite = false;
            }

            if (codeWrite)
            {
                Code.text += (line + "\n");

            }

        }
        

        
    }   
    void Update()
    {

    }
}
