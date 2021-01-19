using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarchantTalk : MonoBehaviour{

    public Text talk;
    public GameObject uiParent;

    Dictionary<string, List<string>> dialogues = new Dictionary<string, List<string>>();

    /*
     * "introduction" : ["Hey toi comment ça va", "Non en fait je m'en fou aurevoir"]
     * "trashtalkArrow" : ["QUOI ?!", "Tu n'as plus de flèches ? Mais quel looser", "tiens."]
     */

    public string conversationType = "introduction";
    public int conversationIndex = 0;

    int nbRequestArrow = 0;
    int maxRequestArrow = 3;

    public bool showUI = true;

    // Start is called before the first frame update
    void Start(){
        nbRequestArrow = 0;

        dialogues["introduction"] = new List <string>(){ "Bonjour Spookie, bienvenue dans notre monde, ... ", "ça va ou quoi ?"};
        dialogues["trashtalkArrow0"] = new List<string>() { "Oh ? Tu n'as plus de flèches ni d'argent ?", "Bon écoute...", "Je vais te faire une fleur", "Voici 5 flèches pour toi" };
        dialogues["trashtalkArrow1"] = new List<string>() { "QUOI ?!", "Tu n'as plus de flèches ? Mais quel looser", "tiens." };
        dialogues["triggered"] = new List<string>() { "AAAAAAAAAAHHHHHH !!!!!!!!" };
    }

    // Update is called once per frame
    void Update(){
        if(conversationIndex >= 0 && conversationIndex < dialogues[conversationType].Count) {
            talk.text = dialogues[conversationType][conversationIndex];
        }
        else
        {
            showUI = false;
        }

        if (Input.GetMouseButtonDown(0)) {
            conversationIndex = conversationIndex + 1;
        }
        if (Input.GetMouseButtonDown(1)) {
            conversationIndex = conversationIndex - 1;
            if  (conversationIndex < 0) conversationIndex = 0;
        }

        uiParent.SetActive(showUI);
    }

    public void ReclameArrow()
    {
        nbRequestArrow++;
        if (nbRequestArrow < 3)
        {
            StartConversation("trashtalkArrow0");
        }
        else if(nbRequestArrow > 2 && nbRequestArrow < 5)
        {
            StartConversation("trashtalkArrow1");
        }
        else if (nbRequestArrow == 5)
        {
            StartConversation("trashtalkArrow2");
        }
        else if (nbRequestArrow > 5)
        {
            StartConversation("triggered");
            GameVariables.nbHeart = 0;
        }
    }

    protected void StartConversation(string type) {
        conversationType = type;
        conversationIndex = 0;
        showUI = true;
    }

}
