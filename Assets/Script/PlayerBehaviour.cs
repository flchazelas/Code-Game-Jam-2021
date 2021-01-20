using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 1f;
    public float sneakySpeed = 0.2f;
    public float accelerationTime = 1f;
    public float accelerationTimer = 0f;
    public GameObject arrow;
    public Image barre;

    public float arrowSpeed = 2f;
    public float arrowDistance = 1f;
    public int ptsVie;
    public int ptsDegat;

    Animator animator;

    private Rigidbody2D rgb;
    private Vector2 positionSouris;
    bool normalMode = true; //False -> Sneaky
    bool canMove = true;
    bool canShoot = true;

    bool isRunning = false;
    bool isSneaky = false;

    // Start is called before the first frame update
    void Start()
    {
        barre.gameObject.SetActive(false);
        rgb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StartCoroutine("Respire");
        ptsDegat = 10;
        ptsVie = GameVariables.nbHeart;
        MusicManager.GetMusic().PlaySound("PaisibleMusic", 2f);
    }

    // Update is called once per frame
    void Update() {
        //RUN
        float currentSpeed = normalMode ? speed : sneakySpeed;
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 direction = (new Vector2(h, v)).normalized;

        if (Mathf.Abs(h) > 0 || Mathf.Abs(v) > 0) {
            if (canMove) {
                accelerationTimer += Time.deltaTime;
            }else {
                accelerationTimer -= Time.deltaTime;
            }
        } else {
            accelerationTimer -= Time.deltaTime;
        }

        if (accelerationTimer >= accelerationTime) accelerationTimer = accelerationTime;
        if (accelerationTimer < 0) accelerationTimer = 0;

        rgb.velocity = direction * currentSpeed * (accelerationTimer / accelerationTime);

        //SHOOT
        if(GameVariables.nbArrow <= 0)
        {
            canShoot = false;
        }
        else
        {
            canShoot = true;
        }

        Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        actions(vec);

        if (Input.GetKey(KeyCode.Space)) {
            barre.gameObject.SetActive(true);
            barre.GetComponent<Animator>().SetBool("isActif", true);
            barre.GetComponent<Animator>().speed = GameVariables.speedPrepare;
        }

        //Sneaky
        if (Input.GetKey(KeyCode.LeftShift)) {
            animator.SetBool("isSneaky", true);

            if(!isSneaky && !GameVariables.isBoss){
                MusicManager.GetMusic().PlaySound("TraqueMusic", 2f);
            }

            isSneaky = true;
            normalMode = false;
        } else {
            animator.SetBool("isSneaky", false);

            if (isSneaky && !GameVariables.isBoss) {
                MusicManager.GetMusic().PlaySound("PaisibleMusic", 2f);
            }

            isSneaky = false;
            normalMode = true;
        }
    }

    public void actions(Vector2 vec) {
        //Deplacements
        if (canMove && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow)))
        {
            if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow)) {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        animator.SetBool("isRunning", rgb.velocity.magnitude > 0);
        isRunning = rgb.velocity.magnitude > 0;

        //Shoot
        if (Input.GetKey(KeyCode.Space)) {
            canMove = false;
            animator.SetBool("isPrepare", true);
            animator.speed = GameVariables.speedPrepare;
            StartCoroutine("Timer");
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            barre.gameObject.SetActive(false);
            animator.SetBool("isActif", false);

            StopCoroutine("Timer");
            animator.SetBool("isTrouble", false);
            StartCoroutine("Shoot");
            canMove = true;
            animator.speed = 1;
            if (canShoot)
            {
                GameObject a = Instantiate(arrow, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                a.transform.right = new Vector3(vec.x, vec.y, 0) - a.transform.position;
                float intensity = barre.GetComponent<BarreBehaviour>().valeur;
                a.GetComponent<ArrowBehaviour>().speed = arrowSpeed;
                a.GetComponent<ArrowBehaviour>().accelerationTime = intensity * arrowDistance;
                a.GetComponent<ArrowBehaviour>().degatsArrow = ptsDegat;
                GameVariables.nbArrow--;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            GameVariables.nbHeart--;
            ptsVie--;
        }
    }

    public float GetPlayerSoundIntensity(){
        return 1 + (isRunning ? 2 : 0) + (isSneaky ? -1 : 0);
    }

    public void WalkSound(){
        MusicManager.GetMusic().PlayEffect("walk", 0.3f);
    }

    public void WalkSmoothSound(){
        MusicManager.GetMusic().PlayEffect("walk", 0.1f);
    }

    IEnumerator Respire() {
        if (normalMode) {
            animator.SetBool("isBreath", true);
            yield return new WaitForSeconds(1);
            animator.SetBool("isBreath", false);
            yield return new WaitForSeconds(5);
            StartCoroutine("Respire");
        }
    }

    IEnumerator Timer() {
        yield return new WaitForSeconds(3);
        animator.SetBool("isTrouble", true);
        StartCoroutine("Timer");
    }

    IEnumerator Shoot() {
        MusicManager.GetMusic().PlayEffect("shoot", 0.5f);
        animator.SetBool("isShooting", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("isShooting", false);
        animator.SetBool("isPrepare", false);
    }
}
