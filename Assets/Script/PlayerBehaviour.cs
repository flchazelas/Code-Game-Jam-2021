using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 1f;
    public float accelerationTime = 1f;
    public float accelerationTimer = 0f;
    public GameObject arrow;

    private Rigidbody2D rgb;
    private Vector2 positionSouris;


    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * speed;
        float v = Input.GetAxis("Vertical") * speed;

        if (Mathf.Abs(h) > 0 || Mathf.Abs(v) > 0)
        {
            accelerationTimer += Time.fixedDeltaTime;
        }

        else
        {
            accelerationTimer = 0;
        }

        if (accelerationTimer >= accelerationTime)
        {
            accelerationTimer = accelerationTime;
        }

        rgb.velocity = new Vector2(h, v) * (accelerationTimer / accelerationTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(vec);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            GameObject a = Instantiate(arrow, new Vector3(transform.position.x,transform.position.y,0), Quaternion.identity);
            Debug.Log(a.transform.position);
            //a.transform.forward = vec;
        }
    }
}
