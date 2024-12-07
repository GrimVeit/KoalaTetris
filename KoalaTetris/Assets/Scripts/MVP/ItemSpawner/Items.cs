using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Items")]
public class Items : ScriptableObject
{
    public List<Item> ItemsPrefabs = new List<Item>();
}
