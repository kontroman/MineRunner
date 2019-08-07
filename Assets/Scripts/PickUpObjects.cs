using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    public bool positiveObject;
    private GameObject GameObject;

    PickUpObjects(GameObject go, bool positiveness)
    {
        GameObject = go;
        positiveObject = positiveness;
    }

}
