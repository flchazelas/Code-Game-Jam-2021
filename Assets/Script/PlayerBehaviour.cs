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
    bool mode = true;
    bool canMove = true;


    // Start is called before the first frame update
    void Start()
    {
        barre.enabled = false;
        rgb = GetComponent<Rigidbody2D>();
        StartCoroutine("Respire");
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * speed;
        float v = Input.GetAxis("Vertical") * speed;

        if (Mathf.Abs(h) > 0 || Mathf.Abs(v) > 0)
        {
            if (canMove)
                accelerationTimer += Time.fixedDeltaTime;
            else
            {
                accelerationTimer = 0;
            }
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

        actions(vec);

        if (Input.GetKey(KeyCode.Space))
        {
            barre.enabled = true;
            barre.GetComponent<Animator>().SetBool("isActif", true);
        }

        //Sneaky
        if (Input.GetKey(KeyCode.LeftControl))
        {
            GetComponent<Animator>().SetBool("isSneaky", true);
            mode = false;
        }
        else
        {
            GetComponent<Animator>().SetBool("isSneaky", false);
            mode = true;
        }
    }

    public void actions(Vector2 vec)
    {
        //Deplacements
        if (canMove && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow)))
        {
            if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            GetComponent<Animator>().SetBool("isRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isRunning", false);
        }

        //Shoot
        if (Input.GetKey(KeyCode.Space))
        {
            canMove = false;
            GetComponent<Animator>().SetBool("isPrepare", true);
            StartCoroutine("Timer");
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            barre.enabled = false;
            barre.GetComponent<Animator>().SetBool("isActif", false);
            GameObject a = Instantiate(arrow, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            a.transform.right = new Vector3(vec.x, vec.y, 0) - a.transform.position;
            a.GetComponent<ArrowBehaviour>().speed = barre.GetComponent<BarreBehaviour>().valeur;
            Debug.Log(a.transform.position);
            StopCoroutine("Timer");
            GetComponent<Animator>().SetBool("isTrouble", false);
            StartCoroutine("Shoot");
            canMove = true;
        }
    }

    IEnumerator Respire()
    {
        if (mode)
        {
            GetComponent<Animator>().SetBool("isBreath", true);
            yield return new WaitForSeconds(1);
            GetComponent<Animator>().SetBool("isBreath", false);
            yield return new WaitForSeconds(5);
            StartCoroutine("Respire");
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetBool("isTrouble", true);
        StartCoroutine("Timer");
    }

    IEnumerator Shoot()
    {
        GetComponent<Animator>().SetBool("isShooting", true);
        yield return new WaitForSeconds(0.5f);
        GetComponent<Animator>().SetBool("isShooting", false);
        GetComponent<Animator>().SetBool("isPrepare", false);
    }
}
