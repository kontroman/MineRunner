using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

    private void Update()
    {
        gameObject.transform.Translate(new Vector3(0,0,2) * 1 * Time.deltaTime * 5, Space.World);
    }

}
