using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    public GameObject item;
    public GameObject shop;
    public Text itemName;
    public Sprite itemView;
    public int price;
    public bool trig;
    public string name;
    int level = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        itemView = GetComponent<SpriteRenderer>().sprite;
        itemName.text = price.ToString() + "$";
        itemName.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F) && trig && GameVariables.nbGold >= price)
        {
            if (name == "Level Up")
            {
                GameVariables.arrowDamage += 2;
                GameVariables.speedPrepare += 0.5f;
                InventoryFunction.buyItem(price);
                level++;
                if(level == 2)
                {
                    price = price * 2;
                }
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
        else if (Input.GetKeyUp(KeyCode.F) && trig)
        {
            shop.GetComponent<MarchantTalk>().ReclameArrow();
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
            trig = false;
            itemName.enabled = false;
        }
    }

}
