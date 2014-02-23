using UnityEngine;
using System.Collections;

public class MoveThroughWaypoints : MonoBehaviour 
{
	public GameObject waypointGroupSmall;

	private float speed = 1f;

	private int nextWaypointIndex = 1;

	void Start()
	{
		transform.position = waypointGroupSmall.transform.GetChild(0).transform.position;
//		print(waypointGroupSmall.transform.GetChild(0).transform.position.x);
	}

	void Update()
	{
		Move();
	}

	void Move()
	{
		Vector3 targetPosition = waypointGroupSmall.transform.GetChild(nextWaypointIndex).transform.position;

		float step = speed * Time.deltaTime;

//		print ("x = " + targetPosition.x + ", y=" + targetPosition.y);

		transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

//		print(waypointGroupSmall.transform.childCounat);

		if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
		{
			//an den ftasame sto teleutaio waypoint
			if (nextWaypointIndex < waypointGroupSmall.transform.childCount - 1)
				nextWaypointIndex++;
			else //an ftasame sto teleutaio waypoint autokatastrepsou
			{
				Destroy(gameObject);
			}

		}
	}

}
