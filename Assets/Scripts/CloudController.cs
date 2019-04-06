using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.Translate(0.03f * Vector3.left);
        if(gameObject.transform.position.x < -60)
        {
            gameObject.transform.position = new Vector3(40f, transform.position.y, transform.position.z);
        }
    }
}





        // АНИМАЦИЯ ОДНОЙ КООРДИНАТЫ