using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterName : MonoBehaviour
{
	public InputField nameInput;
	public string name;

    void Start()
    {
		if (nameInput != null)
		{
			nameInput.text = name;
		}
    }

    public void SaveName(string newName)
    {
		name = newName;
    }

	public void Update()
	{

	}

	void Awake()
	{
		DontDestroyOnLoad (gameObject);
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
	}
}
