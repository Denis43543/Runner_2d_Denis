using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform[] spawnPoints;

    private void Start()
    {
        int spawnCount = spawnPoints.Length;
        for (int i = 0; i < spawnCount; i++)
        {
            Transform spawnPoint = spawnPoints[i];
            Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);
        }
    }
}
