using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTrackGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> trackPrefs;
    private List<GameObject> activeTrack = new List<GameObject>();

    [SerializeField] float _trackLength = 60;
    [SerializeField] Transform _playerPos;

    [SerializeField] GameObject _trackMoving;
    [SerializeField] GameObject _spawnTrackPos;

    private int startTrack = 3;
    private float spawnPos = 0;

    public float SpawnPos
    {
        get => spawnPos;
    }

    private void Start()
    {
        for (int i = 0; i < trackPrefs.Count; i++)
        {
            SpawnTrack(i);
        }
    }
    private void Update()
    {
        if (_playerPos.position.x - 50 > spawnPos - (startTrack * _trackLength))
        {
            //SpawnTrack(Random.Range(0, trackPrefs.Count));
            AddMovingTrack();
            DeleteTrack();
        }
        
    }
    private void SpawnTrack(int trackIndex)
    {
        GameObject nextTrack = Instantiate(trackPrefs[trackIndex], transform.right * spawnPos, Quaternion.identity);
        activeTrack.Add(nextTrack);
        spawnPos += _trackLength;
    }
    private void DeleteTrack()
    {
        Destroy(activeTrack[0]);
        trackPrefs.RemoveAt(0);
        activeTrack.RemoveAt(0);
    }
    void AddMovingTrack()
    {
       GameObject newTrack = Instantiate(_trackMoving, _spawnTrackPos.transform.position, Quaternion.identity);
        trackPrefs.Add(newTrack);
        activeTrack.Add(newTrack);
        spawnPos += _trackLength;
    }
}
