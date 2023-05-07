using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossFightTrigger : MonoBehaviour
{
	[SerializeField] private Collider2D collider;
	[SerializeField] private GameObject BossFight;
	[SerializeField] private Button ApologyButton;
	[SerializeField] private Vector3 moveLocation;
	public EnemyData BossData;
	[SerializeField] private GameObject overWorldDialogue;
	[SerializeField] private TextMeshProUGUI dialogueBox;


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
		overWorldDialogue.SetActive(true);
		collision.gameObject.GetComponent<MovementController>().enabled = false;
		collision.gameObject.GetComponent<MovementController>().animator.SetBool("isMoving", false);

		dialogueBox.text = string.Empty;

		float textSpeed = 0.05f;

		//conversation
		string line0 = "??: Well well well... ";
		foreach (char c in line0.ToCharArray())
		{
			dialogueBox.text += c;
			yield return new WaitForSeconds(0.1f);
		}
		yield return new WaitForSeconds(1f);

		string line1 = "look who finally showed up.";
		foreach (char c in line1.ToCharArray())
		{
			dialogueBox.text += c;
			yield return new WaitForSeconds(textSpeed);
		}
		yield return new WaitForSeconds(1f);

		dialogueBox.text = string.Empty;
		string line2 = "Dragon: So you're here to insult me again witch?";
		foreach (char c in line2.ToCharArray())
		{
			dialogueBox.text += c;
			yield return new WaitForSeconds(textSpeed);
		}
		yield return new WaitForSeconds(1f);

		dialogueBox.text = string.Empty;
		string line3 = "Witch: No i’m here to bring the moon back";
		foreach (char c in line3.ToCharArray())
		{
			dialogueBox.text += c;
			yield return new WaitForSeconds(textSpeed);
		}
		yield return new WaitForSeconds(1f);

		dialogueBox.text = string.Empty;
		string line4 = "Dragon: There you go again, always helping people did that even turn out well for you?";
		foreach (char c in line4.ToCharArray())
		{
			dialogueBox.text += c;
			yield return new WaitForSeconds(textSpeed);
		}
		yield return new WaitForSeconds(1f);

		dialogueBox.text = string.Empty;
		string line5 = "Witch: Why are you doing this dragon?";
		foreach (char c in line5.ToCharArray())
		{
			dialogueBox.text += c;
			yield return new WaitForSeconds(textSpeed);
		}
		yield return new WaitForSeconds(1f);


		dialogueBox.text = string.Empty;
		string line6 = "Dragon: You should know why.";
		foreach (char c in line6.ToCharArray())
		{
			dialogueBox.text += c;
			yield return new WaitForSeconds(textSpeed);
		}
		yield return new WaitForSeconds(1f);


		dialogueBox.text = string.Empty;
		string line7 = "Witch: I just wanted to help!";
		foreach (char c in line7.ToCharArray())
		{
			dialogueBox.text += c;
			yield return new WaitForSeconds(textSpeed);
		}
		yield return new WaitForSeconds(1f);

		dialogueBox.text = string.Empty;
		string line8 = "Dragon: I didn’t want your help!";
		foreach (char c in line8.ToCharArray())
		{
			dialogueBox.text += c;
			yield return new WaitForSeconds(textSpeed);
		}
		yield return new WaitForSeconds(1f);

		dialogueBox.text = string.Empty;
		string line9 = "Witch: Why are you so upset with me dragon?";
		foreach (char c in line9.ToCharArray())
		{
			dialogueBox.text += c;
			yield return new WaitForSeconds(textSpeed);
		}
		yield return new WaitForSeconds(1f);

		dialogueBox.text = string.Empty;
		string line10 = "Dragon: Just leave!";
		foreach (char c in line10.ToCharArray())
		{
			dialogueBox.text += c;
			yield return new WaitForSeconds(textSpeed);
		}

		yield return new WaitForSeconds(1f);
		
		overWorldDialogue.SetActive(false);
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
		//collision.gameObject.GetComponent<MovementController>().enabled = true;
	}
}


