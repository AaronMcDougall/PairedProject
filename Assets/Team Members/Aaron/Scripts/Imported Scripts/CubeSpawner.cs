using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cube;

    private List<GameObject> grid = new List<GameObject>();

    public int gridSize;

    public float cubeHeight;
    public float perlinAdjust;
    public float scale;


    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
        new List<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GenerateGrid()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                cubeHeight = Mathf.PerlinNoise(x * perlinAdjust, y * perlinAdjust) * scale;
                GameObject copy = Instantiate(cube, new Vector3(x, cubeHeight, y), Quaternion.Euler(0, 0, 0));
                grid.Add(copy);
            }
        }
    }

    public void ClearGrid()
    {
        foreach (GameObject cube in grid)
        {
            GameObject.DestroyImmediate(cube, true);
        }

        grid.Clear();
    }
}