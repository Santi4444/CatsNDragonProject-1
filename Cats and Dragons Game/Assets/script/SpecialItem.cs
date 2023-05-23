using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpecialItem : MonoBehaviour
{
	public GameObject dialoguePanel;
	public TextMeshProUGUI dialogueText;
	public string dialogue;
	private int index;

	//public GameObject contButton;
	public float wordSpeed;
	public bool playerIsClose;

	[SerializeField] private bool ePressed = false;
	[SerializeField] private GameObject player;
	[SerializeField] private bool specialItem = false;


	[SerializeField] private GameObject dialogueNPCTextBox;
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

				if(specialItem)
				{
					StartCoroutine(TypingNormal(player));
				}
				else
				{
					StartCoroutine(TypingSpecialItem(player));
				}
				
			}

		}

	}

	public void zeroText()
	{
		dialogueText.text = "";
		index = 0;
		dialoguePanel.SetActive(false);
	}

	IEnumerator TypingNormal(GameObject other)
	{
		ePressed = true;
		MovementController controller = other.GetComponent<MovementController>();
		controller.animator.SetBool("isMoving", false);
		controller.enabled = false;
		dialogueText.text = string.Empty;


		foreach (char c in dialogue.ToCharArray())
		{
			dialogueText.text += c;
			yield return new WaitForSeconds(wordSpeed);
		}
		yield return new WaitForSeconds(2f);


		controller.enabled = true;
		dialoguePanel.SetActive(false);
		ePressed = false;
	}

		IEnumerator TypingSpecialItem(GameObject other)
		{
		ePressed = true;
		MovementController controller = other.GetComponent<MovementController>();
		controller.animator.SetBool("isMoving", false);
		controller.enabled = false;
		dialogueText.text = string.Empty;


		foreach (char c in dialogue.ToCharArray())
		{
			dialogueText.text += c;
			yield return new WaitForSeconds(wordSpeed);
		}

		

		yield return new WaitForSeconds(1f);

		other.GetComponent<PlayerData>().SpecialItem = true;
		specialItem = true;
		dialogueText.text = string.Empty;
		string itemDialogue = "You got a special item";
		foreach (char c in itemDialogue.ToCharArray())
		{
			dialogueText.text += c;
			yield return new WaitForSeconds(wordSpeed);
		}
		yield return new WaitForSeconds(1f);

		controller.enabled = true;
		dialoguePanel.SetActive(false);
		ePressed = false;


	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			movementController = other.GetComponent<MovementController>();
			player = other.gameObject;
			playerIsClose = true;
			dialogueNPCTextBox.gameObject.SetActive(true);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			playerIsClose = false;
			zeroText();
			dialogueNPCTextBox.gameObject.SetActive(false);
		}	
	}


}
