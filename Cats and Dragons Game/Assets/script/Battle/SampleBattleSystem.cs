using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleBattleSystem : MonoBehaviour
{
	[SerializeField] private GameObject BattleSystemCanvas;
	public void StartBattleSystem()
	{
		BattleSystemCanvas.SetActive(true);
	}
}
