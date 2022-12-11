using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SpaceObject", menuName = "SpaceObject")]
public class SpawnManagerScriptableObject : ScriptableObject
{
    public string spaceObjectName;

    public Sprite spaceObjectSprite;

    public int damage;
    public int health;
    public int score;
}
