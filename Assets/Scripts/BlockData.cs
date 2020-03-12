using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "levelData ")]
public class BlockData : ScriptableObject
{
    public Vector3[] boxBloksCoordinates;
    public Vector3[] circleBlocksCoordinates;
    public Vector3[] triangleBlocksCoordinates;
}
