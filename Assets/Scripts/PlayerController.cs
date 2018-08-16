using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public int playerNumber;
	private Rigidbody2D playerRgbd;
	private JointMotor2D motor2d = default(JointMotor2D);
	public float jumpFactor;
	public float tekmeFactor = 800f;
	public GameObject tekmebacak;
	GameManager gameManager;

	void Start () 
	{
		playerRgbd = GetComponent<Rigidbody2D>();
		gameManager = FindObjectOfType<GameManager>();
	}
	

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space) && playerNumber == 1)
		{
			Jump();
		}

		if(Input.GetKeyDown(KeyCode.F) && playerNumber == 2)
		{
			Jump();
		}
	}

	public void Jump()
	{
		playerRgbd.AddForce(new Vector2(base.transform.up.x, Mathf.Abs(base.transform.up.y)) * this.jumpFactor);
		TekmeCek();
	}

	private void TekmeCek()
	{
		this.motor2d.motorSpeed = this.tekmeFactor;
		this.tekmebacak.GetComponent<HingeJoint2D>().motor = this.motor2d;
	}

	public void ResetPlayer()
	{
		
	}

	private void OnTriggerEnter2D(Collider2D col) 
	{
		if(col.gameObject.tag == "Ball")
		{
			col.gameObject.SendMessage("UnfreezeMovement");
		}	
	}
}
