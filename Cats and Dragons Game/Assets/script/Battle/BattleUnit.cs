using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
	public EnemyData enemyBase;

	public Enemy Enemy { get; set; }
	public void Setup(EnemyData wildEnemy)
	{
		enemyBase = wildEnemy;
		Enemy = new Enemy(enemyBase);

		
		GetComponent<SpriteRenderer>().sprite = Enemy.enemy.enemySprite;
	}

}
