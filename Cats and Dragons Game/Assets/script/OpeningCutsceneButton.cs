using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningCutsceneButton : MonoBehaviour
{

	[SerializeField] private Animator animator;

    [SerializeField] private int counter = 1;



    public void PlayScene()
    {
        counter++;

		if (counter == 2)
        {
			animator.SetTrigger("OpenCut2");
		} else if (counter == 3) 
        {
			animator.SetTrigger("OpenCut3");
		} else if(counter == 4)
        {
			animator.SetTrigger("OpenCut4");
		}else if(counter == 5)
        {
			animator.SetTrigger("OpenCut5");
		}else if (counter == 6)
		{
			animator.SetTrigger("OpenCut6");
		} else if (counter==7)
		{
			animator.SetTrigger("OpenCut7");
		} else if( counter == 8) 
		{
			animator.SetTrigger("OpenCut8");
		}else if( counter == 9) 
		{
			animator.SetTrigger("OpenCut9");
		} else if (counter == 10)
		{
			animator.SetTrigger("OpenCut10");
		} else if(counter == 11)
		{
			animator.SetTrigger("OpenCut11");
		} else if (counter == 12)
		{
			animator.SetTrigger("OpenCut12");
		} else if ( counter == 13)
		{
			animator.SetTrigger("OpenCut13");
		} else if(counter == 14)
		{
			animator.SetTrigger("OpenCut14");
		}else if (counter == 15)
		{
			animator.SetTrigger("OpenCut15");
		}else if(counter==16)
		{
			SceneManager.LoadScene("SampleScene");
		}
        
    }
}
