using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	public GameObject Char1;
	public GameObject Char2;
	public GameObject Char3;
	bool charNum = true;

	public void PlayGame()
	{
		if (charNum)
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}
	}

	public void QuitGame()
	{
		Application.Quit();
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

	public void Timer()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void Replay()
	{
		GameObject HUDCtrl = GameObject.Find("HUDController");
		HUDController HUD = HUDCtrl.GetComponent<HUDController>();
		Destroy(HUD.gameObject);
		SceneManager.LoadScene ("UI_level");
	}

	public void Menu()
	{
		SceneManager.LoadScene ("Main_Menu");
	}
		
    void Start()
    {
        
    }

    void Update()
    {
        
    }

	public void SelectOne()
	{
		charNum = true;
		Char1.SetActive(true);
		Char2.SetActive(false);
		Char3.SetActive(false);
	}

	public void SelectTwo()
	{
		charNum = false;
		Char1.SetActive(false);
		Char2.SetActive(true);
		Char3.SetActive(false);
	}

	public void SelectThree()
	{
		charNum = false;
		Char1.SetActive(false);
		Char2.SetActive(false);
		Char3.SetActive(true);
	}
}
