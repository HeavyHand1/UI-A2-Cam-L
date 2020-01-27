using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class HUDController : MonoBehaviour
{
	public Image healthBar;
	public Text redText;
	public Text blueText;
	public Text greenText;
	public int countRed;
	public int countBlue;
	public int countGreen;

	public Image tree;
	public Image cacti;

	public Image xpBar;
	public Text xpText;
	public int countXp;

	public Text stepsText;
	public float countSteps;
	public float DelayAmount = 3f;

	public Text honeyText;
	public int honeyPoints;
	public float xpHoney;

	public GameObject EndMenu;

	public AudioClip step;
	public float stepWait;
	bool keepPlaying = true;

    void Start()
    {
		redText.text = "0";
		blueText.text = "0";
		greenText.text = "0";
		tree.enabled = false;
		cacti.enabled = false;
		xpText.text = "0";
		stepsText.text = "0";
		redText.text = countRed.ToString ();
		xpText.text = countXp.ToString ();
		blueText.text = countBlue.ToString ();
		greenText.text = countGreen.ToString ();
		stepsText.text = countSteps.ToString ("f0");

    }

    void Update()
    {
		healthBar.fillAmount -= 0.01f * Time.deltaTime;
		if (Input.GetKey("w"))
		{
			countSteps += Time.deltaTime*DelayAmount;
			stepsText.text = countSteps.ToString ("f0");
		}

		else
		{
			keepPlaying = false;
		}

		if (Input.GetKeyDown("w"))
		{
			keepPlaying = true;
			StartCoroutine(SoundOut());
		}



		countXp = Mathf.Clamp(countXp, 0, 100);
		if(healthBar.fillAmount <= 0)
		{
			EndMenu.GetComponent<MenuController> ().Timer();
		}
    }

	public void IncrementCountRed()
	{
		countRed++;
		redText.text = countRed.ToString ();
		countXp++;
		xpText.text = countXp.ToString ();
		xpBar.fillAmount += 0.01f;
	}
	public void IncrementCountBlue()
	{
		countBlue++;
		blueText.text = countBlue.ToString ();
		countXp += 3;
		xpText.text = countXp.ToString ();
		xpBar.fillAmount += 0.03f;
	}
	public void IncrementCountGreen()
	{
		countGreen++;
		greenText.text = countGreen.ToString ();
		countXp += 2;
		xpText.text = countXp.ToString ();
		xpBar.fillAmount += 0.02f;
	}

	public void EnterForest()
	{
		tree.enabled = true;
		countXp += 15;
		xpText.text = countXp.ToString ();
		xpBar.fillAmount += 0.15f;
		Destroy (GameObject.FindWithTag("Forest"));
	}
	public void EnterDesert()
	{
		cacti.enabled = true;
		countXp += 15;
		xpBar.fillAmount += 0.15f;
		xpText.text = countXp.ToString ();
		Destroy (GameObject.FindWithTag("Desert"));
	}
		
	public void PickRandom()
	{
		honeyPoints += Random.Range(-countXp, countXp);
		countXp += honeyPoints;
		xpText.text = countXp.ToString ();
		honeyText.text = honeyPoints + " XP POINTS FROM HONEY";
		xpHoney += honeyPoints / 100f;
		xpBar.fillAmount += xpHoney;
		Destroy (honeyText, 5f);
	}

	void Awake() 
	{
		DontDestroyOnLoad (gameObject);
	}

	public IEnumerator SoundOut()
	{
		while (keepPlaying)
		{
			GetComponent<AudioSource>().PlayOneShot(step);
			yield return new WaitForSeconds(stepWait);
		}
	}
}
		