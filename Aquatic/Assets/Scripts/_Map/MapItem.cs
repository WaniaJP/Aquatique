using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
[CreateAssetMenu(fileName = "Map", menuName = "Cartographer/MapItem", order = 1)]
public class MapItem : ScriptableObject
{

    [ScenePath] public string path;
    public Sprite visual;
}
