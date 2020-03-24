using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "levelData ")]
public class BlockData : ScriptableObject
{
    public Vector3[] boxBloksCoordinates;               //(x,y,z) of all box blocks
    public Vector3[] circleBlocksCoordinates;           //(x,y,z) of all circle blocks
    public Vector3[] triangleBlocksCoordinates;         //(x,y,z) of all triangle blocks
    public int immuneCount;                             //count of immune blocks   
    public int invisibleCount;                          //count of invisible blocks
}
