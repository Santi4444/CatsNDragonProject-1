using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleWildEnemies : MonoBehaviour
{
    //[SerializeField] private List<Enemy> enemyType;

    public EnemyData[] tester;

    public int test1;
    public EnemyData GetRandomEnemy()
    {

        return tester[Random.Range(0, tester.Length)];

        //return enemyType[Random.Range(0, enemyType.Count)];

    }
}
