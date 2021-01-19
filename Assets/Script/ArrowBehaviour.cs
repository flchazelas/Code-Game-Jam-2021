using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    public float speed = 2f;

    Rigidbody2D rgb;

    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rgb.MovePosition((rgb.position + Vector2.right) * speed * Time.deltaTime);
    }
}
