using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    //speed
    public float moveSpeed;

    public LayerMask solidObjectsLayer;
    public LayerMask randomArea;


    public GameObject BattleCanvas;



    private bool isMoving;
    private Vector2 input;

    // Update is called once per frame
    void Update()
    {
        if(!isMoving)
		{
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            //prevents diagonal
            if(input.x != 0)
			{
                input.y = 0;
			}

            if(input != Vector2.zero)
			{
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if(IsWalkable(targetPos))
				{
                    StartCoroutine(Move(targetPos));
                }
                
			}
		}
    }

    IEnumerator Move(Vector3 targetPos)
	{
        isMoving = true;

        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
		{
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;

		}
        transform.position = targetPos;

        isMoving = false;

        RandomEncounter();


    }

    private bool IsWalkable(Vector3 targetPos)
	{
        if (Physics2D.OverlapCircle(targetPos, 0.3f, solidObjectsLayer) != null)
        {
            return false;
        }
            return true;
	}

    private void RandomEncounter()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, randomArea) != null)
        {
            Debug.Log("Touch");
            if (Random.Range(1, 101) <= 50)
			{
                BattleCanvas.SetActive(true);
                isMoving = true;
                Debug.Log("Random Encounter");
			}
        }

    }

    public void LeaveRandomEncounter()
	{
        isMoving = false;
        BattleCanvas.SetActive(false);
    }

}
