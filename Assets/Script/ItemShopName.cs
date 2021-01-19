using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemShopName : MonoBehaviour
{
    public GameObject item;
    public Text itemName;

    // Start is called before the first frame update
    void Start()
    {
        itemName.enabled = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision");
        if (col.tag == "Player")
        {
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
