using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBall : MonoBehaviour 
{
	private void OnTriggerEnter2D(Collider2D col) 
	{
		if(col.gameObject.tag == "Ball")
		{
			col.gameObject.SendMessage("UnfreezeMovement");
		}	
	}
	
	private void OnCollisionEnter2D(Collision2D col) 
	{
		if(col.gameObject.tag == "Ball")
		{
			col.gameObject.SendMessage("UnfreezeMovement");
		}
	}
}
