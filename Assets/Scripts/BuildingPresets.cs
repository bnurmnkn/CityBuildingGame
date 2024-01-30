using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO.Enumeration;

[CreateAssetMenu(fileName = "BuildingPresets", menuName = "New Building Preset")]
public class BuildingPresets : ScriptableObject
{
    public int cos;
    public int cosPerTurn;
    public GameObject prefab;
    public int population;
    public int jobs;
    public int food;
}

