using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfraidEnemy : MonoBehaviour
{
    private GameObject target;

    float lerpTime = 1f;
    float currentLerpTime;
    float moveDistance = 10f;

    Vector3 startPos;
    Vector3 endPos;

    bool isLerping = false;
    bool isCloseCombat = false;


    Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.gameObject;

            updateLerpingParams();
        }
    }

    //Contact
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
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
        else
        {

            if (isLerping)
            {
                currentLerpTime += Time.deltaTime;
                if (currentLerpTime > lerpTime)
                {
                    currentLerpTime = lerpTime;
                }

                Vector3 direction = startPos - endPos;
                Vector3 destination = startPos + direction;
                float perc = currentLerpTime / lerpTime;
                transform.position = Vector3.Lerp(startPos, destination, perc);
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
