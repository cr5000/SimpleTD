using UnityEngine;
using System.Collections;

public class HomingMissileScript : MonoBehaviour {

	[HideInInspector]
	public GameObject attackTarget = null;

	private float speed = 5f;

	//rotate vars
//	private float increment;
	
	// Update is called once per frame
	void Update () {
		if (attackTarget != null)
		{
//			print("homing missile attacking something");
			transform.position = Vector2.MoveTowards(transform.position, attackTarget.transform.position, Time.deltaTime * speed);

		}
		else
		{
			//destroy the bullet if it loses the attack target
			Destroy(gameObject);
		}
	}


}
