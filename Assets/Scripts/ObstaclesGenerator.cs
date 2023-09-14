using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour
{
    [SerializeField] GameObject obj1;
    [SerializeField] GameObject obstacleMesh;
    [SerializeField] GameObject trackMeshRend;
    [SerializeField] GameObject powerUp;
    [SerializeField] float powerUpOnTrack = 7;

    MeshRenderer _trackMesh;
    Bounds trackBound;
    Bounds obstacleBound;
    Vector3 spawnBlockPos;
    float spawnPosVertical;
    float blockLength;
    
    GameObject _powerUp;
    GameObject _obstacleUpPos;

    private void Start()
    {
        _trackMesh = trackMeshRend.GetComponent<MeshRenderer>();
        trackBound = _trackMesh.bounds;

        for (int i = 0; i < powerUpOnTrack; i++)
        {
            SpawnPowerUp();
        }
   
        obstacleBound = obstacleMesh.GetComponent<MeshRenderer>().bounds;
        blockLength = obstacleBound.max.z - obstacleBound.min.z;
        spawnPosVertical = trackBound.max.y;

        SpawnObstacle(3f, trackBound.min.x, trackBound.max.z - (blockLength/2)); // start track
        SpawnObstacle(0f, trackBound.center.x, trackBound.max.z - (blockLength/2)); // center track
        SpawnObstacle(-3f, trackBound.max.x, trackBound.max.z - (blockLength/2) - blockLength); // end track

    }

    private void Update()
    {

    }

    void SpawnPowerUp()
    {
        float tmpSpawnX;
        tmpSpawnX = Random.Range(trackBound.min.x, trackBound.max.x);
        tmpSpawnX = Mathf.Clamp(tmpSpawnX, trackBound.min.x + 2f, trackBound.max.x - 2f);

        float tmpSpawnZ;
        tmpSpawnZ = Random.Range(trackBound.min.z + (blockLength/2), trackBound.max.z - (blockLength/2));

        Vector3 spawnVector = new Vector3(tmpSpawnX, trackBound.min.y + 1.5f, tmpSpawnZ);

        _powerUp = Instantiate (powerUp, spawnVector, Quaternion.identity);
        _powerUp.transform.parent = gameObject.transform;

    }

    void SpawnObstacle(float spawnX, float trackPosX, float randomZ)
    {
        spawnBlockPos = new Vector3(trackPosX + spawnX, trackBound.max.y, randomZ);// trackBound.max.z - (blockLength / 2)); // First block position horizontal

        float stringLength = Random.Range(1,5);
            float columnLength = Random.Range(1, 7);

            for (int i = 0; i < stringLength; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    _obstacleUpPos = Instantiate(obj1, spawnBlockPos, Quaternion.identity);
                    _obstacleUpPos.transform.parent = gameObject.transform;
                    spawnBlockPos = new Vector3(trackPosX + spawnX, spawnBlockPos.y + blockLength, spawnBlockPos.z);
                }
                spawnBlockPos = new Vector3(trackPosX + spawnX, spawnPosVertical, spawnBlockPos.z - blockLength - .05f);
            }
    }
   
}

//                spawnFirstHorizontal = new Vector3(trackBound.min.x + 3f, trackBound.max.y, spawnFirstHorizontal.z - blockLength - .05f);
//            spawnFirstVertical = new Vector3(trackBound.min.x + 3f, spawnFirstVertical.y + (blockLength + .07f), trackBound.max.z - (blockLength / 2));

