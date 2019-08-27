using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public GameObject chest;

    private void PlayAnimation()
    {
        chest.GetComponent<Animator>().enabled = true;
    }

}
