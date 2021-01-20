using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //Vie Boss
    public int MaxHealth;
    public int CurrentHealth;

    private int domageBoss;

    //Deplacement Boss
    public float moveSpeed;

    private Rigidbody2D myRigidbody;

    public bool moving;

    public float timeBetweenMove;
    public float timeBetweenMoveCounter;
    public float timeToMove;
    public float timeToMoveCounter;

    private Vector3 moveDirector;

    //Reaparition Boss et degat
    public float waitToReload;
    public bool reloading;
    private GameObject thePlayer;

    public int DomageBoss { get => domageBoss; set => domageBoss = value; }

    // Start is called before the first frame update
    void Start()
    {
        DomageBoss = 1;
        CurrentHealth = MaxHealth;

        myRigidbody = GetComponent<Rigidbody2D>();

        //timeBetweenMoveCounter = timeBetweenMove;
        //timeToMoveCounter = timeToMove;

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);

    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 150)
        {
            moveSpeed = 1.5f;
        }
        if (CurrentHealth <= 100)
        {
            moveSpeed = 2f;
        }
        if (CurrentHealth <= 50)
        {
            moveSpeed = 2.5f;
            timeBetweenMove = 0.5f;
            timeToMove = 0.5f;
        }
        if (CurrentHealth <= 0)
        {
            GameVariables.nbGold += 50;
            Destroy(gameObject);
            GameVariables.isWin = true;
        }

        if (moving)
        {
            GetComponent<Animator>().SetBool("isWalking", true);
            timeToMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = moveDirector * moveSpeed;

            if (timeToMoveCounter < 0f)
            {
                moving = false;
                //timeBetweenMoveCounter = timeBetweenMove;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
                GetComponent<Animator>().SetBool("isWalking", false);
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

                moveDirector = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
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

    /*void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            GameVariables.nbHeart--;

            other.gameObject.SetActive(false);
            reloading = true;

            thePlayer = other.gameObject;
        }
    }*/

    //Vie
    public void HurtBoss(int damageToGive)
    {
        CurrentHealth -= damageToGive;
    }

    public void SetHealthMax()
    {
        CurrentHealth = MaxHealth;
    }
}

