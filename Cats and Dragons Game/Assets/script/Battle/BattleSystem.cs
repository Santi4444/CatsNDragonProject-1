using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleSystem : MonoBehaviour
{

    public BattleUnit enemyUnit;
    public BattleHud enemyHud;

	public int EnemyHealth;

    public EnemyData enemyData;

    public int playerHealth;

    public MovementController playerMovement;


    public GameObject choiceScreen;
    public GameObject attackScreen;

    public PlayerData playerStats;

	public GameObject OverworldGameObject;
	public TextMeshProUGUI FriendPointsNum;


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

        OverworldGameObject.SetActive(false);

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
			enemyHud.PlayEnemyCorrectDialogue(enemyUnit.Enemy, "Player says sarcastic line");
			Debug.Log("He is Saracastic");

            EnemyHealth -= 5;
            enemyHud.UpdateEnemyHealth(EnemyHealth);
            //CheckEnemyHpIsZero();
        }
        else
        {
			enemyHud.PlayEnemyIncorrectDialogue(enemyUnit.Enemy, "Player says sarcastic line");
			playerHealth -= 1;
            enemyHud.UpdatePlayerHealth(playerHealth);
            //CheckPlayerHpIsZero();
        }

    }

    public void ShyAttack()
    {
        if (enemyData.enemyType == EnemyData.EnemyType.Shy)
        {
			enemyHud.PlayEnemyCorrectDialogue(enemyUnit.Enemy, "Player says shy line");
			Debug.Log("He is Shy");

            EnemyHealth -= 5;
            enemyHud.UpdateEnemyHealth(EnemyHealth);
            //CheckEnemyHpIsZero();
        }
        else
        {
			enemyHud.PlayEnemyIncorrectDialogue(enemyUnit.Enemy, "Player says a shy line");
			playerHealth -= 1;
            enemyHud.UpdatePlayerHealth(playerHealth);
            //CheckPlayerHpIsZero();
        }

    }

    public void SeriousAttack()
    {
        if (enemyData.enemyType == EnemyData.EnemyType.Serious)
        {
			enemyHud.PlayEnemyCorrectDialogue(enemyUnit.Enemy, "Player says serious line");
			Debug.Log("He is Serious");

            EnemyHealth -= 5;
            enemyHud.UpdateEnemyHealth(EnemyHealth);
            //CheckEnemyHpIsZero();
        }
        else
        {
			enemyHud.PlayEnemyIncorrectDialogue(enemyUnit.Enemy, "Player says a serious line");
			playerHealth -= 1;
            enemyHud.UpdatePlayerHealth(playerHealth);
            //CheckPlayerHpIsZero();
        }

    }

    public void ConfidantAttack()
    {
        if (enemyData.enemyType == EnemyData.EnemyType.Confidant)
        {
			enemyHud.PlayEnemyCorrectDialogue(enemyUnit.Enemy, "Player says confidant line");
			Debug.Log("He is Confidant");

            EnemyHealth -= 5;
            enemyHud.UpdateEnemyHealth(EnemyHealth);
           // CheckEnemyHpIsZero();
        }
        else
        {
			enemyHud.PlayEnemyIncorrectDialogue(enemyUnit.Enemy, "Player says a confidant line");
			playerHealth -= 1;
            enemyHud.UpdatePlayerHealth(playerHealth);
            //CheckPlayerHpIsZero();
        }

    }

	public void ApologyAttack()
	{
		enemyHud.FinalBossInteraction();
	}

	public void CheckEnemyHpIsZero()
    {
        if (EnemyHealth <= 0)
        {
            choiceScreen.SetActive(true);
            attackScreen.SetActive(false);
            playerMovement.LeaveRandomEncounter();
            playerStats.playerFriendPoints += enemyData.enemyPoints;

            string playerPoints = playerStats.playerFriendPoints.ToString();
            FriendPointsNum.text = playerPoints;


		}
    }
    public void CheckPlayerHpIsZero()
    {
        if (playerHealth <= 0)
        {
            choiceScreen.SetActive(true);
            attackScreen.SetActive(false);
            playerMovement.LeaveRandomEncounter();
			playerMovement.enabled = true;
		}
    }

    public void OpenAttackScreen()
    {
        choiceScreen.SetActive(false);
        attackScreen.SetActive(true);
    }

	public void RunAwayChoice()
	{
		enemyHud.RunAwayFunction(playerMovement);
	}

}
