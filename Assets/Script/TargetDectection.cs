using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDectection : MonoBehaviour
{
    private GameObject target;

    float lerpTime = 1f;
    float currentLerpTime;
    float moveDistance = 10f;

    Vector3 startPos;
    Vector3 endPos;

    bool isLerping = false;
    bool isCloseCombat = false;

    CircleCollider2D circle;

    Rigidbody2D body;

    private void Start() {
        body=GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerBehaviour player = other.gameObject.GetComponent<PlayerBehaviour>();
            if (player == null) return;

            float distance = Vector2.Distance(player.transform.position, transform.position); //Distance par rapport au joueur
            float soundEmitted = player.GetPlayerSoundIntensity();
            float radius = circle.radius;

            if (distance > radius * (80f/100f)) {
                if  (soundEmitted > 2)
                {
                    target = other.gameObject;
                                }                    
            }
            else if (distance > radius * (40f / 100f))
            {
                if (soundEmitted > 1)
                {
                    target = other.gameObject;
                } //DETECTED
            }
            else
            {
                target = other.gameObject;
            }

            updateLerpingParams();
        }
    }

    //Contact
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            isCloseCombat = true;
        }
    }
    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            isCloseCombat = false;
        }
    }
    //*****************************

     void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
            isLerping = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (target != null && playerHasMoved())
            updateLerpingParams();

        if (isCloseCombat)
        {
            isLerping = false;
        }
        else { 

        if (isLerping)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            float perc = currentLerpTime / lerpTime;
            transform.position = Vector3.Lerp(startPos, endPos, perc);
        }
        }
    }

    private void updateLerpingParams()
    {
        endPos = target.transform.position;
        startPos = transform.position;
        currentLerpTime = 0f;
        isLerping = true;
    }

    private bool playerHasMoved()
    {
        bool playerMove = false;
        if (endPos != target.transform.position)
            playerMove = true;
        else
            playerMove = false;

        return playerMove;
    }
}
