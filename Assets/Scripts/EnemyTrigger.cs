using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour 
{
	[SerializeField] private EnemyController enemyController;
	
	private void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.gameObject.tag == "Ball")
		{
			if(enemyController.canJump)
			{
				enemyController.Jump();
				enemyController.canJump = false;
				StartCoroutine(enemyController.CountdownToJump());
			}	
		}
	}
}
