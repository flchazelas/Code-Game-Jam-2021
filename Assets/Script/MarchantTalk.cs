using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarchantTalk : MonoBehaviour{

    public Text talk;
    public GameObject uiParent;

    public float minTimePass = 0.5f;
    public float minTimerPass = 0.0f;

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

        dialogues["introduction"] = new List <string>(){ "Bonjour Spookie, bienvenue dans notre monde, ... ", "comme tout les anciens aventuriers, ...", "tu as été amené lorsque tu mangeais ton bol de céréales. ...", "J'aimerais te prévenir que les coffres que tu dois chasser sont potentiellement méchant, ...", "certains vont te fuir, d'autres vont t'attaquer. Bonne chance petit." };
        dialogues["trashtalkArrow0"] = new List<string>() { "Ah... je vois que tu es à sec.", "Mais en plus tu n'as pas d'argent ?", "Bon... Je vais te faire une fleur", "Bon ! Tiens, je te donne quelques flèches pour te dépanner..." };
        dialogues["trashtalkArrow1"] = new List<string>() { "Tu m'as pris pour les Resto Du Coeur ?", "Vu que tu fais pitié, je t'en donne encore 5 !" };
        dialogues["trashtalkArrow2"] = new List<string>() { "Bon écoute tu commence à me les casser !"," Je t'en file encore 5 !", "Si tu reviens je te tue !" };
        dialogues["triggered"] = new List<string>() { "AAAAAAAAAAHHHHHH !!!!!!!!" };
    }

    // Update is called once per frame
    void Update(){

        minTimerPass += Time.deltaTime;
        if(minTimerPass >= minTimePass) minTimerPass = minTimePass;

        if(conversationIndex >= 0 && conversationIndex < dialogues[conversationType].Count) {
            talk.text = dialogues[conversationType][conversationIndex];
        }
        else
        {
            showUI = false;
        }

        if (Input.GetMouseButtonDown(0) && minTimerPass >= minTimePass) {
            conversationIndex = conversationIndex + 1;
            if(conversationIndex >= 0 && conversationIndex <= dialogues[conversationType].Count) MusicManager.GetMusic().PlayEffect("bubble", 0.7f);
            minTimerPass = 0;
        }
        if (Input.GetMouseButtonDown(1) && minTimerPass >= minTimePass) {
            conversationIndex = conversationIndex - 1;
            if  (conversationIndex < 0) conversationIndex = 0;
            minTimerPass = 0;
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
