using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy 
{
	public EnemyData enemy { get; set; }
	int level;

	public int Hp { get; set; }

	public Enemy(EnemyData enemyBase)
	{
		enemy = enemyBase;
		Hp = enemy.enemyHealth;
	}


}
