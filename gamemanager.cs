using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_manager : MonoBehaviour
{
    bool gamehasended = false;
    public GameObject completelevelUI;
    public void completeLevel()
    {
        completelevelUI.SetActive(true);
    }

    
    public void EndGame()
    {
        if (gamehasended == false)
        {
            gamehasended = true;
            Debug.Log("Game Over");

            Restart();
        }

    }
    
    void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

