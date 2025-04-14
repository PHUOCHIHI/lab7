using System.Collections;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab;
    public Transform spawnPoint;

    public float randomXRange = 5f;

    void Start()
    {
        StartCoroutine(SpawnBubble());
    }

    IEnumerator SpawnBubble()
    {
        while (true)
        {
            float randomX = Random.Range(-randomXRange, randomXRange);
            Vector3 spawnPos = new Vector3(spawnPoint.position.x + randomX, spawnPoint.position.y, spawnPoint.position.z);

            Instantiate(bubblePrefab, spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(2f);
        }
    }
}
