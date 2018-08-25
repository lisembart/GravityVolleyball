﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public int playerNumber;
	private Rigidbody2D playerRgbd;
	public Collider2D playerCollider;
	public Collider2D playerDownCollider;
	private JointMotor2D motor2d = default(JointMotor2D);
	public float jumpFactor;
	public LayerMask groundLayerMask;
	public bool jump;
	public bool grounded;
	public float tekmeFactor = 800f;
	public GameObject tekmebacak;
	GameManager gameManager;
	private Quaternion orginalRotationValue;
	private Vector3 orginalPositionValue;
	public Transform spawnPos;

	void Start () 
	{
		playerRgbd = GetComponent<Rigidbody2D>();
		playerCollider = GetComponent<PolygonCollider2D>();
		playerDownCollider = GetComponent<CircleCollider2D>();
		gameManager = FindObjectOfType<GameManager>();
		orginalRotationValue = transform.rotation;
		orginalPositionValue = new Vector3(transform.position.x, transform.position.y, transform.position.y);
	}
	

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

	public void Jump()
	{
		jump = true;
		TekmeCek();
	}

	private void TekmeCek()
	{
		this.motor2d.motorSpeed = this.tekmeFactor;
		this.tekmebacak.GetComponent<HingeJoint2D>().motor = this.motor2d;
	}

	public void ResetPlayer()
	{
		transform.rotation = orginalRotationValue;
		transform.position = spawnPos.transform.position;
	}
}
