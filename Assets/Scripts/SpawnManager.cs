using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject enemyPrefab;

    private PlayerController pc;
    private float highestY = 0;

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnPlatform", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPlatform()
    {
        highestY += 3;
        int padding = 2;
        Vector3 pos = new Vector3(Random.Range(pc.leftBound + padding, pc.rightBound - padding), highestY, 0);
        GameObject platform = Instantiate(platformPrefab, pos, platformPrefab.transform.rotation);

        if (Random.Range(0.0f, 1.0f) < 0.2)
        {
            SpawnEnemy(platform);
        }
    }

    private void SpawnEnemy(GameObject platform)
    {
        float width = platform.GetComponent<MeshRenderer>().bounds.size.x;
        float height = platform.GetComponent<MeshRenderer>().bounds.size.y;
        float x = Random.Range(platform.transform.position.x - width / 2, platform.transform.position.x + width / 2);

        // Why is this the correct y coordinate? Why +0.5??
        float y = highestY + height + 0.5f;
        Vector3 pos = new Vector3(x, y, 0);

        Instantiate(enemyPrefab, pos, enemyPrefab.transform.rotation);
    }
}
