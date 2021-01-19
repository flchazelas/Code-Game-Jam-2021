﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNPC : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D myRigidbody;

    public bool isWalking;

    public float walkTime;
    public float walkCounter;
    public float waitTime;
    public float waitCounter;

    private int WalkDirection;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if(isWalking)
        {
            walkCounter -= moveSpeed;
            if(walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }
            switch (WalkDirection)
            {
                case 0:

                    break;

                case 1:

                    break;

                case 2:

                    break;
                case 3:

                    break;
            }

        }
        else
        {
            waitCounter -= moveSpeed;
            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }

    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
}