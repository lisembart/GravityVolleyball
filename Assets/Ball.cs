using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour 
{
	public Transform spawnPos;

	void Start () 
	{
		
	}
	

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.P))
		{
			transform.position = spawnPos.transform.position;
		}
	}
}
