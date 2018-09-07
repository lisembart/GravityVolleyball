using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour 
{
	public int playerNumber;
	protected Rigidbody2D playerRgbd;
	protected Collider2D playerCollider;
	protected Collider2D playerDownCollider;
	protected JointMotor2D motor2d = default(JointMotor2D);
	public float jumpFactor;
	public LayerMask groundLayerMask;
	public bool jump;
	public bool grounded;
	public float tekmeFactor = 800f;
	public GameObject tekmebacak;
	GameManager gameManager;
	protected Quaternion orginalRotationValue;
	protected Vector3 orginalPositionValue;
	public Transform spawnPos;
	public AudioSource jumpSource;
	
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

		if(jump)
		{
			if(grounded)
			{
				Debug.Log("Player jumping 3");
				playerRgbd.AddForce(new Vector2(base.transform.up.x, Mathf.Abs(base.transform.up.y)) * this.jumpFactor);
				jump = false;
				Debug.Log("Player jumping 4");
			}
		}
	}

	public void Jump()
	{
		jump = true;
		TekmeCek();
		Debug.Log("Player jumping 1");
	}

	protected void TekmeCek()
	{
		this.motor2d.motorSpeed = this.tekmeFactor;
		this.tekmebacak.GetComponent<HingeJoint2D>().motor = this.motor2d;
		jumpSource.Play();
		Debug.Log("Player jumping 2");
	}

	public void ResetPlayer()
	{
		transform.rotation = orginalRotationValue;
		transform.position = spawnPos.transform.position;
	}
}
