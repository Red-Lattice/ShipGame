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
        Initialize();
    }

    void Initialize() {
        for (int i = 1; i <= 50; i++) {
            Vector3 randomPos = new Vector3(
                    Random.Range(-1f,1f),Random.Range(-1f,1f),Random.Range(-1f,1f))
                .normalized 
                * Random.Range(50f,300f);
            Instantiate(asteroidSO.Asteroids[0], randomPos, Quaternion.identity);
        }
    }
}
