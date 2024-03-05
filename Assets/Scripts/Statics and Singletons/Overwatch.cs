using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Overwatch
{
    public static uint neededAsteroids {get; private set;}
    public static uint destroyedAsteroids {get; private set;}

    public static void AsteroidDestroyed() {
        ++destroyedAsteroids;
    }

    public static bool GameWonCheck() {
        return destroyedAsteroids >= neededAsteroids;
    }

    public static void GameStart() {
        neededAsteroids = 2;
    }

    public static void StartNewWave() {
        neededAsteroids += 2;
        destroyedAsteroids = 0;
    }
}
