using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speedLeftRight;
    [SerializeField] float _moveSpeed;
    [SerializeField] AudioSource _gameMusic;
    [SerializeField] FixedJoystick _joystick;
    [SerializeField] GameObject _tapCanvas;
    [SerializeField] GameObject _gameOverObj;

    Rigidbody _playerRb;
    GameOver _isgameOver;

    float _horizontal;
    float ZleftSize = 2.37f;

    private void Start()
    {
        _playerRb = gameObject.GetComponent<Rigidbody>();
        _isgameOver = _gameOverObj.GetComponent<GameOver>();
        _gameMusic.Play();
        _tapCanvas.SetActive(true);
    }
    private void Update()
    {
        // _horizontal = Input.GetAxis("Horizontal");
        //_horizontal = _joystick.Horizontal;

        if (Input.touchCount > 0)
        {
            _horizontal = _joystick.Horizontal;
            Time.timeScale = 1;
            _tapCanvas.SetActive(false);
        }
        else 
        {
            Time.timeScale = 0;
            _tapCanvas.SetActive(true);
        }
        if (_isgameOver.IsGameOver)
        {
            _tapCanvas.SetActive(false);
        }

    }
    private void FixedUpdate()
    {
        transform.Translate(_moveSpeed, 0, 0);
        transform.Translate(0, 0, -_horizontal * speedLeftRight * Time.fixedDeltaTime);

        if (transform.position.z > ZleftSize)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, ZleftSize);
        }
        if (transform.position.z < -ZleftSize)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -ZleftSize);
        }
        //_playerRb.velocity = new Vector3(0, 0f, _horizontal * -speedLeftRight);
    }

}
