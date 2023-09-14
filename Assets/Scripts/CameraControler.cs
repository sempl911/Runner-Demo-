using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] Transform _playerPos;
    [SerializeField] float cameraOffsetX = -5f;
    [SerializeField] float cameraOffsetY = 5f;
    [SerializeField] GameObject _gameMusic;

    private void Start()
    {
        _gameMusic.SetActive(true);
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(_playerPos.position.x + cameraOffsetX, _playerPos.position.y + cameraOffsetY);
    }
}
