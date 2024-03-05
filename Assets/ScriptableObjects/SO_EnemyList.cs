using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_EnemyList", menuName = "Scriptable Objects/Enemy List")]
public class SO_EnemyList : ScriptableObject
{
    public List<GameObject> Enemies;
}
