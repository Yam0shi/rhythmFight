using UnityEngine;

public class BossScript : MonoBehaviour
{
    [SerializeField] private Transform[] ennemySpawner;
    [SerializeField] private GameObject ennemyPrefab;
    [SerializeField] private float bulletSpeed;


    public float bpm;
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
}
