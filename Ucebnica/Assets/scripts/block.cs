using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class block : MonoBehaviour
{
    public string Type = null;
    public int index = 0;
    public bool right = false;

    private void Start()
    {
        print(Type +  index);
    }
    private void Update()
    {
        transform.Find("TEXT").GetComponent<TextMeshPro>().text = Type;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "plate")
        {
            if (index == other.gameObject.GetComponent<plate>().index)
            {
                print("jec rit");
                right = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "plate")
        {
           
                right = false;
            
        }
    }
}
