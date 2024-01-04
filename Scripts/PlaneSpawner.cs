using UnityEngine;
using System.Collections.Generic;

public class PlaneSpawner : MonoBehaviour
{
    public List<GameObject> objectsToSpawn; // Use a list of GameObjects
    public int numberOfObjects = 10;
    public Vector2 spawnAreaSize = new Vector2(10f, 10f);
    public Vector3 fixedRotation = new Vector3(0f, 90f, 0f); // Adjust as needed

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomPosition = GetRandomPositionOnPlane();
            Quaternion fixedQuaternion = Quaternion.Euler(fixedRotation);

            // Use Random.Range to choose a random index from the list
            int randomIndex = Random.Range(0, objectsToSpawn.Count);
            GameObject selectedObject = objectsToSpawn[randomIndex];

            Instantiate(selectedObject, randomPosition, fixedQuaternion);
        }
    }

    Vector3 GetRandomPositionOnPlane()
    {
        float randomX = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
        float randomZ = Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2);

        return new Vector3(randomX, 0f, randomZ) + transform.position;
    }
}
