using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "All Levels")]
public class LevelData : ScriptableObject
{
    public BlockData[] level;
    public int chosenLevel = 0;

}
