using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour 
{
	[Header("Music settings")]
	public AudioSource musicSource;
	public GameObject musicObject;
	public bool musicMuted;
	public Text musicStatusText;

	[Header("Sounds settings")]
	public AudioSource soundsSource;
	public GameObject soundsObject;
	public bool soundsMuted;
	public Text soundsStatusText;

	void Start () 
	{
		if(PlayerPrefs.GetInt("musicMuted") == 1)
		{
			musicMuted = true;
		} else if(PlayerPrefs.GetInt("musicMuted") == 0)
		{
			musicMuted = false;
		}
		SetMusic(musicMuted);

		if(PlayerPrefs.GetInt("soundsMuted") == 1)
		{
			musicMuted = true;
		} else if(PlayerPrefs.GetInt("soundsMuted") == 0)
		{
			soundsMuted = false;
		}
		SetSounds(soundsMuted);
	}

	public void OnMusicChange()
    {
        if (PlayerPrefs.GetInt("musicMuted") == 0)
        {
            PlayerPrefs.SetInt("musicMuted", 1);
			musicMuted = true;
            PlayerPrefs.Save();
        }
        else if (PlayerPrefs.GetInt("musicMuted") == 1)
        {
            PlayerPrefs.SetInt("musicMuted", 0);
			musicMuted = false;
            PlayerPrefs.Save();
        }
		SetMusic(musicMuted);
	}

	public void OnSoundsChange()
    {
        if (PlayerPrefs.GetInt("soundsMuted") == 0)
        {
            PlayerPrefs.SetInt("soundsMuted", 1);
			soundsMuted = true;
            PlayerPrefs.Save();
        }
        else if (PlayerPrefs.GetInt("soundsMuted") == 1)
        {
            PlayerPrefs.SetInt("soundsMuted", 0);
			soundsMuted = false;
            PlayerPrefs.Save();
        }
		SetSounds(soundsMuted);
	}

	public void SetMusic(bool muted)
	{
		if(muted)
		{
			musicObject.SetActive(false);
		} else 
		{
			musicObject.SetActive(true);
		}
	}

	public void SetSounds(bool muted)
	{
		if(muted)
		{
			soundsObject.SetActive(false);
		} else 
		{
			soundsObject.SetActive(true);
		}
	}

	private void Update() 
	{
		if(musicMuted)
		{
			musicStatusText.text = "OFF";
		} else 
		{
			musicStatusText.text = "ON";
		}

		if(soundsMuted)
		{
			soundsStatusText.text = "OFF";
		} else 
		{
			soundsStatusText.text = "ON";
		}
	}
}
