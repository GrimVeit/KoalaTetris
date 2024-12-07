using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : Car
{
    public override void Move()
    {
        Debug.Log("Еду на велосипеде");
    }
}
