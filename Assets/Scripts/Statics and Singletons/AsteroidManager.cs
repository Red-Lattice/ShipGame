using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public static AsteroidManager Instance;
    public static bool asteroidsSpawned;
    public static uint NumberOfAsteroidsToSpawn;
    public SO_Asteroids asteroidSO;
    public Animator asteroidAnimator;
    public List<GameObject> evilAsteroids;

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
            float randomScale = Random.Range(0.5f,2f);
            Instantiate(asteroidSO.Asteroids[Random.Range(0,2)], randomPos, Quaternion.identity)
                .transform.localScale *= randomScale;
        }
        for (int i = 1; i <= 5; i++) {
            Vector3 randomPos = new Vector3(
                    Random.Range(-1f,1f),Random.Range(-1f,1f),Random.Range(-1f,1f))
                .normalized 
                * Random.Range(50f,300f);
            float randomScale = Random.Range(0.5f,2f);
            GameObject evilAsteroid = Instantiate(asteroidSO.SpecialAsteroids[0], randomPos, Quaternion.identity);
            evilAsteroids.Add(evilAsteroid);
            evilAsteroid.transform.localScale *= randomScale;
        }
    }
}