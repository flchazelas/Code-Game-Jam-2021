using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    bool isPaused = false;
    public GameObject canvas;
    public GameObject canvasPrincipal;
    public Image imageMenu;
    public Image imageEchec;
    public Image imageFin;
    public Image imageControle;
    public Button bouton;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("prout");
        canvas.SetActive(false);
        imageEchec.enabled = false;
        imageMenu.enabled = false;
        imageFin.enabled = false;
        imageControle.enabled = false;
        bouton.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) {
            imageMenu.enabled = true;
            isPaused = true;
            canvas.SetActive(true);
            canvasPrincipal.SetActive(false);
        }

        if (isPaused)
            Time.timeScale = 0f; // Le temps s'arrete

        else
            Time.timeScale = 1.0f; // Le temps reprend

        if(GameVariables.nbHeart <= 0)
        {
            canvas.SetActive(true);
            imageEchec.enabled = true;
            bouton.gameObject.SetActive(false);
            canvasPrincipal.SetActive(false);
        }

        if (GameVariables.isWin)
        {
            canvas.SetActive(true);
            imageFin.enabled = true;
            bouton.gameObject.SetActive(false);
            canvasPrincipal.SetActive(false);
        }
    }

    public void Continuer()
    {
        isPaused = false;
        canvas.SetActive(false);
        canvasPrincipal.SetActive(true);
        imageEchec.enabled = false;
        imageMenu.enabled = false;
        imageFin.enabled = false;
    }

    public void Jouer()
    {
        GameVariables.ResetVariables();
        SceneManager.LoadScene("Ile_map");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Controle()
    {
        imageControle.enabled = true;
    }
}
