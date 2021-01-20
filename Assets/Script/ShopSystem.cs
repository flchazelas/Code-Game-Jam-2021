﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    public GameObject item;
    public Text itemName;
    public Sprite itemView;
    public int price;
    public bool trig;
    public string name;
    

    // Start is called before the first frame update
    void Start()
    {
        itemView = GetComponent<SpriteRenderer>().sprite;
        itemName.text = name + " " + price.ToString() + "$";
        itemName.enabled = false;   
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F) && trig)
        {
            if (name == "Level Up")
            {
                GameVariables.arrowDamage += 2;
                GameVariables.speedPrepare += 0.5f;
                InventoryFunction.buyItem(price);
            }
            else if (name == "Heart")
            {
                if (GameVariables.nbHeart < 5)
                {
                    Debug.Log("P");
                    GameVariables.nbHeart++;
                    InventoryFunction.buyItem(price);
                }
            }
            else if (name == "Arrow")
            {
                GameVariables.nbArrow++;
                InventoryFunction.buyItem(price);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.tag == "Player")
        {
            trig = true;
            Debug.Log(itemName.text);
            itemName.enabled = true;
        }


    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            itemName.enabled = false;
        }
    }

}
