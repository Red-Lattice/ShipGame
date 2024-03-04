using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds prefabs of asteroids for the asteroid spawner
/// </summary>
[CreateAssetMenu(fileName = "SO_Asteroid", menuName = "Scriptable Objects/Asteroid Spawner")]
public class SO_Asteroids : ScriptableObject
{
    public List<GameObject> Asteroids;
    public List<GameObject> SpecialAsteroids;
}
