using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class OverworldNPCDialogue : MonoBehaviour
{
	public GameObject dialoguePanel;
	public TextMeshProUGUI dialogueText;
	public string dialogue;
	private int index;

	//public GameObject contButton;
	public float wordSpeed;
	public bool playerIsClose;

	[SerializeField] private bool ePressed = false;
	[SerializeField] private MovementController movementController;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && playerIsClose && !ePressed)
		{
			

			if (dialoguePanel.activeInHierarchy)
			{
				zeroText();
			}
			else
			{
				dialoguePanel.SetActive(true);
				StartCoroutine(Typing(movementController));
			}

		}

		//if (dialogueText.text == dialogue[index])
		//{
		//	contButton.SetActive(true);
		//}
	}

	public void zeroText()
	{
		dialogueText.text = "";
		index = 0;
		dialoguePanel.SetActive(false);
	}

	IEnumerator Typing(MovementController other)
	{
		ePressed = true;
		other.animator.SetBool("isMoving", false);
		other.enabled = false;
		Debug.Log("typed"); 
		dialogueText.text = string.Empty;
		foreach (char c in dialogue.ToCharArray())
		{
			dialogueText.text += c;
			yield return new WaitForSeconds(0.1f);
		}
		yield return new WaitForSeconds(2f);
		other.enabled = true;
		dialoguePanel.SetActive(false);
		ePressed = false;

		////For every letter added, a new one will be added after a few seconds
		//foreach (char letter in dialogue[index].ToCharArray())
		//{
		//	dialogueText.text += letter;
		//	yield return new WaitForSeconds(wordSpeed);
		//}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			movementController = other.GetComponent<MovementController>();
			playerIsClose = true;
		}
	}

	//public void NextLine()
	//{
	//	contButton.SetActive(false);

	//	if (index < dialogue.Length - 1)
	//	{
	//		index++;
	//		dialogueText.text = "";
	//		StartCoroutine(Typing(movementController));
	//	}
	//	else
	//	{
	//		zeroText();
	//	}
	//}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			playerIsClose = false;
			zeroText();
		}
	}
}
