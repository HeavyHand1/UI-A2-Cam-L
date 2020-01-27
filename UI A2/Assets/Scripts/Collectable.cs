using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Bottle : MonoBehaviour
{
    

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Destroy(gameObject);
        }
    }
}
