using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour 
{
	public GameObject mainMenuObject;
	public GameObject optionsMenuObject;
	public GameObject infoMenuObject;
	[SerializeField] private GameManager gameManager;

	private void Start() 
	{
		optionsMenuObject.SetActive(false);
		infoMenuObject.SetActive(false);
		mainMenuObject.SetActive(true);
	}

	public void GoToOptions()
	{
		mainMenuObject.SetActive(false);
		optionsMenuObject.SetActive(true);
		gameManager.DestroyBanner();
	}

	public void GoToInfo()
	{
		mainMenuObject.SetActive(false);
		infoMenuObject.SetActive(true);
		gameManager.SendMessage("DestroyBanner");
	}

	public void BackToMainMenu()
	{
		if(optionsMenuObject.active = true)
		{
			optionsMenuObject.SetActive(false);
		} 
		if(infoMenuObject.active = true)
		{
			infoMenuObject.SetActive(false);
		}
		mainMenuObject.SetActive(true);
		gameManager.SendMessage("RequestBanner");
	}
}
