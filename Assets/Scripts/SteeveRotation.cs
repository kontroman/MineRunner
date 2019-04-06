using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeveRotation : MonoBehaviour {

    public static float speed = 70f;

    void Update () {
        gameObject.transform.Rotate(0f, speed * Time.deltaTime, 0f, Space.World);	
	}
}
