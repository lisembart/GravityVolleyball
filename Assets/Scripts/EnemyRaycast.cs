using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaycast : MonoBehaviour 
{
	public EnemyController enemyController;

	void Start () 
	{
		enemyController.canJump = true;
	}

	void Update () 
	{
		RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector2.down);
		if(rayHit.collider != null)
		{
			GameObject hitObject = rayHit.transform.gameObject;
			if(hitObject.gameObject.name == "Ball" && enemyController.canJump)
			{
				enemyController.Jump();
				enemyController.canJump = false;
				StartCoroutine(enemyController.CountdownToJump());
			}
		}
		Debug.DrawLine (transform.position, rayHit.point,Color.red);
	}



	
}
