using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossFightTrigger : MonoBehaviour
{
	[SerializeField] private Collider2D collider;
	[SerializeField] private GameObject BossFight;
	[SerializeField] private Button ApologyButton;
	[SerializeField] private Vector3 moveLocation;
	public EnemyData BossData;


	public BattleSystem enemyBattleSystem;
	// Start is called before the first frame update
	void Start()
	{
		collider = this.gameObject.GetComponent<Collider2D>();
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{

		

		StartCoroutine(MovePlayerBossFight(collision));
		//collision.GetComponent<MovementController>().RoadBlockMover(moveLocation);
	}

	IEnumerator MovePlayerBossFight(Collider2D collision)
	{
		//add pre cutscene


		//Set Data for Boss
		//need data like dialogue and name but not type
		//bossFight.SetupBattle(BossData);
		enemyBattleSystem.SetupBattle(BossData);
		//activate bossfight screen
		BossFight.SetActive(true);

		if(collision.gameObject.GetComponent<PlayerData>().SpecialItem == true)
		{
			ApologyButton.gameObject.SetActive(true);
		}

		//NOTE Open Unique Boss Fight Choices or add new Type
		//Also add unique button when certain item is aquired

		collision.gameObject.GetComponent<MovementController>().enabled = false;
		yield return new WaitForSeconds(.1f);

		collision.GetComponent<MovementController>().RoadBlockMover(moveLocation);
		//change in boss fight leave here for now
		collision.gameObject.GetComponent<MovementController>().enabled = true;
	}
}


