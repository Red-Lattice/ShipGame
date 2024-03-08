using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManagerSingleton : MonoBehaviour
{
    public static EnemyManagerSingleton Instance;
    public SO_EnemyList enemies;
    public static List<EnemyAI> enemyList;
    public static Transform target;

    void Awake() {
        if (Instance != null) {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    public static void Initialize(uint neededEnemies) {
        enemyList = new List<EnemyAI>();
        for (int i = 1; i <= neededEnemies; ++i) {
            GameObject ship = Instantiate(Instance.enemies.Enemies[0]);
            ship.transform.position = EnemyAI.RandomVector() * Random.Range(150f,250f);
            enemyList.Add(ship.GetComponent<EnemyAI>());
        }
    }
}
