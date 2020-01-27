using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter_area_1 : MonoBehaviour
{
	public AudioClip pop;

    void Start()
    {
		GetComponent<AudioSource>().playOnAwake = false;
		GetComponent<AudioSource>().clip = pop;
    }

    void Update()
    {
        
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.name == "Player")
		{
			GetComponent<AudioSource>().Play();
			Destroy(gameObject , 6f);
		}
	}
}
