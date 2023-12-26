using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject enemyPrefab;

    private float highestY = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPlatform", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPlatform()
    {
        highestY += 3;
        Vector3 pos = new Vector3(Random.Range(-10, 10), highestY, 0);
        Instantiate(platformPrefab, pos, platformPrefab.transform.rotation);
    }
}
