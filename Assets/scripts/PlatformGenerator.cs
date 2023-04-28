using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platform;
    public GameObject obstacle;
    public Transform GenerationPoint;
    public float distanceBetween;
    float platformWidth;
    public float distanceMin;
    public float distanceMax;
    public float obstacleDistanceMin;
    public float obstacleDistanceMax;

    public PlatformManager platformM;

    // Start is called before the first frame update
    void Start()
    {
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < GenerationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceMin, distanceMax);
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, platform.transform.position.y, platform.transform.position.z);

            GameObject newPlatform = platformM.GetPlatform();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            float obstacleDistance = Random.Range(obstacleDistanceMin, obstacleDistanceMax);
            Vector3 obstaclePosition = new Vector3(transform.position.x + obstacleDistance, newPlatform.transform.position.y + 0.5f, 0f);
            GameObject newObstacle = platformM.GetObstacle();
            newObstacle.transform.position = obstaclePosition;
            newObstacle.transform.rotation = transform.rotation;
            newObstacle.SetActive(true);
            //ObstacleDestroyer obstacleDestroyer = newObstacle.GetComponent<ObstacleDestroyer>();
            //obstacleDestroyer.destroyPoint = GenerationPoint.gameObject;
        }
    }
}
