using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleSystem : MonoBehaviour
{

    public BattleUnit enemyUnit;
    public BattleHud enemyHud;

    [SerializeField] private int EnemyHealth;

    public EnemyData enemyData;

    public int playerHealth;

    public MovementController playerMovement;


    public GameObject choiceScreen;
    public GameObject attackScreen;

    public PlayerData playerStats;

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

        //get enemydata
        enemyData = enemy;

        playerHealth = enemyHud.player.playerHealth;
    }

    public void TestAttack()
    {
        EnemyHealth -= 5;
        //enemyUnit.Enemy.enemy.enemyHealth -= 5;
        enemyHud.UpdateEnemyHealth(EnemyHealth);


    }
    public void SarcasticAttack()
    {
        if (enemyData.enemyType == EnemyData.EnemyType.Sarcastic)
        {
            Debug.Log("He is Saracastic");

            EnemyHealth -= 5;
            enemyHud.UpdateEnemyHealth(EnemyHealth);
            CheckEnemyHpIsZero();
        }
        else
        {
            playerHealth -= 1;
            enemyHud.UpdatePlayerHealth(playerHealth);
            CheckPlayerHpIsZero();
        }

    }

    public void ShyAttack()
    {
        if (enemyData.enemyType == EnemyData.EnemyType.Shy)
        {
            Debug.Log("He is Shy");

            EnemyHealth -= 5;
            enemyHud.UpdateEnemyHealth(EnemyHealth);
            CheckEnemyHpIsZero();
        }
        else
        {
            playerHealth -= 1;
            enemyHud.UpdatePlayerHealth(playerHealth);
            CheckPlayerHpIsZero();
        }

    }

    public void SeriousAttack()
    {
        if (enemyData.enemyType == EnemyData.EnemyType.Serious)
        {
            Debug.Log("He is Serious");

            EnemyHealth -= 5;
            enemyHud.UpdateEnemyHealth(EnemyHealth);
            CheckEnemyHpIsZero();
        }
        else
        {
            playerHealth -= 1;
            enemyHud.UpdatePlayerHealth(playerHealth);
            CheckPlayerHpIsZero();
        }

    }

    public void ConfidantAttack()
    {
        if (enemyData.enemyType == EnemyData.EnemyType.Confidant)
        {
            Debug.Log("He is Confidant");

            EnemyHealth -= 5;
            enemyHud.UpdateEnemyHealth(EnemyHealth);
            CheckEnemyHpIsZero();
        }
        else
        {
            playerHealth -= 1;
            enemyHud.UpdatePlayerHealth(playerHealth);
            CheckPlayerHpIsZero();
        }

    }

    public void CheckEnemyHpIsZero()
    {
        if (EnemyHealth <= 0)
        {
            choiceScreen.SetActive(true);
            attackScreen.SetActive(false);
            playerMovement.LeaveRandomEncounter();
            playerStats.playerFriendPoints += enemyData.enemyPoints;
        }
    }
    public void CheckPlayerHpIsZero()
    {
        if (playerHealth <= 0)
        {
            choiceScreen.SetActive(true);
            attackScreen.SetActive(false);
            playerMovement.LeaveRandomEncounter();
        }
    }

    public void OpenAttackScreen()
    {
        choiceScreen.SetActive(false);
        attackScreen.SetActive(true);
    }
}
