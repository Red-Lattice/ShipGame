using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidSpawnerSingleton : MonoBehaviour
{
    public static AsteroidSpawnerSingleton Instance;
    public static bool asteroidsSpawned;
    public static uint NumberOfAsteroidsToSpawn;
    public SO_Asteroids asteroidSO;

    void Awake() {
        if (Instance != null) {
            Destroy(this);
        }
        Instance = this;
    }

    void Initialize() {
        for (int i = 1; i <= 500; i++) {
            Instantiate(asteroidSO.Asteroids[0]);
        }
    }
}
