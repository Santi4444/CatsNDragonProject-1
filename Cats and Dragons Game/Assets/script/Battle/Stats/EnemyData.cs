using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/CreateEnemy")]
public class EnemyData : ScriptableObject
{
	public string name;
	public int enemyHealth;
	public Sprite enemySprite;
	public EnemyType enemyType;

	public int enemyPoints;

	public string[] dialogue;
	public enum EnemyType 
	{ 
		Sarcastic,
		Shy,
		Serious,
		Confidant,
		Boss
	}

	public string GetName 
	{
		get { return name; }
	}

	public string[] enemyCorrectDialogue;
	public string[] enemyWrongDialogue;
	public string[] enemyVictoryDialogue;
	public string[] enemyLossDialogue;
}
