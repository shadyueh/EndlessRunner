using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 31.5f;

    public int numberOfFiles = 5;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfFiles; i++)
        {
            if (i==0)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(0, tilePrefabs.Length));
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTile(int tileIndex)
    {
        Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        zSpawn += tileLength;
    }

}
