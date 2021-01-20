using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiNoise : MonoBehaviour
{
    public PlayerBehaviour player;
    public GameObject background;
    public GameObject border;
    public GameObject container;

    public Sprite uiElementSprite;
    public Color uiElementColor;

    public int sizeUi = 7;
    public float currentNoise = 0f;
    public List<GameObject> uiElementSound = new List<GameObject>();


    protected int OLD_sizeUi = -1;
    public float timeChangeVisual = 0.2f;
    protected float timerChangeVisual = 0f;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OLD_sizeUi != sizeUi){
            GenerateUi();
            OLD_sizeUi = sizeUi;
        }

        currentNoise = player.GetPlayerSoundIntensity() * 0.5f;

        timerChangeVisual += Time.deltaTime;
        if(timerChangeVisual >= timeChangeVisual){
            UpdateVisual();
            timerChangeVisual = 0.0f;
        }
    }

    void GenerateUi(){
        background.transform.localScale = new Vector2(sizeUi * 1f/32f, sizeUi * 1f / 32f);
        border.transform.localScale = new Vector2((sizeUi + 2) * 1f / 32f, (sizeUi + 2) * 1f / 32f);
        //Destroy all
        foreach (Transform child in container.transform) {
            Destroy(child.gameObject);
        }
        uiElementSound.Clear();
        float moveSmall = - 1/32f * Mathf.Floor((sizeUi - 1) / 2f);
        //Regenerate all
        for(int i = 0; i < sizeUi; i++){
            GameObject element = new GameObject("element");
            element.transform.parent = container.transform;
            SpriteRenderer spriteRenderer = element.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = uiElementSprite;
            spriteRenderer.color = uiElementColor;
            spriteRenderer.sortingOrder = 8;
            element.transform.localScale = new Vector2(0.03125f, 1f);
            element.transform.localPosition = new Vector2(moveSmall + (i * (1f / 32f)), 0f);
            uiElementSound.Add(element);
        }
    }

    void UpdateVisual(){
        for(int i = 0; i < uiElementSound.Count; i++){
            float value = Mathf.Sin(Time.time * Mathf.Pow(10, currentNoise) + i) * currentNoise * 2.0f;
            uiElementSound[i].transform.localPosition =new Vector2(uiElementSound[i].transform.localPosition.x, value);
        }
    }
}
