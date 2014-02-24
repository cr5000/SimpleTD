using UnityEngine;
using System.Collections;

public class Tower2Shoot : MonoBehaviour {
	
	public GameObject bullet;
	
	private float coolDown = 0.4f;
	private float coolDownTimer;
	
//	private float bulletForce = 200f;
	
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
				GameObject bulletClone;
				bulletClone = Instantiate(bullet,transform.position, Quaternion.identity) as GameObject;
//				bulletClone.rigidbody2D.AddForce((currentTarget.transform.position - transform.position).normalized * bulletForce);
				bulletClone.gameObject.GetComponent<HomingMissileScript>().attackTarget = currentTarget;
				coolDownTimer = coolDown;
			}
		}
	}

	//when there is an enemy in the trigger radius
	void OnTriggerStay2D(Collider2D other)
	{
		if (currentTarget == null)
		{
			currentTarget = other.gameObject;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (currentTarget == null)
		{
			if (other.tag == "Enemy")
			{
				currentTarget = other.gameObject;
	//			print("target acquired");
			}
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
