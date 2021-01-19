using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarchantTalk : MonoBehaviour{

    public Text talk1;
    public int conversationIndex = 0;
    public List<string> conversation;

    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update(){
        if(conversationIndex >= 0 && conversationIndex < conversation.Count)
        {
            talk1.text = conversation[conversationIndex];
        }
    }


}
