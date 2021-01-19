using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    public float speed = 10f;
    public float accelerationTime = 2f;
    public float accelerationTimer = 0f;

    Rigidbody2D rgb;

    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        accelerationTimer = 0f;
    }

    private void FixedUpdate()
    {
        rgb.velocity = transform.right * speed * (1f-(accelerationTimer / accelerationTime));
    }

    // Update is called once per frame
    void Update()
    {
        accelerationTimer += Time.fixedDeltaTime;

        if (accelerationTimer >= accelerationTime)
        {
            accelerationTimer = accelerationTime;
        }
    }
}
