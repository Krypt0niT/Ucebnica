using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController CHC;
    float PlayerMoveX = 0;
    float PlayerMoveZ = 0;

    float PlayerSpeed = 5;
    GameObject PlayerHand = null;


    bool spaceAvaiable = true;
    void Start()
    {
        CHC = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        if (Input.GetKey(KeyCode.W))
        {
            PlayerMoveZ = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            PlayerMoveZ = -1;
        }
        else
        {
            PlayerMoveZ = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            PlayerMoveX = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            PlayerMoveX  = 1;
        }
        else
        {
            PlayerMoveX = 0;
        }
        



        CHC.Move(new Vector3(PlayerMoveX,0,PlayerMoveZ) * Time.deltaTime * PlayerSpeed);



        //nosenie
        if (PlayerHand != null)
        {
            PlayerHand.transform.position = this.gameObject.transform.position + new Vector3(0,1f,0);
            if (Input.GetKey(KeyCode.Space) && spaceAvaiable)
            {
                PlayerHand.transform.position = this.gameObject.transform.position + new Vector3(0, 0, 0);
                PlayerHand = null;

            }
        }
        if (!Input.GetKey(KeyCode.Space))
        {
            spaceAvaiable = true;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "PickUp")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (PlayerHand == null && spaceAvaiable)
                {
                    PlayerHand = other.gameObject;
                    spaceAvaiable = false;
                }
            }
        }
    }
}
