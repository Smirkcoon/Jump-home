using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;

    public int numberOfPlatform = 20;
    public float levelWidth = 3f;
    public float minY = .2f;
    public float maxY = 1.5f;
    private Vector2 lastPlatform;
    public Transform Player;
    private Vector2 spawnPosition = new Vector2();
    
    void Start()
    {       
        Spawn();
    }
    private void Update()
    {
        if ((lastPlatform.y -15) < Player.position.y ) 
        {
            Spawn();           
        }       
    }
    void Spawn()
    {       
        for (int i = 0; i < numberOfPlatform; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            GameObject clone = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);           
            if (i == (numberOfPlatform -1)) 
            {
                lastPlatform = new Vector2(spawnPosition.x, spawnPosition.y);               
            }
        }
    }
}
