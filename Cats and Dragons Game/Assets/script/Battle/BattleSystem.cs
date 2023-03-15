using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleSystem : MonoBehaviour
{

    public BattleUnit enemyUnit;
    public BattleHud enemyHud;

    [SerializeField] private int EnemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        //SetupBattle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupBattle(EnemyData enemy)
	{
        enemyUnit.Setup(enemy);
        enemyHud.SetData(enemyUnit.Enemy);

        EnemyHealth = enemy.enemyHealth;


    }

    public void TestAttack()
    {
        EnemyHealth -= 5;
        //enemyUnit.Enemy.enemy.enemyHealth -= 5;
        enemyHud.UpdateEnemyHealth(EnemyHealth);


    }
}
