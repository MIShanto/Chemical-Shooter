using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using DG.Tweening;

public class EnemyManagersXRControl : MonoBehaviour 
{
	public Button buttonStart;
	public GameObject bossSpawnPoint;
	public GameObject bossPrefab;
	public EnemyManagerXR[] enemyManagersXR;
	private EnemyManagerXR enemyManagerXRTemp;
	public UnityEvent OnInitialized;
	public int WaveCount;
	private int initedPools = 0;
	private int enemyManagersXRActiveCount = 0;
	public int enemyCount, remainingWave;

	private void Start()
	{
		buttonStart.onClick.AddListener(Spawn);
		remainingWave = WaveCount;
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

		if (enemyCount <= 0)
		{
			if (remainingWave > 0)
			{
				remainingWave--;
				Spawn();
			}
			else
			{
				SpawnBoss();
			}
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
	void SpawnBoss()
	{
		Instantiate(bossPrefab, bossSpawnPoint.transform.position, Quaternion.identity);
	}
	public void Spawn()
	{
		//tween
		GameManager.instance.hudManager.ShowAlert("Wave incoming\nSelect proper gun");

		enemyManagerXRTemp = enemyManagersXR[WaveCount - remainingWave - 1];

		if (enemyManagerXRTemp)
		{
			enemyManagerXRTemp.Spawn();
		}
	}
}
