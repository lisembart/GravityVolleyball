using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour 
{
	private GameManager gameManager;
	private Rigidbody2D ballRgbd;
	
	public Vector2 moveDirection;
	public int leftPlayerTouchCounter;
	public int rightPlayerTouchCounter;

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
		Physics2D.IgnoreLayerCollision(8,9); //Ignore collision with PlayerBarrier

		if(leftPlayerTouchCounter >= 4)
		{
			gameManager.AddPoint(1);
		} else if(rightPlayerTouchCounter >= 4)
		{
			gameManager.AddPoint(2);
		}
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
		
		if(col.gameObject.tag == "PlayerLeft")
		{
			rightPlayerTouchCounter = 0;
			leftPlayerTouchCounter++;
		}

		if(col.gameObject.tag == "PlayerRight")
		{
			leftPlayerTouchCounter = 0;
			rightPlayerTouchCounter++;
		}
	}

	
	public void ResetBall(int whoScoredPoint)
	{
		ballRgbd.velocity = Vector2.zero;
		ballRgbd.angularVelocity = 0f;
		leftPlayerTouchCounter = 0;
		rightPlayerTouchCounter = 0;
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
		Debug.Log("UNFREEZING BALL");
	}

}
