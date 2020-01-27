using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScores : MonoBehaviour
{
	public Text redText;
	public Text blueText;
	public Text greenText;
	public Text xpText;
	public Text stepsText;
	public Text nameText;

    void Start()
    {
		GameObject HUDCtrl = GameObject.Find("HUDController");
		HUDController HUD = HUDCtrl.GetComponent<HUDController>();
		redText.text = HUD.countRed.ToString ();
		xpText.text = HUD.countXp.ToString ();
		blueText.text = HUD.countBlue.ToString ();
		greenText.text = HUD.countGreen.ToString ();
		stepsText.text = HUD.countSteps.ToString ("f0");

		GameObject Name = GameObject.Find("Naming");
		EnterName Named = Name.GetComponent<EnterName>();
		nameText.text = Named.name.ToString ();
    }

    void Update()
    {
        
    }
}
