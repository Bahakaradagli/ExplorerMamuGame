using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Computer : MonoBehaviour
{
    public string Mail1scene;
    public string Mail2scene;
    public string Mail3scene;
    public string ExitMailBoxscene;
    public string StartGameBox;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Mail1()
    {
        SceneManager.LoadScene(Mail1scene);
    }

    public void Mail2()
    {
        SceneManager.LoadScene(Mail2scene);
    }

    public void Mail3()
    {
        SceneManager.LoadScene(Mail3scene);
    }

    public void ExitMailBox()
    {
        SceneManager.LoadScene(ExitMailBoxscene);
    }

    public void StartGameComputer()
    {
        SceneManager.LoadScene(StartGameBox);
    }

}
