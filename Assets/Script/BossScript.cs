using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    [SerializeField] private Transform[] ennemySpawner;
    [SerializeField] private List<Transform> AllBullets = new();
    [SerializeField] private GameObject ennemyPrefab;
    [SerializeField] private float bulletSpeed;


    public float bpm = 120f; // Remplacez par le BPM réel de votre musique
    private float beatInterval;
    private float nextBeatTime;


    void Start()
    {        
        beatInterval = 60f / bpm;

        nextBeatTime = Time.time + beatInterval;
    }

    private void Update()
    {
        BeatMap();
    }

    void BeatMap()
    {
        if (Time.time >= nextBeatTime)
        {
            int indexRandom = Random.Range(0, ennemySpawner.Length);
            Instantiate(ennemyPrefab, ennemySpawner[indexRandom].position, Quaternion.identity, ennemySpawner[indexRandom]);

            nextBeatTime += beatInterval;
        }
    }

    private void FixedUpdate()
    {
            EnnemyBulletMoving();
    }

    void EnnemyBulletMoving()
    {
        for (int i = 0; i < AllBullets.Count; i++)
        {
            if (AllBullets[i] != null)
            {
                AllBullets[i].transform.position += Vector3.back * bulletSpeed * Time.deltaTime;
            }
            else
            {
                AllBullets.RemoveAt(i);
            }
        }
    }
}
