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
	public float time = 1;

	[Header("Score Manager")]
	public int leftPlayerScore;
	public int rightPlayerScore;
	public Text scoreText;
	public bool allowToAddPoint;

	void Start () 
	{
		Time.timeScale = 1;
		allowToAddPoint = true;
	}
	

	void Update () 
	{
		string currentSceneNumber = Application.loadedLevelName;
		if(Input.GetKey(KeyCode.O))
		{
			Application.LoadLevel(currentSceneNumber);	
		}

		scoreText.text = (leftPlayerScore + " - " + rightPlayerScore);
		//Time.timeScale = time;
	}

	public void AddPoint(int whichPlayer)
	{
		if(allowToAddPoint)
		{
			if(whichPlayer == 1)
			{
				rightPlayerScore++;
				StartCoroutine("SlowTime", 1);
				allowToAddPoint = false;
			} else if(whichPlayer == 2)
			{
				leftPlayerScore++;
				StartCoroutine("SlowTime", 2);
				allowToAddPoint = false;
			}
		}
	}

	IEnumerator SlowTime(int whichPlayer)
	{
		Time.timeScale = 0.3f;
		yield return new WaitForSeconds(0.2f);
		ReloadGame(whichPlayer);
		ReloadSettings();
	}

	private void ReloadGame(int whoScoredPoint)
	{
		ball.SendMessage("ResetBall", whoScoredPoint);
		playerLeft.SendMessage("ResetPlayer");
		playerRight.SendMessage("ResetPlayer");
	}

	private void ReloadSettings()
	{
		Time.timeScale = 1;
		allowToAddPoint = true;
		Debug.Log("RELOADING SETTINGS");
	}
}
