using System.Collections;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject[] duckPrefabs;
    public float minSpawnTime = 5f;
    public float maxSpawnTime = 7f;
    void Start()
    {
        StartCoroutine(SpawnDucks());
    }

    IEnumerator SpawnDucks()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);
            
            GameObject duckPrefab = duckPrefabs[Random.Range(0, duckPrefabs.Length)];
            
            Instantiate(duckPrefab, transform.position, transform.rotation);
        }
    }
}
