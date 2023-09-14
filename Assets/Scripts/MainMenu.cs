using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource selectionAudio;
    int gameScene = 1;
    public void PlayHandler()
    {
        SceneManager.LoadScene(gameScene);
        selectionAudio.Play();
    }
    public void ExitHandler()
    {
        selectionAudio.Play();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
