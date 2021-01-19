using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 1f;

    private Rigidbody2D rgb;
    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal") * speed;
        float v = Input.GetAxis("Vertical") * speed;

        rgb.velocity = new Vector2(h, v);

        /*
        if (Input.GetButtonUp())
        {
            Instantiate(arrow);
        }*/
    }
}
