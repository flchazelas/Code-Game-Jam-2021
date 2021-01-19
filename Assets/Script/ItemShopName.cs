using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemShopName : MonoBehaviour
{
    public GameObject item;
    public Text itemName;
    public Sprite itemView;
    public int price;
    public string name;
    

    // Start is called before the first frame update
    void Start()
    {
        itemView = GetComponent<SpriteRenderer>().sprite;
        itemName.text = name + "\n" + price + "$";
        itemName.enabled = false;   
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            itemName.enabled = true;
        }

        if (Input.GetKey(KeyCode.F))
        {
            InventoryFunction.buyItem(price);

            if(name == "Arc" || name == "arc")
            {

            }
            else if(name == "Heart" || name == "heart")
            {
                GameVariables.nbHeart++;
            }
            else if(name == "Arrow" || name == "arrow")
            {
                GameVariables.nbArrow++;
            }
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
