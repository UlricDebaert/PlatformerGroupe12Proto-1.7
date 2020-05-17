using UnityEngine.SceneManagement;
using UnityEngine;


public class GameManage : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;

    public void CompleteLevel()
    {
        Debug.Log("Level Won");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}

