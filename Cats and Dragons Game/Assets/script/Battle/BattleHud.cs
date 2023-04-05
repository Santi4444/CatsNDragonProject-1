using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleHud : MonoBehaviour
{
	
	public TextMeshProUGUI enemyNameText;
	public TextMeshProUGUI enemyHp;


	public PlayerData player;
	public TextMeshProUGUI playerHp;

	public TextMeshProUGUI dialogueBox;

	public void SetData(Enemy enemy)
	{
		enemyNameText.text = enemy.enemy.name;
		enemyHp.text = enemy.enemy.enemyHealth.ToString();

		playerHp.text = player.playerHealth.ToString();

		dialogueBox.text = enemy.enemy.dialogue[0];
	}

	public void UpdateEnemyHealth(int enemy)
	{
		enemyHp.text = enemy.ToString();
	}

	public void UpdatePlayerHealth(int player)
	{
		playerHp.text = player.ToString();
	}
}
