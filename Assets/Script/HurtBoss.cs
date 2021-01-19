using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBoss : MonoBehaviour
{

    public int damageToGive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Arrow");
        {
            //Destroy(other.gameObject);
            Boss boss = other.gameObject.GetComponent<Boss>();
            if (boss != null) boss.HurtBoss(damageToGive);
        }
    }
}
