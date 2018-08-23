using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaycast : MonoBehaviour 
{
	public EnemyController enemyController;
	private bool canJump;

	void Start () 
	{
		canJump = true;
	}

	void Update () 
	{
		RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector2.down);
		if(rayHit.collider != null)
		{
			GameObject hitObject = rayHit.transform.gameObject;
			if(hitObject.gameObject.name == "Ball" && canJump)
			{
				enemyController.Jump();
				canJump = false;
				StartCoroutine(CountdownToJump());
			}
		}
	}

	IEnumerator CountdownToJump()
	{
		yield return new WaitForSeconds(0.1f);
		canJump = true;
	}
}
