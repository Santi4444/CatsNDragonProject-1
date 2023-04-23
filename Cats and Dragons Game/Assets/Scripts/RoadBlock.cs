using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlock : MonoBehaviour
{
    [SerializeField] private Collider2D collider;
    [SerializeField] private Vector3 moveLocation;
    // Start is called before the first frame update
    void Start()
    {
        collider = this.gameObject.GetComponent<Collider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("enter");

		StartCoroutine(MovePlayer(collision));

		//collision.GetComponent<MovementController>().RoadBlockMover(moveLocation);
	}

    IEnumerator MovePlayer(Collider2D collision)
	{
        
        Debug.Log("2nd location");
        collision.gameObject.GetComponent<MovementController>().enabled = false;
        yield return new WaitForSeconds(2f);
        Debug.Log("new location");
        collision.GetComponent<MovementController>().RoadBlockMover(moveLocation);
        collision.gameObject.GetComponent<MovementController>().enabled = true;
    }

    
}
