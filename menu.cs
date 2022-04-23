using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour
{

    public GameObject pausemenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void start()
    {
        SceneManager.LoadScene("level1");
    }
    public void quit()
    {
        Application.Quit();
    }

    public void returntomenu()
    {
        SceneManager.LoadScene("main menu");
        Time.timeScale = 1;
    }

    public void pausebtn()
    {
        pausemenuUI.SetActive(true);
        Time.timeScale = 0;
    }
    public void resume()
    {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
