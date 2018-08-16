using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour 
{
	private GameManager gameManager;
	private Rigidbody2D ballRgbd;
	
	[Header("Ball Spawn Positions")]
	public Transform leftBallSpawnPosition;
	public Transform rightBallSpawnPosition;

	void Start () 
	{
		gameManager = FindObjectOfType<GameManager>();
		ballRgbd = GetComponent<Rigidbody2D>();
	}
	

	void Update () 
	{

	}

	private void OnCollisionEnter2D(Collision2D col) 
	{
		if(col.gameObject.tag == "FloorLeft")
		{
			gameManager.SendMessage("AddPoint",1);
		}

		if(col.gameObject.tag == "FloorRight")
		{
			gameManager.SendMessage("AddPoint",2);
		}
	}

	public void ResetBall(int whoScoredPoint)
	{
		ballRgbd.velocity = Vector2.zero;
		ballRgbd.angularVelocity = 0f;
		if(whoScoredPoint == 1)
		{
			transform.position = rightBallSpawnPosition.transform.position;
		} else if(whoScoredPoint == 2)
		{
			transform.position = leftBallSpawnPosition.transform.position;
		}
		FreezeMovement();
	}

	private void FreezeMovement()
	{
		ballRgbd.constraints = RigidbodyConstraints2D.FreezePositionX;
		ballRgbd.constraints = RigidbodyConstraints2D.FreezePositionY;
	}

	private void UnfreezeMovement()
	{
		ballRgbd.constraints = RigidbodyConstraints2D.None;
	}

}
