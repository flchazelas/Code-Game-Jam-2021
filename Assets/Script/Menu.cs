using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    bool isPaused = false;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) {
            isPaused = false;
            canvas.SetActive(true);
        }

        if (isPaused)
            Time.timeScale = 0f; // Le temps s'arrete

        else
            Time.timeScale = 1.0f; // Le temps reprend
    }

    public void Continuer()
    {
        isPaused = true;
        canvas.SetActive(false);
    }

    public void Jouer()
    {
        SceneManager.LoadScene("Ile_map");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
