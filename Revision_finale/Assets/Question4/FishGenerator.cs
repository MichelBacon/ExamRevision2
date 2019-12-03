using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FishGenerator : MonoBehaviour
{

    public int mapWidth = 256;
    public int mapHeight = 256;
    public float noiseScale;
    public int octaves;
    [Range(0, 1)]
    public float persistance;
    public float lacunarity;
    public bool autoUpdate;
    public int seed;
    public Vector2 offset;

    public int maxNumberOfFishes = 100;
    public GameObject fishPrefab;
    private void Start()
    {

    }

    public void GenerateFishes()
    {
        DeleteFishes();

        float[,] noiseMapFish = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                if(noiseMapFish[x,y] > 0.8)
                {
                    Instantiate(fishPrefab, new Vector3(x, y, 0), new Quaternion(0, 0, 0, 0));
                }    
            }
        }
    }

    public void DeleteFishes()
    {
        foreach (Fish fish in FindObjectsOfType<Fish>())
        {
            DestroyImmediate(fish.gameObject);
        }
    }


    private void OnValidate()
    {
        if (mapWidth < 1)
        {
            mapWidth = 1;
        }
        if (lacunarity < 1)
        {
            lacunarity = 1;
        }
        if (octaves < 0)
        {
            octaves = 0;
        }

    }


}

