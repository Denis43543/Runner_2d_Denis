using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platform;
    public GameObject obstacle;
    public int platformAmount;
    public int obstacleAmount;
    List<GameObject> platforms;
    List<GameObject> obstacles;

    // Start is called before the first frame update
    void Start()
    {
        platforms = new List<GameObject>();
        for (int i = 0; i < platformAmount; i++)
        {
            GameObject obj = Instantiate(platform);
            obj.SetActive(false);
            platforms.Add(obj);
        }

        obstacles = new List<GameObject>();
        for (int i = 0; i < obstacleAmount; i++)
        {
            GameObject obj = Instantiate(obstacle);
            obj.SetActive(false);
            obstacles.Add(obj);
        }
    }

    public GameObject GetPlatform()
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            if (!platforms[i].activeInHierarchy)
            {
                return platforms[i];
            }
        }
        GameObject obj = Instantiate(platform);
        obj.SetActive(false);
        platforms.Add(obj);
        return obj;
    }

    public GameObject GetObstacle()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (!obstacles[i].activeInHierarchy)
            {
                return obstacles[i];
            }
        }
        GameObject obj = Instantiate(obstacle);
        obj.SetActive(false);
        obstacles.Add(obj);
        return obj;
    }
}
