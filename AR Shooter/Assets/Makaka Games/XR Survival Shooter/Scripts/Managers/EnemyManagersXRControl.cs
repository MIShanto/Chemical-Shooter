using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;

public class EnemyManagersXRControl : MonoBehaviour 
{
	public Button buttonStart;
	public EnemyManagerXR[] enemyManagersXR;
	private EnemyManagerXR enemyManagerXRTemp;
	public UnityEvent OnInitialized;
	public int WaveCount;
	private int initedPools = 0;
	private int enemyManagersXRActiveCount = 0;
	int enemyCount, remainingWave;

	private void Start()
	{
		buttonStart.onClick.AddListener(Spawn);
		remainingWave--;

		for (int i = 0; i < enemyManagersXR.Length; i++)
		{
			enemyManagerXRTemp = enemyManagersXR[i];

			if (enemyManagerXRTemp)
			{	
				enemyManagerXRTemp.OnInitialized.AddListener(CountInitedEnemyManagerXR);
				enemyManagerXRTemp.OnSpawn.AddListener(EnemySpawned);
				enemyManagerXRTemp.OnDeath.AddListener(EnemyDead);
				enemyManagerXRTemp.enabled = true;

				enemyManagersXRActiveCount++;
			}
		}
	}
	public void EnemySpawned()
	{
		enemyCount++;
	}
	public void EnemyDead()
	{
		enemyCount--;

		if (enemyCount <= 0 && remainingWave > 0)
		{
			Spawn();
			remainingWave--;
		}
	}
	public void CountInitedEnemyManagerXR()
	{
		initedPools++;

		//Debug.Log("Pool Inited: #" + initedPools);

		if (initedPools == enemyManagersXRActiveCount)
		{
			buttonStart.interactable = true;

			OnInitialized.Invoke();

			//Debug.Log("All Pools Inited");
		}
	}

	public void Spawn()
	{
		for (int i = 0; i < enemyManagersXR.Length; i++)
		{
			enemyManagerXRTemp = enemyManagersXR[i];

			if (enemyManagerXRTemp)
			{	
				enemyManagerXRTemp.Spawn();
			}
		}
	}
}
