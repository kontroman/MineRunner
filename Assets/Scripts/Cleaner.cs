using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Location")
            Destroy(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Location")
        {
            Debug.Log("DESTROYING LOCATION");
            Destroy(other.gameObject);
            LocationController.CreateNewLocation();
        }
    }

    private void Update()
    {
        gameObject.transform.Translate(new Vector3(0,0,2) * PlayerController1.speed * Time.deltaTime * 5, Space.World);
    }

}
