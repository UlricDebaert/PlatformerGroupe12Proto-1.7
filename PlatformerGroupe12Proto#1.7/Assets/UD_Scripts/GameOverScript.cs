using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public static bool gameIsOver = false;

    public GameObject GameOverScreen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Lose();
        }
    }

    public void Lose()
    {
        GameOverScreen.SetActive(true);
        Time.timeScale = 0f;
        gameIsOver = true;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        print("quit");
        Application.Quit();
    }
}
