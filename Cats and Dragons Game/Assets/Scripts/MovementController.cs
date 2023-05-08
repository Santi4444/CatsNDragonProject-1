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

    public GameObject mainCamera;

    public bool isMoving;
    private Vector2 input;

    public BattleUnit enemyCharacter;
    public BattleSystem enemyBattleSystem;

    public SampleWildEnemies testenemies;

    public Animator animator;

	public GameObject OverworldGameObject;
	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

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
				animator.SetFloat("moveX", input.x);
				animator.SetFloat("moveY", input.y);


				var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if(IsWalkable(targetPos))
				{
                    StartCoroutine(Move(targetPos));
                }
                
			}

            animator.SetBool("isMoving", isMoving);
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
                //temp fix
                //testenemies = FindObjectOfType<SampleWildEnemies>().GetComponent<SampleWildEnemies>();

                SampleWildEnemies wildEnemies = Physics2D.OverlapCircle(transform.position, 0.2f, randomArea).gameObject.GetComponent<SampleWildEnemies>();
                //temp fix
                testenemies = wildEnemies;
                enemyBattleSystem.SetupBattle(testenemies.GetRandomEnemy());
                mainCamera.SetActive(false);
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
        mainCamera.SetActive(true);
		OverworldGameObject.SetActive(true);
        this.gameObject.GetComponent<MovementController>().enabled = true;

	}

	public void RoadBlockMover(Vector3 targetLocation)
	{
		StopAllCoroutines();
		StartCoroutine(Move(targetLocation));
	}

	public void Teleport(Vector3 targetPos)
	{
		isMoving = true;
		transform.position = targetPos;
		isMoving = false;
	}
}
