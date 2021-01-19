using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    public float speed = 10f;
    public float accelerationTime = 2f;
    public float accelerationTimer = 0f;
    public float degatsArrow = 1f;

    public AnimationCurve curveSpeed;

    [SerializeField] protected Sprite throwedSprite;
    bool finishThrow = false;

    Rigidbody2D rgb;

    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        accelerationTimer = 0f;
    }

    private void FixedUpdate() {
        rgb.velocity = transform.right * curveSpeed.Evaluate(accelerationTimer / accelerationTime) * speed;
    }

    // Update is called once per frame
    void Update() {
        accelerationTimer += Time.deltaTime;

        if (accelerationTimer >= accelerationTime) {
            accelerationTimer = accelerationTime;
        }

        if(!finishThrow && accelerationTimer >= accelerationTime){
            finishThrow = true;
            GetComponent<SpriteRenderer>().sprite = throwedSprite;
            transform.rotation = Quaternion.identity;
        }
    }
}
