using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tests : MonoBehaviour 
{
	public GameObject ballPrefab;
	public Transform ballSpawnPos;

	void Start () 
	{
		
	}
	

	void Update () 
	{
		if(Input.GetKey(KeyCode.P))
		{
			Instantiate(ballPrefab, ballSpawnPos.transform);
		}
	}
}
