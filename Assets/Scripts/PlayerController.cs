using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerBehaviour
{
	void Update () 
	{
		grounded = Physics2D.IsTouchingLayers(playerCollider, groundLayerMask)
		 || Physics2D.IsTouchingLayers(playerDownCollider, groundLayerMask);

		if(Input.GetKeyDown(KeyCode.Space) && playerNumber == 1)
		{
			Jump();
		}

		if(Input.GetKeyDown(KeyCode.F) && playerNumber == 2)
		{
			Jump();
		}

		if(jump)
		{
			if(grounded)
			{
				playerRgbd.AddForce(new Vector2(base.transform.up.x, Mathf.Abs(base.transform.up.y)) * this.jumpFactor);
				jump = false;
			}
		}
	}
}
