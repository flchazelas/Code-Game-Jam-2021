using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeal : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;
    private int degatDommage;

    public int DegatDommage { get => degatDommage; set => degatDommage = value; }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        DegatDommage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentHealth <= 0)
        {
            GameVariables.nbGold += 10;
            Debug.Log("CREATION EXPLOSION");
            GameObject explosion = Instantiate((GameObject)Resources.Load("prefabs/Explosion"));
            explosion.transform.position = transform.position;
            Destroy(gameObject);
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        CurrentHealth -= damageToGive;
    }

    public void SetHealthMax()
    {
        CurrentHealth = MaxHealth;
    }

}
