using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour 
{
	public GameObject mainMenuObject;
	public GameObject optionsMenuObject;
	public GameObject infoMenuObject;

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
	}

	public void GoToInfo()
	{
		mainMenuObject.SetActive(false);
		infoMenuObject.SetActive(true);
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
	}
}
