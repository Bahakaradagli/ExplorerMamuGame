using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public string computersScene;
    public string FirstScreen;
    public string Tutoriall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(FirstScreen);
    }

    public void Computer()
    {
        SceneManager.LoadScene(computersScene);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(Tutoriall);
    }

}
