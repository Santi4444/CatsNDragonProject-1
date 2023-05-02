using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
	
	public TextMeshProUGUI enemyNameText;
	public TextMeshProUGUI enemyHp;


	public PlayerData player;
	public TextMeshProUGUI playerHp;

	public TextMeshProUGUI dialogueBox;

	public Button[] attackButtons;
	private int dialogueNum;

	public BattleSystem battleSystem;

	public Button[] ChoiceButtons;

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

	public void PlayEnemyIncorrectDialogue(Enemy opponent, string playerLine)
	{
		StartCoroutine(GettingWrongChoiceDialogue(opponent, playerLine));

	}

	IEnumerator GettingWrongChoiceDialogue(Enemy enemy, string playerLine)
	{
		for (int i = 0; i < attackButtons.Length; i++)
		{
			attackButtons[i].interactable = false;
		}
		//plays player action dialogue
		dialogueBox.text = string.Empty;
		foreach (char c in playerLine.ToCharArray())
		{
			dialogueBox.text += c;
			yield return new WaitForSeconds(0.1f);
		}
		yield return new WaitForSeconds(1f);
		//plays enemy action dialogue
		dialogueBox.text = string.Empty;
		foreach (char c in enemy.enemy.enemyWrongDialogue[Random.Range(0, enemy.enemy.enemyWrongDialogue.Length)].ToCharArray())
		{
			dialogueBox.text += c;
			yield return new WaitForSeconds(0.1f);
		}
		yield return new WaitForSeconds(1f);



		if (battleSystem.playerHealth <= 0)
		{
			//plays loss dialogue
			dialogueBox.text = string.Empty;
			foreach (char c in enemy.enemy.enemyVictoryDialogue[Random.Range(0, enemy.enemy.enemyVictoryDialogue.Length)].ToCharArray())
			{
				dialogueBox.text += c;
				yield return new WaitForSeconds(0.1f);
			}
			yield return new WaitForSeconds(1f);
			for (int i = 0; i < attackButtons.Length; i++)
			{
				attackButtons[i].interactable = true;
			}
			battleSystem.CheckPlayerHpIsZero();
		}
		else
		{
			//plays comment intro
			dialogueBox.text = string.Empty;
			foreach (char c in enemy.enemy.dialogue[Random.Range(0, enemy.enemy.dialogue.Length)].ToCharArray())
			{
				dialogueBox.text += c;
				yield return new WaitForSeconds(0.1f);
			}
			for (int i = 0; i < attackButtons.Length; i++)
			{
				attackButtons[i].interactable = true;
			}
		}

	}
	public void PlayEnemyCorrectDialogue(Enemy opponent, string playerLine)
	{
		StartCoroutine(GettingCorrectChoiceDialogue(opponent, playerLine));
	}

	IEnumerator GettingCorrectChoiceDialogue(Enemy enemy, string playerLine)
	{
		for (int i = 0; i < attackButtons.Length; i++)
		{
			attackButtons[i].interactable = false;
		}
		//plays player action dialogue
		dialogueBox.text = string.Empty;
		foreach (char c in playerLine.ToCharArray())
		{
			dialogueBox.text += c;
			yield return new WaitForSeconds(0.1f);
		}
		yield return new WaitForSeconds(1f);
		//plays enemy action dialogue
		dialogueBox.text = string.Empty;
		foreach (char c in enemy.enemy.enemyCorrectDialogue[Random.Range(0, enemy.enemy.enemyCorrectDialogue.Length)].ToCharArray())
		{
			dialogueBox.text += c;
			yield return new WaitForSeconds(0.1f);
		}
		yield return new WaitForSeconds(1f);



		if (battleSystem.EnemyHealth <= 0)
		{
			//plays victory dialogue
			dialogueBox.text = string.Empty;
			foreach (char c in enemy.enemy.enemyLossDialogue[Random.Range(0, enemy.enemy.enemyLossDialogue.Length)].ToCharArray())
			{
				dialogueBox.text += c;
				yield return new WaitForSeconds(0.1f);
			}
			yield return new WaitForSeconds(1f);

			dialogueBox.text = string.Empty;

			string pointsGained = "You gained " + enemy.enemy.enemyPoints + " friend points";


			foreach (char c in pointsGained.ToCharArray())
			{
				dialogueBox.text += c;
				yield return new WaitForSeconds(0.1f);
			}
			yield return new WaitForSeconds(1f);

			for (int i = 0; i < attackButtons.Length; i++)
			{
				attackButtons[i].interactable = true;
			}
			battleSystem.CheckEnemyHpIsZero();
		}
		else
		{
			//plays comment intro
			dialogueBox.text = string.Empty;
			foreach (char c in enemy.enemy.dialogue[Random.Range(0, enemy.enemy.dialogue.Length)].ToCharArray())
			{
				dialogueBox.text += c;
				yield return new WaitForSeconds(0.1f);
			}
			for (int i = 0; i < attackButtons.Length; i++)
			{
				attackButtons[i].interactable = true;
			}
		}

	}

	public void FinalBossInteraction()
	{
		StartCoroutine(FinalBossDialogue());
	}
	IEnumerator FinalBossDialogue()
	{
		for (int i = 0; i < attackButtons.Length; i++)
		{
			attackButtons[i].interactable = false;
		}
		string apology = "I apologize";




		//plays player action dialogue
		dialogueBox.text = string.Empty;
		foreach (char c in apology.ToCharArray())
		{
			dialogueBox.text += c;
			yield return new WaitForSeconds(0.1f);
		}

		yield return new WaitForSeconds(1f);
		string apology2 = "Oh I forgive you";

		//plays player action dialogue
		dialogueBox.text = string.Empty;
		foreach (char c in apology2.ToCharArray())
		{
			dialogueBox.text += c;
			yield return new WaitForSeconds(0.1f);
		}

		for (int i = 0; i < attackButtons.Length; i++)
		{
			attackButtons[i].interactable = true;
		}
	}

	public void RunAwayFunction(MovementController mc)
	{
		StartCoroutine(RunAway(mc));
	}
	IEnumerator RunAway(MovementController mc)
	{
		for (int i = 0; i < ChoiceButtons.Length; i++)
		{
			ChoiceButtons[i].interactable = false;
		}
		string apology = "You ran away";




		//plays player action dialogue
		dialogueBox.text = string.Empty;
		foreach (char c in apology.ToCharArray())
		{
			dialogueBox.text += c;
			yield return new WaitForSeconds(0.1f);
		}

		yield return new WaitForSeconds(1f);

		for (int i = 0; i < ChoiceButtons.Length; i++)
		{
			ChoiceButtons[i].interactable = true;
		}

		mc.LeaveRandomEncounter();


	}

}
