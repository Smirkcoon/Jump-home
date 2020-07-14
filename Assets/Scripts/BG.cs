using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    public float BGSize;
    

    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone = 10;
    private int UpIndex;
    private int DownIndex;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }
        DownIndex = 0; //left
        UpIndex = layers.Length - 1; //right
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraTransform.position.y < (layers[DownIndex].transform.position.y + viewZone))
        {
            ScrollDown();
            
        }
        if (cameraTransform.position.y > (layers[UpIndex].transform.position.y - viewZone))
        {
            ScrollUp();
            
        }
    }
    private void ScrollDown()
    {
        int lastUp = UpIndex;
        layers[UpIndex].position = Vector3.up * (layers[DownIndex].position.y - BGSize);
        DownIndex = UpIndex;
        UpIndex--;
        if (UpIndex < 0)
        {
            UpIndex = layers.Length - 1;
        }
    }
    private void ScrollUp()
    {
        int lastDown = DownIndex;
        layers[DownIndex].position = Vector3.up * (layers[UpIndex].position.y + BGSize);
        UpIndex = DownIndex;
        DownIndex++;
        if (DownIndex == layers.Length)
        {
            DownIndex = 0;
        }
    }
}
