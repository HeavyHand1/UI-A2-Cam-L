using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Rotate : MonoBehaviour
{
	public float sensitivity = 10f;
	public float maxYAngle = 80f;
	private Vector2 currentRotation;
	public bool Paused = true;
    void Start()
    {
        
    }

    public void Update()
    {
		if (Paused)
		{
			currentRotation.x += Input.GetAxis("Mouse X") * sensitivity;
		currentRotation.y -= Input.GetAxis("Mouse Y") * sensitivity;
		currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
		currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
		transform.rotation = Quaternion.Euler(currentRotation.y,currentRotation.x,0);

		}
		}
}
