using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCollision : MonoBehaviour
{
    PlayerCubeCollect _cubeHolder;
   public bool addNewCube;

    private void Start()
    {
        _cubeHolder = GameObject.FindAnyObjectByType<PlayerCubeCollect>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            // addNewCube = true;
            _cubeHolder.AddCube(true);
            Destroy(gameObject);
        }
    }

    
}
