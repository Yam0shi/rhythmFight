using UnityEngine;

public class BossScript : MonoBehaviour
{
    [SerializeField] private Transform[] ennemySpawner;
    [SerializeField] private GameObject ennemyPrefab;
    
    [SerializeField] private float bpm;
    [SerializeField] private AudioSource soundSource;
    private float beatInterval;
    private float nextBeatTime;


    void Start()
    {
        soundSource = GetComponent<AudioSource>();
        nextBeatTime = Time.time + beatInterval;
    }

    private void Update()
    {
        if (soundSource.isPlaying == true)
        {
            BeatMap();
        }
        PartSelection();
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

    void PartSelection()
    {
        if (soundSource.time < 27f)
        {
            bpm = 80;
            beatInterval = 60f / bpm;
        }
        else if (soundSource.time >= 27f && soundSource.time < 34f)
        {
            bpm = 160;
            beatInterval = 60f / bpm;
        }
        else if (soundSource.time >= 34f)
        {
            bpm = 200;
            beatInterval = 60f / bpm;
        }
    }
}