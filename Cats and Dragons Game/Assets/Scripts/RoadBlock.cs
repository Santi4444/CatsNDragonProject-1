using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoadBlock : MonoBehaviour
{
    [SerializeField] private Collider2D collider;
    [SerializeField] private Vector3 moveLocation;
	[SerializeField] private GameObject dialogueContainer;
	[SerializeField] private TextMeshProUGUI dialogueBox;

	[SerializeField] private PlayerData playerData;
	[SerializeField] private int pointAmount;
	// Start is called before the first frame update
	void Start()
    {
        collider = this.gameObject.GetComponent<Collider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("enter");

		StartCoroutine(MovePlayer(collision, "You need " + pointAmount + " friend points"));

		//collision.GetComponent<MovementController>().RoadBlockMover(moveLocation);
	}

    IEnumerator MovePlayer(Collider2D collision, string playerLine)
	{
		
		Debug.Log("2nd location");
		dialogueBox.text = string.Empty;
		dialogueContainer.SetActive(true);
		collision.gameObject.GetComponent<MovementController>().enabled = false;

		collision.gameObject.GetComponent<MovementController>().animator.SetBool("isMoving", false);

		if (playerData.playerFriendPoints < pointAmount)
		{
			

			foreach (char c in playerLine.ToCharArray())
			{
				
				dialogueBox.text += c;
				yield return new WaitForSeconds(0.1f);
			}
			yield return new WaitForSeconds(2f);
			Debug.Log("new location");
			collision.GetComponent<MovementController>().RoadBlockMover(moveLocation);
			collision.gameObject.GetComponent<MovementController>().enabled = true;
			dialogueContainer.SetActive(false);
		}else
		{
			
			string pass = "You passed";
			foreach (char c in pass.ToCharArray())
			{
				
				dialogueBox.text += c;
				yield return new WaitForSeconds(0.1f);
			}
			yield return new WaitForSeconds(2f);
			Destroy(this.gameObject);
			collision.gameObject.GetComponent<MovementController>().enabled = true;
			dialogueContainer.SetActive(false);

		}
	}

    
}
