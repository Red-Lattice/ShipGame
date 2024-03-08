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
    public List<GameObject> asteroids;
    public int asteroidCount;

    void Awake() {
        if (Instance != null) {
            Destroy(this);
        }
        Instance = this;
        Initialize();
    }

    void Initialize() {
        for (int i = 1; i <= 50; i++) {
            asteroidCount++;
            Vector3 randomPos = new Vector3(
                    Random.Range(-1f,1f),Random.Range(-1f,1f),Random.Range(-1f,1f))
                .normalized 
                * Random.Range(50f,300f);
            float randomScale = Random.Range(0.5f,2f);
            GameObject asteroid = Instantiate(asteroidSO.Asteroids[Random.Range(0,2)], randomPos, Quaternion.identity);
            asteroids.Add(asteroid);
            asteroid.transform.localScale *= randomScale;
        }
    }

    public void FillInGaps() {
        while (asteroidCount < 50) {
            asteroidCount++;
            Vector3 randomPos = new Vector3(
                    Random.Range(-1f,1f),Random.Range(-1f,1f),Random.Range(-1f,1f))
                .normalized 
                * Random.Range(50f,300f);
            float randomScale = Random.Range(0.5f,2f);
            GameObject asteroid = Instantiate(asteroidSO.Asteroids[Random.Range(0,2)], randomPos, Quaternion.identity);
            asteroids.Add(asteroid);
            asteroid.transform.localScale *= randomScale;
        }
    }

    public void AsteroidDestroyed() {
        asteroidCount--;
    }
}
