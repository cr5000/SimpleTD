using UnityEngine;
using System.Collections;

public class TowerDetectEnemy : MonoBehaviour {
	
	public GameObject bullet;

	private float coolDown = 0.4f;
	private float coolDownTimer;

	private float bulletForce = 200f;

	private GameObject currentTarget = null;

	void Update()
	{
		ShootBullets();
	}

	void ShootBullets()
	{
		if (currentTarget != null)
		{
			//shoot at target
//			print("SHOOT");

			coolDownTimer -= Time.deltaTime;

			if (coolDownTimer <= 0)
			{
				GameObject clone;
				clone = Instantiate(bullet,transform.position, Quaternion.identity) as GameObject;
				clone.rigidbody2D.AddForce((currentTarget.transform.position - transform.position).normalized * bulletForce);
				coolDownTimer = coolDown;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy")
		{
			currentTarget = other.gameObject;
			print("target acquired");
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Enemy")
		{
			currentTarget = null;
		}
	}

}
