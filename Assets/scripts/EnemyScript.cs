using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	private float maxHealth = 20f;
	private float currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Bullet")
		{
			//destroy the bullet
			if (other.transform.parent != null)
			{
				Destroy(other.transform.parent.gameObject);
			}
			else
				Destroy(other.gameObject);

			//damage the enemy
			damageEnemy(10f);
		}

	}

	void damageEnemy(float dmg)
	{
		currentHealth -= dmg;
		if (currentHealth <= 0f)
		{
			Destroy(gameObject);
		}
	}
}
