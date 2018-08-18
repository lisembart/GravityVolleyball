using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFollower : MonoBehaviour 
{
	public GameObject ballObject;
	
	void Update () 
	{
		transform.position = new Vector3(ballObject.transform.position.x, transform.position.y, transform.position.z);
	}
}
