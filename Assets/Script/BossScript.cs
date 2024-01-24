using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    [SerializeField] private Transform[] ennemySpawner;
    [SerializeField] private List<Transform> AllBullets = new();
    [SerializeField] private GameObject ennemyPrefab;
    [SerializeField] private float bulletSpeed;

    void Start()
    {
        StartCoroutine(EnnemySpawner());
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

    private IEnumerator EnnemySpawner()
    {
        int indexRandom = Random.Range(0, ennemySpawner.Length);
        GameObject ennemyBullet = Instantiate(ennemyPrefab, ennemySpawner[indexRandom].position, Quaternion.identity, ennemySpawner[indexRandom]);
        AllBullets.Add(ennemyBullet.transform);
        yield return new WaitForSeconds(1);
        StartCoroutine(EnnemySpawner());
    }
}
