using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCutscene : MonoBehaviour
{

	[SerializeField] private Animator animator;

	[SerializeField] private int counter = 1;



	public void PlayScene()
	{
		counter++;

		if (counter == 2)
		{
			animator.SetTrigger("End1");
		}
		else if (counter == 3)
		{
			animator.SetTrigger("End2");
		}
		else if (counter == 4)
		{
			animator.SetTrigger("End3");
		}
		else if (counter == 5)
		{
			animator.SetTrigger("End4");
		}
		else if (counter == 6)
		{
			animator.SetTrigger("End5");
		}
		else if (counter == 7)
		{
			animator.SetTrigger("End6");
		}
		else if (counter == 8)
		{
			animator.SetTrigger("End7");
		}
		else if (counter == 9)
		{
			animator.SetTrigger("End8");
		}
		else if (counter == 10)
		{
			animator.SetTrigger("End9");
		}
		else if (counter == 11)
		{
			animator.SetTrigger("End10");
		}
		else if (counter == 12)
		{
			animator.SetTrigger("End11");
		}
		else if (counter == 13)
		{
			animator.SetTrigger("End12");
		}
		else if (counter == 14)
		{
			animator.SetTrigger("End13");
			
		}else if(counter >= 15)
		{
			SceneManager.LoadScene("TitleScreen");
		}

	}
}
