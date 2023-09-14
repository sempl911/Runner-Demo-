using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject _gameOverCanvas;
    [SerializeField] GameObject _pauseCanvas;
    [SerializeField] AudioSource _playerDamageAudio;
    [SerializeField] AudioSource _gameMusic;

    private bool isGameOver;
    public bool IsGameOver
    {
        get => isGameOver;
    }

    private void Start()
    {
        _gameOverCanvas.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            EndGame();
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            EndGame();
        }
    }
    void EndGame()
    {
        isGameOver = true;
        Time.timeScale = 0;
        _gameOverCanvas.SetActive(true);
        //Destroy(_pauseCanvas);
        _playerDamageAudio.Play();
        _gameMusic.Stop();
    }
}
