using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariables : MonoBehaviour
{
    public static int nbGold = 10;
    public static int nbArrow = 5;
    public static int nbHeart = 5;
    public static int arrowDamage = 6;
    public static float speedPrepare = 1.5f;
    public static bool isWin = false;

    public static void ResetVariables(){
        nbGold = 10;
        nbArrow = 5;
        nbHeart = 5;
        arrowDamage = 6;
        speedPrepare = 1.5f;
        isWin = false;
    }
}
