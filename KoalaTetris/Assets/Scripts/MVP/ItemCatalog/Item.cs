using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Item : MonoBehaviour, IIdentify
{
    [SerializeField] private string id;
    
    public string GetID() => id;
}
