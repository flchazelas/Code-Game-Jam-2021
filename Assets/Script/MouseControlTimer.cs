using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseControlTimer : MonoBehaviour
{

    public bool showUI = false;
    public GameObject uiParent;

    // Start is called before the first frame update
    void Start()
    {
        showUI = false;
        Invoke("leftMB", 1.0f);
    }

    void leftMB()
    {
        showUI = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
