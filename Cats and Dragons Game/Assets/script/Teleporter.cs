using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

	[SerializeField] private Collider2D collider;
	[SerializeField] private Vector3 position;

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
		//collision.gameObject.GetComponent<MovementController>().enabled = false;
		//collision.GetComponent<MovementController>().Teleport(position);
		//collision.gameObject.GetComponent<MovementController>().enabled = true;
		collision.gameObject.GetComponent<MovementController>().animator.SetBool("isMoving", false);
		collision.gameObject.GetComponent<MovementController>().enabled = false;
		//collision.GetComponent<SpriteRenderer>().color.a =;
		yield return new WaitForSeconds(2f);
		Debug.Log("new tele location");
		collision.GetComponent<MovementController>().Teleport(position);
		collision.gameObject.GetComponent<MovementController>().enabled = true;


	}

}
