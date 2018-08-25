﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	[Header("Player Objects")]
	public GameObject playerLeft;
	public GameObject playerRight;
	public GameObject playerCpu;

	[Header("Other Objects")]
	public GameObject ball;
	public float time = 1;

	[Header("Score Manager")]
	public bool endlessGame;
	public int leftPlayerScore;
	public int rightPlayerScore;
	public Text scoreText;
	public GameObject scoreTextObject;
	public bool allowToAddPoint;
	private int currentGameMode;

	[Header("Match End")]
	public GameObject matchEndCanvas;
	public Text whoWonText;
	public Text endScoreText;

	[Header("Ads")]
	private AdsManager AdsManager;

	[Header("Main Menu")]
	public GameObject mainMenuObject;
	public GameObject gameObjects;

	void Start () 
	{
		gameObjects.SetActive(false);
		currentGameMode = 0;
	}

	public void StartVsCpu()
	{
		playerCpu.SetActive(true);
		playerRight.SetActive(false);
		currentGameMode = 1;
		SetGame();
	}

	public void StartVsPlayer()
	{
		playerRight.SetActive(true);
		playerCpu.SetActive(false);
		currentGameMode = 2;
		SetGame();
	}

	private void SetGame()
	{
		mainMenuObject.SetActive(false);
		gameObjects.SetActive(true);
		Time.timeScale = 1;
		allowToAddPoint = true;
		playerLeft.SetActive(true);
	}

	public void Rematch()
	{
		if(currentGameMode == 1)
		{
			StartVsCpu();
		} else if(currentGameMode == 2)
		{
			StartVsPlayer();
		}
	}

	public void SetEndless(bool endless)
	{
		endlessGame = endless;
	}

	void Update () 
	{
		string currentSceneNumber = Application.loadedLevelName;
		if(Input.GetKey(KeyCode.O))
		{
			Application.LoadLevel(currentSceneNumber);	
		}

		scoreText.text = (leftPlayerScore + " - " + rightPlayerScore);

		if(!endlessGame)
		{
			if(leftPlayerScore == 5 || rightPlayerScore == 5)
			{
				MatchEnd();
			}
		}
	}

	public void MatchEnd()
	{
		matchEndCanvas.SetActive(true);
		ball.SetActive(false);
		scoreTextObject.SetActive(false);
		if(leftPlayerScore == 5)
		{
			whoWonText.text = "BLUE WINS";
		} else 
		{
			whoWonText.text = "RED WINS";
		}
		endScoreText.text = scoreText.text;
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
		playerCpu.SendMessage("ResetPlayer");
	}

	private void ReloadSettings()
	{
		Time.timeScale = 1;
		allowToAddPoint = true;
		Debug.Log("RELOADING SETTINGS");
	}
}
