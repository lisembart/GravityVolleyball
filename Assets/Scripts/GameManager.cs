using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	[Header("Player Objects")]
	public GameObject playerLeft;
	public GameObject playerRight;

	[Header("Other Objects")]
	public GameObject ball;

	[Header("Score Manager")]
	public int leftPlayerScore;
	public int rightPlayerScore;
	public Text scoreText;

	void Start () 
	{
		Time.timeScale = 1;
	}
	

	void Update () 
	{
		string currentSceneNumber = Application.loadedLevelName;
		if(Input.GetKey(KeyCode.O))
		{
			Application.LoadLevel(currentSceneNumber);	
		}

		scoreText.text = (leftPlayerScore + " - " + rightPlayerScore);
	}

	public void AddPoint(int whichPlayer)
	{
		if(whichPlayer == 1)
		{
			rightPlayerScore++;
			Time.timeScale = 0.2f;
			StartCoroutine("SlowTime", 1);
		} else if(whichPlayer == 2)
		{
			leftPlayerScore++;
			Time.timeScale = 0.2f;
			StartCoroutine("SlowTime", 2);
		}
	}

	IEnumerator SlowTime(int whichPlayer)
	{
		yield return new WaitForSeconds(0.15f);
		ReloadGame(whichPlayer);
	}

	private void ReloadGame(int whoScoredPoint)
	{
		ball.SendMessage("ResetBall", whoScoredPoint);
		playerLeft.SendMessage("ResetPlayer");
		playerRight.SendMessage("ResetPlayer");
		Time.timeScale = 1;		
	}
}
