using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "All Levels")]
public class LevelData : ScriptableObject
{
    public BlockData[] level;       //array of all levels
    public int chosenLevel = 0;     //index of chosen level

}
