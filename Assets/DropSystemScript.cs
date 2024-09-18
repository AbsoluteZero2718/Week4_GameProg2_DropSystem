using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DropSystemScript
{
    public string ItemName;
    public GameObject ItemPrefab;
    [Range(0, 100)]
    public float DropChance;
    public int min, max;
    public float duration;



}
