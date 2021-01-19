using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    public float speed = 1f;

    Rigidbody2D rgb;

    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //rgb.velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
