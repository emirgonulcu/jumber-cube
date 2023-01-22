using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platform;
    private Transform tr;

    public int platform_count;

    public float platform_width;

    public float minY, maxY;

    void Start()
    {
        tr = platform.GetComponent<Transform>();
        Vector3 spawn_location = new Vector3();
        Vector2 newScale = new Vector2();

        for (int i = 0; i < platform_count; i++)
        {
            newScale.x = Random.Range(0.9f, 1.1f);
            newScale.y = Random.Range(0.9f, 1.1f);
            tr.localScale = newScale;

            spawn_location.y += Random.Range(minY, maxY);
            spawn_location.x = Random.Range(-platform_width, platform_width);

            Instantiate(platform, spawn_location, Quaternion.identity);
        }
    }

    private void Update()
    {
        
    }
}
