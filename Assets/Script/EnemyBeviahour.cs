using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class EnemyBeviahour : MonoBehaviour
{

    private EnemyPathfindingMovement pathfindingMovement;
    public float moveSpeedBase;
    public float moveSpeedCmbt;


    private Vector3 startingPosition;
    
    
    private void Start()
    {
        startingPosition = transform.position;
    }

    private Vector3 GetRoamingPosition()
    {
        Vector3 move;   
        move = UtilsClass.GetRandomDir() * Random.Range(10f,50f);
        return move;
    }
}
