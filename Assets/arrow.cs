using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrowPrefab;

    void Start()
    {
        SpawnArrow();
    }

    public void SpawnArrow()
    {
        Instantiate(arrowPrefab, transform.position, Quaternion.identity);
    }
}
