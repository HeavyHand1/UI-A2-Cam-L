using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Collectable : MonoBehaviour
{
	public AudioClip pick;
	public static bool GameIsPaused = false;
	public GameObject HUD;
	public GameObject PopUp;
	public GameObject HUDctrl;
	public GameObject Camera;
	public GameObject Info;

	void Start()
	{
		GetComponent<AudioSource>().playOnAwake = false;
		GetComponent<AudioSource>().clip = pick;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.name == "Player")
		{
			GetComponent<AudioSource>().Play();
			if (GameIsPaused)
			{
				PickUp();
				Drop();
				Examine();
			}
			else
			{
				Pause();
			}
		
		}
	}

	public void PickUp ()
	{
		PopUp.SetActive(false);
		HUD.SetActive(true);
		GameIsPaused = false;
		Time.timeScale = 1f;
		HUDctrl.GetComponent<HUDController> ().PickRandom();
		Camera.GetComponent<Camera_Rotate>().Paused = true;
		Destroy(gameObject, 0.1f);
	}
	public void Pause ()
	{
		PopUp.SetActive(true);
		HUD.SetActive(false);
		Info.SetActive(false);
		Camera.GetComponent<Camera_Rotate>().Paused = false;
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void Drop ()
	{
		PopUp.SetActive(false);
		HUD.SetActive(true);
		GameIsPaused = false;
		Camera.GetComponent<Camera_Rotate>().Paused = true;
		Time.timeScale = 1f;

	}

	public void Examine ()
	{
		Info.SetActive(true);
	}
}
