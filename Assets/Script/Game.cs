using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Image coeur1;
    public Image coeur2;
    public Image coeur3;
    public Image coeur4;
    public Image coeur5;
    public Text nbArrow;
    public Text nbPiece;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nbArrow.text = GameVariables.nbArrow.ToString();
        nbPiece.text = GameVariables.nbGold.ToString();

        switch (GameVariables.nbHeart)
        {
            case 5:
                coeur5.enabled = true;
                coeur4.enabled = true;
                coeur3.enabled = true;
                coeur2.enabled = true;
                coeur1.enabled = true;
                break;
            case 4:
                coeur5.enabled = false;
                coeur4.enabled = true;
                coeur3.enabled = true;
                coeur2.enabled = true;
                coeur1.enabled = true;
                break;
            case 3:
                coeur5.enabled = false;
                coeur4.enabled = false;
                coeur3.enabled = true;
                coeur2.enabled = true;
                coeur1.enabled = true;
                break;
            case 2:
                coeur5.enabled = false;
                coeur4.enabled = false;
                coeur3.enabled = false;
                coeur2.enabled = true;
                coeur1.enabled = true;
                break;
            case 1:
                coeur5.enabled = false;
                coeur4.enabled = false;
                coeur3.enabled = false;
                coeur2.enabled = false;
                coeur1.enabled = true;
                break;
            case 0:
                coeur5.enabled = false;
                coeur4.enabled = false;
                coeur3.enabled = false;
                coeur2.enabled = false;
                coeur1.enabled = false;
                break;
        }
    }
}
