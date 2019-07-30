using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamonds : MonoBehaviour
{
    private GameObject popob;

    void Update()
    {
        gameObject.transform.Rotate(0f, 90f * Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"){
            Destroy(gameObject);
            popob = GameObject.FindGameObjectWithTag("pop");
            popob.gameObject.GetComponent<AudioSource>().Play();
            if (RunnerController.doubleDiamon)
                RunnerController.Diamonds += 2;
            else
                RunnerController.Diamonds++;
        }
        if (other.gameObject.tag == "Enemy")
            Destroy(gameObject);
    }
}
