using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Camera Camera;
    public NavMeshAgent agent;
    RaycastHit hit;
    Animator myAnim;
    float dist;
    Quaternion newRotation;
    float rotSpeed = 5f;

    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    void Update()
    {

		if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        }

        dist = Vector3.Distance(hit.point, transform.position);

        if (dist < 1f)
        {
            myAnim.SetBool("isRunning", false);
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotSpeed * Time.deltaTime);
    }

	public GameObject HUDctrl;

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Red")
		{
			HUDctrl.GetComponent<HUDController> ().IncrementCountRed();
		}
		else if (other.gameObject.tag == "Blue")
		{
			HUDctrl.GetComponent<HUDController> ().IncrementCountBlue();
		}
		else if (other.gameObject.tag == "Green")
		{
			HUDctrl.GetComponent<HUDController> ().IncrementCountGreen();
		}
		else if (other.gameObject.tag == "Forest")
		{
			HUDctrl.GetComponent<HUDController> ().EnterForest();
		}
		else if (other.gameObject.tag == "Desert")
		{
			HUDctrl.GetComponent<HUDController> ().EnterDesert();
		}
	}
		
}

public class NavMeshAgent
{
    internal void SetDestination(Vector3 point)
    {
        throw new NotImplementedException();
    }
}