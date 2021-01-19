using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariable : MonoBehaviour
{
    public static int nbGold = 5;
    public static int nbArrow = 5;

    public static void buyItem(int price)
    {
        if(nbGold >= price)
        {
            for(int i=0; i<price; i++)
            {
                nbGold--;
            }
        }
    }

    public static void attackArrow()
    {
        nbArrow--;
    }

    public static void dropGold(string mob, int gain)
    {
        nbGold += gain;
    }

    public static void dropArrow(int gain)
    {
        nbArrow += gain;
    }
}
