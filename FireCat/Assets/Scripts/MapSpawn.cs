﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawn : MonoBehaviour
{
    [Header("Building")]
    public GameObject BuildingPrefab;
    public GameObject[] RoadSections;

    [Header("Grid Dimensions")]
    public int X;
    public int Z;
    public float spacing;


    private List<List<Building>> _buildings = new List<List<Building>>();
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < X; i++)
        {
            _buildings.Add(new List<Building>());
            for (int j = 0; j < Z; j++)
            {
                var building = Instantiate(BuildingPrefab, transform);
                building.transform.localPosition = new Vector3(i * spacing, 0, j * spacing);
                Building b = building.GetComponent<Building>();
                if (b == null)
                {
                    print("Tried to instatiate a buidling without a buidling script, HELP!");
                }
                _buildings[i].Add(b);

            }
        }
        if (X > 1 && Z > 1)
        {
            for (int i = 0; i < X ; i++)
            {
                for (int j = 0; j < Z; j++)
                {
                    int one = i + 1;
                    int two = j + 1;
                    if(one < _buildings.Count)
                    {
                        _buildings[i][j].AddNeighbor(_buildings[one][j]);
                    }
                    if (two < _buildings[i].Count)
                    {
                        _buildings[i][j].AddNeighbor(_buildings[i][two]);
                    }

                }
            }
        }
        int x = Random.Range(0,X-1);
        int z = Random.Range(0, Z-1);
        _buildings[x][z].AddFire();
        GenerateRoadLayout();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GenerateRoadLayout()
    {
        for(int x = 0; x < X; x++)
        {
            for(int z = 0; z < Z; z++)
            {
                if(x < X-1)
                {
                    var building = Instantiate(RoadSections[0], transform);
                    building.transform.localPosition = new Vector3(x * spacing + (spacing / 2), -2, z * spacing);
                }
                if(z < Z-1)
                {
                    var building2 = Instantiate(RoadSections[0], transform);
                    building2.transform.localPosition = new Vector3(x * spacing, -2, z * spacing + (spacing / 2));
                    building2.transform.localRotation = Quaternion.Euler(0,90,0);
                }
                if(z < Z-1 && x < X-1)
                {
                    var building3 = Instantiate(RoadSections[1], transform);
                    building3.transform.localPosition = new Vector3(x * spacing + (spacing / 2), -2, z * spacing + (spacing / 2));
                }
            }
        }
    }
}
