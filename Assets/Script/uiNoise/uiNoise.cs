using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiNoise : MonoBehaviour
{
    public PlayerBehaviour player;

    public float currentNoise = 0f;
    public List<GameObject> uiElementSound = new List<GameObject>();

    public float timeChangeVisual = 0.2f;
    public float timerChangeVisual = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentNoise = player.GetPlayerSoundIntensity() * 0.5f;

        timerChangeVisual += Time.deltaTime;
        if(timerChangeVisual >= timeChangeVisual){
            UpdateVisual();
            timerChangeVisual = 0.0f;
        }
    }

    void UpdateVisual(){
        for(int i = 0; i < uiElementSound.Count; i++){
            float value = Mathf.Sin(Time.time * currentNoise * 10 + i * currentNoise) * currentNoise;
            uiElementSound[i].transform.localPosition =new Vector2(uiElementSound[i].transform.localPosition.x, value);
        }
    }
}
