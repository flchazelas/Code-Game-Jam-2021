using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchandAnimation : MonoBehaviour
{
    bool cote;

    // Start is called before the first frame update
    void Start()
    {
        cote = GetComponent<Animator>().GetBool("droit");
        StartCoroutine("Timer", 7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Timer(float val)
    {
        float rand = Random.Range(5f, 10f);
        yield return new WaitForSeconds(val);
        if (cote)
        {
            GetComponent<Animator>().SetBool("gauche", true);
            GetComponent<Animator>().SetBool("droit", false);
            cote = !cote;
        }
        else
        {
            GetComponent<Animator>().SetBool("gauche", false);
            GetComponent<Animator>().SetBool("droit", true);
            cote = !cote;
        }
        StartCoroutine("Timer", rand);
    }
}
