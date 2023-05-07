using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

	[SerializeField] private Collider2D collider;
	[SerializeField] private Vector3 position;

	[SerializeField] private GameObject overWorldDialogue;
	[SerializeField] private TextMeshProUGUI dialogueBox;

	void Start()
	{
		collider = this.gameObject.GetComponent<Collider2D>();
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		StartCoroutine(TeleportPlayer(collision));


	}

	IEnumerator TeleportPlayer(Collider2D collision)
	{
		collision.gameObject.GetComponent<MovementController>().animator.SetBool("isMoving", false);
		collision.gameObject.GetComponent<MovementController>().enabled = false;

		overWorldDialogue.SetActive(true);

		dialogueBox.text = string.Empty;
		string line1 = "Witch: Well…There’s no turning back now. I can do this!";
		foreach (char c in line1.ToCharArray())
		{
			dialogueBox.text += c;
			yield return new WaitForSeconds(0.1f);
		}
		
		

		//collision.gameObject.GetComponent<MovementController>().enabled = false;
		//collision.GetComponent<MovementController>().Teleport(position);
		//collision.gameObject.GetComponent<MovementController>().enabled = true;
		
		//collision.GetComponent<SpriteRenderer>().color.a =;
		yield return new WaitForSeconds(2f);
		overWorldDialogue.SetActive(false);
		Debug.Log("new tele location");
		collision.GetComponent<MovementController>().Teleport(position);
		collision.gameObject.GetComponent<MovementController>().enabled = true;


	}

}
