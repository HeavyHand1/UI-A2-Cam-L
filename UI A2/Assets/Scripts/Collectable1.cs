using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable1 : MonoBehaviour
{
	public AudioClip pick;
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
			Destroy(gameObject, 0.1f);
        }
    }

}
