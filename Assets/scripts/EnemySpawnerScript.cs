using UnityEngine;
using System.Collections;

public class EnemySpawnerScript : MonoBehaviour 
{
	//public
	public GameObject enemy;

	private int numberOfWave = 5; //wave 1 = spawn 1 enemy, wave 2 = spawn 2 enemies etc.
	private int numberOfEnemiesSpawnedThisWave = 0;

	//timer for wave spawns
	private float waveSpawnCooldown = 3f;
	private float waveCooldownTimer;

	//timer for each enemy spawn
	private float enemySpawnCooldown = 0.6f;
	private float enemyCooldownTimer = 0f;

	//states
	enum State
	{
		Spawning,
		Cooldown
	};

	private State state = State.Cooldown;

	void Start()
	{
		waveCooldownTimer = waveSpawnCooldown;
	}

	void Update()
	{
		SpawnWaves1();
	}

	void SpawnWaves1()
	{
		if (state == State.Cooldown)
		{
			//subtract time from the cd timer
			waveCooldownTimer -= Time.deltaTime;

			//when the cd timer reaches zero switch to spawning state
			if (waveCooldownTimer <= 0f)
			{
				state = State.Spawning;
			}

		}

		if (state == State.Spawning)
		{
			//subtract time from the cd timer
			enemyCooldownTimer -= Time.deltaTime;

			//when the timer reaches 0
			if (enemyCooldownTimer <= 0f)
			{
				//spawn enemy
				Instantiate(enemy, new Vector2(-10f, 0f), Quaternion.identity);
				numberOfEnemiesSpawnedThisWave++;
//				print("SPAWN ENEMY" + numberOfEnemiesSpawnedThisWave);
				enemyCooldownTimer = enemySpawnCooldown; //reset the enemy cd timer

				if (numberOfEnemiesSpawnedThisWave >= numberOfWave)
				{
					numberOfEnemiesSpawnedThisWave = 0; //reset the enemy counter
					numberOfWave++; //increase wave by 1
					state = State.Cooldown; //switch to cooldown state
					waveCooldownTimer = waveSpawnCooldown; //reset the wave cd timer
				}
			}


		}
	}


}
