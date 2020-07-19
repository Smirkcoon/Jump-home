using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public int PlatformCount;
    public float levelWidth;
    public float minY;
    public float maxY;
    private Vector2 lastPlatform;
    public Transform Player;
    public GameObject whirlwind;
    private List<GameObject> Platforms = new List<GameObject>();
    public GameObject[] platformPrefabs;
    private Vector2 spawnPosition;

    public GameObject ResetAllPosition;


    private void Start()
    {
        SpawnPlatforms();
        SpawnWhirlWind();       
    }
    private void Update()
    {
        if ((lastPlatform.y - 15) < Player.position.y)
        {           
            SpawnPlatforms();
            ResetAllPosition.GetComponent<ResetPosition>().ResetAllPosition(Mathf.RoundToInt(lastPlatform.y));
            spawnPosition.y -= Mathf.RoundToInt(lastPlatform.y);
            lastPlatform.y -= Mathf.RoundToInt(lastPlatform.y);
            SpawnWhirlWind();
        }
    }
    private void SpawnPlatforms()
    {

        Platforms.Clear();               
        for (int i = 0; i < PlatformCount; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            int PlatformRandomIndex = Random.Range(0, platformPrefabs.Length);
            GameObject platformPrefabClone = Instantiate(platformPrefabs[PlatformRandomIndex], spawnPosition, Quaternion.identity);
            Platforms.Add(platformPrefabClone);

            if (i == (PlatformCount - 1))
            {
                lastPlatform = new Vector2(spawnPosition.x, spawnPosition.y);
            }
        }       
    }
    private void SpawnWhirlWind()
    {
        int RandomCountWhirlWind = Random.Range(1, 4);
        for (int i = 0; i > RandomCountWhirlWind; i++)
        {
            int RandomPlatformNumber = Random.Range(0, PlatformCount);
            GameObject whirlwindClone = Instantiate(whirlwind, new Vector2(Platforms[RandomPlatformNumber].transform.position.x, Platforms[RandomPlatformNumber].transform.position.y + 0.8f), Quaternion.identity);
        }
    }
}
