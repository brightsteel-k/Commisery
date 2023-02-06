using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

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
        SceneManager.LoadScene(1);
    }

    public void EndStory()
    {
        SceneManager.LoadScene(2);
    }

        public void EndInstructions1()
    {
        SceneManager.LoadScene(3);
    }

    public void EndInstructions2()
    {
        SceneManager.LoadScene(4);
    }

    public void EndInstructions3()
    {
        SceneManager.LoadScene(5);
    }

    public void Retry()
    {
        EventManager.ResetEvents();
        LeanTween.cancelAll();
        SceneManager.LoadScene(0);
    }
}
