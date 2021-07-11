using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinate
{
    public Vector3 coordinate {get; set;}
    public bool isAvailable{get; set;}

    public Coordinate(float x, float y, float z){
        this.coordinate = new Vector3(x, y, z);
        this.isAvailable = true;
    }
}
