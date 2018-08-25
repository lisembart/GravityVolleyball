using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleTextBehaviour : MonoBehaviour 
{
	private float rotationZ;

	void Start () 
	{
		rotationZ = 0;
	}
	

	void Update () 
	{
		transform.Rotate(new Vector3(0, 0, rotationZ));
	}
}
