using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCameraDowner : MonoBehaviour
{

    private Vector3 target = new Vector3(0.1f, 2.15f, 4.49f);
    private Vector3 native = new Vector3(0.1f, 3.84f, 5.19f);

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "TreeCam")
        {
            transform.Translate(target * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "TreeCam")
        {
            transform.Translate(native * Time.deltaTime);
        }
    }
}
