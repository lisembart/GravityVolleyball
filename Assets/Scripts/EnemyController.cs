using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : PlayerBehaviour
{
	public bool canJump;	

	public IEnumerator CountdownToJump()
	{
		yield return new WaitForSeconds(0.1f);
		canJump = true;
	}
}
