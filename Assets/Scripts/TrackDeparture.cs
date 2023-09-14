using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackDeparture : MonoBehaviour
{
    GameObject trackGenerator;
    MyTrackGenerator _spawnPos;
    float tmpSpawnPos;
    private void Start()
    {
        trackGenerator = GameObject.Find("TrackGeneration");
        _spawnPos = trackGenerator.GetComponent<MyTrackGenerator>();
        tmpSpawnPos = _spawnPos.SpawnPos;
    }

    private void Update()
    {
        if (transform.position.x < tmpSpawnPos)
        {
            float spawnTrackPoint = tmpSpawnPos - 60f;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(spawnTrackPoint, 0f), 3f);
        }
    }
}
