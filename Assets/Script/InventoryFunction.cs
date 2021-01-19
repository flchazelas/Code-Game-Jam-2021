using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryFunction : MonoBehaviour
{
    public int gold;
    public int arrow;

    // Start is called before the first frame update
    void Start()
    {
        gold = 5;
        arrow = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buyItem(int price)
    {
        if(gold >= price)
        {
            for(int i=0; i<price; i++)
            {
                gold--;
            }
        }
    }

    public void attackArrow()
    {
        arrow--;
    }

    public void dropGold(string mob, int gain)
    {
        gold = gold + gain;
    }

    public void dropArrow(int gain)
    {
        arrow = arrow + gain;
    }
}
