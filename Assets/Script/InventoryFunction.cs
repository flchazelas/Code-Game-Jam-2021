using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryFunction : MonoBehaviour
{
    public int nbGold = 5;
    public int nbArrow = 5;

    public void buyItem(int price)
    {
        if(nbGold >= price)
        {
            for(int i=0; i<price; i++)
            {
                nbGold--;
            }
        }
    }

    public void attackArrow()
    {
        nbArrow--;
    }

    public void dropGold(string mob, int gain)
    {
        nbGold += gain;
    }

    public void dropArrow(int gain)
    {
        nbArrow += gain;
    }
}
