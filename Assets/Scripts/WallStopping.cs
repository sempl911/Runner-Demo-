using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallStopping : MonoBehaviour
{
    Vector3 stopPos;
    float blockLength = .95f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            // Destroy(collision.gameObject);
            collision.gameObject.transform.SetParent(gameObject.transform);
            stopPos = collision.gameObject.transform.position;
           collision.gameObject.transform.position =  CubeStop(stopPos);
        }
    }

    Vector3 CubeStop(Vector3 stopPosCube)
    {
        stopPosCube = new Vector3(transform.position.x - blockLength, transform.position.y, transform.position.z);
        return stopPosCube;
    }
}
