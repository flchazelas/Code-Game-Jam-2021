using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 1f;
    public float accelerationTime = 1f;
    public float accelerationTimer = 0f;
    public GameObject arrow;
    public Image barre;

    private Rigidbody2D rgb;
    private Vector2 positionSouris;


    // Start is called before the first frame update
    void Start()
    {
        barre.enabled = false;
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
        //Debug.Log(vec);

        if (Input.GetKey(KeyCode.Space))
        {
            barre.enabled = true;
            barre.GetComponent<Animator>().SetBool("isActif", true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            barre.enabled = false;
            barre.GetComponent<Animator>().SetBool("isActif", false);
            GameObject a = Instantiate(arrow, new Vector3(transform.position.x,transform.position.y,0), Quaternion.identity);
            a.transform.right = new Vector3(vec.x, vec.y, 0) - a.transform.position;
            a.GetComponent<ArrowBehaviour>().speed = barre.GetComponent<BarreBehaviour>().valeur;
            Debug.Log(a.transform.position);
            //a.transform.forward = vec;
        }
    }
}
