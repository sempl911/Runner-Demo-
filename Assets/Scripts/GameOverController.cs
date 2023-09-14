using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    int currentScene;
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;

    }
    public void OnTryAgain()
    {
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1;
    }
    public void OnExit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
