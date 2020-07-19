using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public Transform[] AllNeedToResetPosition;
    public void ResetAllPosition(int YlastPlatform)
    {
        foreach (Transform go in AllNeedToResetPosition)
        {
            go.position = new Vector3(go.position.x, go.position.y - YlastPlatform, go.position.z);
        }
        GameObject[] AllPlatforms = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject go in AllPlatforms) 
        {
            Debug.Log("Platform");
            go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y - YlastPlatform, go.transform.position.z);
        }
    }
}
