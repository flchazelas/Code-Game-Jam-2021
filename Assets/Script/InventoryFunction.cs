using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryFunction : MonoBehaviour
{
    public static void buyItem(int price)
    {
        if(GameVariables.nbGold >= price)
        {
            for(int i=0; i<price; i++)
            {
                GameVariables.nbGold--;
            }
        }
    }

 
}
