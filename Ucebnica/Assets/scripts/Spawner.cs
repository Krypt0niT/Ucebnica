using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public int level;
    int levelQuestions = 0  ;
    List<string> blocks = new List<string>();

    int lineCount = 0;
    [SerializeField] List<GameObject> spawns = new List<GameObject>();
    [SerializeField] List<Material> colors = new List<Material>();
    [SerializeField] List<GameObject> spawnPoints = new List<GameObject>();

    [SerializeField] TextMeshPro Code;

    Dictionary<string, string> CT = new Dictionary<string, string>();


    private void Awake()
    {
        level = GameObject.Find("manager").GetComponent<manager>().level;
    }
    void Start()
    {
        //nacitanie hodnoput do slovnika
        CT.Add("blue", "<color=#0077AA>");
        CT.Add("green", "<color=\"green\">");
        CT.Add("orange", "<color=\"orange\">");
        CT.Add("purple", "<color=\"purple\">");
        CT.Add("red", "<color=\"red\">");
        CT.Add("white", "<color=\"white\">");
        CT.Add("yellow", "<color=\"yellow\">");

      


        for (int color = 0; color < colors.Count; color++)
        {
            colors[color].color = new Color(Random.Range(0.2f, 1), Random.Range(0.2f, 1), Random.Range(0.2f, 1), 255);

        }
        
        string[] answers = System.IO.File.ReadAllLines("Assets/sources/answers.txt");

        int sharpCount = 0;
        foreach (string answer in answers)
        {
            if (answer == "##") { sharpCount++; continue; }
            if (sharpCount == level)
            {
                blocks.Add(answer);
            }
        }
        levelQuestions = blocks.Count;


        List<GameObject> spawned = new List<GameObject>();
        for (int pick = 0; pick < levelQuestions; pick++)
        {

            GameObject rnd = spawnPoints[(int)Random.Range(0, spawnPoints.Count)];
            spawns[pick].transform.position = spawnPoints[(int)Random.Range(0, spawnPoints.Count)].transform.position + new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-0.05f, 0.05f), Random.Range(-1.5f, 1.5f));
            spawns[pick].SetActive(true);
            print(pick);
        }
        string[] lines = System.IO.File.ReadAllLines("Assets/sources/rounds.txt");
        sharpCount = 0;

        foreach (string line in lines)
        {
            
            if(line == "##") { sharpCount++; continue; }
            if (sharpCount == level)
            {
                


                    string[] partsArray = line.Split(' ');
                    List<string> parts = partsArray.ToList();

                    for (int i = 0; i < parts.Count; i++)
                    {

                        if (parts[i] == "INSERT" ||
                            parts[i] == "INTO" ||
                            parts[i] == "VALUES" ||
                            parts[i] == "UPDATE" ||
                            parts[i] == "DELETE" ||
                            parts[i] == "SELECT" ||
                            parts[i] == "INNER" ||
                            parts[i] == "JOIN" ||
                            parts[i] == "ON" ||
                            parts[i] == "FROM"
                            )
                        {
                            Code.text += CT["blue"];
                        }

                        else
                        {
                            Code.text += CT["white"];
                            
                        }



                        /*if (parts[i].Contains("(") && parts[i].Contains(")"))
                        {
                            string[] wordCut = parts[i].Split('(',')');
                            for (int j = 0; j < wordCut.Length; j++)
                            {
                                if (parts[i][0] == '(')
                                {
                                    parts[i] = "";
                                    parts[i] += CT["orange"];
                                    parts[i] += "(";
                                    for (int l = 0; l < wordCut.Length+1; l++)
                                    {
                                        parts[i] += wordCut[j];
                                    }
                                }
                                if (parts[i][parts[i].Length-1] == ')')
                                {
                                    parts[i] = "";
                                    for (int l = 0; l < wordCut.Length; l++)
                                    {
                                        parts[i] += wordCut[j];
                                    }
                                    parts[i] += CT["orange"];
                                    parts[i] += ")";
                                    
                                }

                            }

                        }
                        else if (parts[i].Contains("("))
                        {
                            string[] wordCut = parts[i].Split('(');
                            parts[i] = "";
                            for (int j = 0; j < wordCut.Length; j++)
                            {
                                parts[i] += wordCut[j];
                                parts[i] += "(";
                            }
                        }*/

                        if (parts[i] == "@")
                        {
                            parts[i] = "       ";
                            //blocks.Add();
                        }

                        Code.text += (parts[i]);
                        Code.text += " ";

                    }
                    Code.text += "\n";
                    lineCount++;




                }



            
        }

        for (int i = 0; i < blocks.Count; i++)
        {
            spawns[i].GetComponent<block>().Type = blocks[i];
            spawns[i].GetComponent<block>().index = i;
            GameObject.Find("manager").GetComponent<manager>().blocksCount++;
        }
        for (int i = 0; i < 10; i++)
        {
            if(GameObject.Find("lvl" + (i + 1)) != null)
            {
                if(i+1 != level)
                {
                    GameObject.Find("lvl" + (i + 1)).SetActive(false);
                }
            }

        }

    }
    private void Update()
    {
        if (GameObject.Find("manager").GetComponent<manager>().blocksCount == GameObject.Find("manager").GetComponent<manager>().blocksRight)
        {
            for (int color = 0; color < colors.Count; color++)
            {
                colors[color].color = new Color(0, 1,0);

            }
        }
    }

}
