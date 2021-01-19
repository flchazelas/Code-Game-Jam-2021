using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D myRigidbody;

    public bool moving;

    public float timeBetweenMove;
    public float timeBetweenMoveCounter;
    public float timeToMove;
    public float timeToMoveCounter;

    private Vector3 moveDirector;

    public float waitToReload;
    public bool reloading;
    private GameObject thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        //timeBetweenMoveCounter = timeBetweenMove;
        //timeToMoveCounter = timeToMove;

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);

    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = moveDirector*moveSpeed;

            if (timeToMoveCounter < 0f)
            {
                moving = false;
                //timeBetweenMoveCounter = timeBetweenMove;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);

            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;

            if (timeBetweenMoveCounter < 0f)
            {
                moving = true;
                //timeToMoveCounter = timeToMove;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);

                moveDirector = new Vector3(Random.Range(-1f, 1f) , Random.Range(-1f, 1f) , 0f);
                moveDirector.Normalize();
            }
        }

        if (reloading)
        {
            waitToReload -= Time.deltaTime;
            if (waitToReload < 0)
            {
                Application.LoadLevel(Application.loadedLevel);
                thePlayer.SetActive(true);
            }
        }
    }

  void OnCollisionEnter2D (Collision2D other)
    {

      if( other.gameObject.name == "Perso Test")
        {
            Destroy(other.gameObject);

            other.gameObject.SetActive(false);
            reloading = true;

            thePlayer = other.gameObject;
        }
    }
}

  