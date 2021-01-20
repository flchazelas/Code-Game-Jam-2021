using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RammassageArrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.transform.CompareTag("Player") && transform.parent.gameObject.GetComponent<ArrowBehaviour>().FinishThrow)
        {
            GameVariables.nbArrow++;
            Destroy(transform.parent.gameObject);
            MusicManager.GetMusic().PlayEffect("getArrow", 0.3f); 
        }
    }
}
