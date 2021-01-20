using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
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
        if (other.gameObject.tag == "Arrow"); {
            //Destroy(other.gameObject);
            EnemyHeal enemy = other.gameObject.GetComponent<EnemyHeal>();
            if (enemy != null) enemy.HurtEnemy(damageToGive);
        }
    }
}
