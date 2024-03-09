using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overwatch : MonoBehaviour
{
    public static Overwatch Instance;
    public uint neededAsteroids {get; private set;}
    public uint destroyedAsteroids {get; private set;}
    public int totalDestroyed {get; private set;}
    public int totalWaves {get; private set;}

    public void Awake() {
        if (Instance != null) {
            Destroy(this); return;
        }
        Instance = this;
        totalWaves = -1;
    }
    public void AsteroidDestroyed() {
        ++destroyedAsteroids;
        ++totalDestroyed;
    }

    public bool GameWonCheck() {
        return destroyedAsteroids >= neededAsteroids;
    }

    private void GameStart() {
        StartNewWave();
    }

    public void StartNewWave() {
        totalWaves += 1;
        neededAsteroids += 2;
        destroyedAsteroids = 0;
        EnemyManagerSingleton.Initialize(neededAsteroids);
        AsteroidManager.Instance.FillInGaps();
    }
}
