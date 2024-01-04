using UnityEngine;
using UnityEngine.AI;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    public int numberOfObjects = 10;
    public float spawnRadius = 10f;

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        int spawnedObjects = 0;

        while (spawnedObjects < numberOfObjects)
        {
            Vector3 randomPosition = GetRandomNavMeshPoint();

            if (randomPosition != Vector3.zero)
            {
                // Randomly select a prefab from the array
                GameObject selectedPrefab = objectPrefabs[Random.Range(0, objectPrefabs.Length)];

                Instantiate(selectedPrefab, randomPosition, Quaternion.identity);
                spawnedObjects++;
            }
        }
    }

    Vector3 GetRandomNavMeshPoint()
    {
        Vector3 randomPosition = Random.insideUnitSphere * spawnRadius + transform.position;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomPosition, out hit, spawnRadius, NavMesh.AllAreas))
        {
            return hit.position;
        }

        return Vector3.zero;
    }
}
