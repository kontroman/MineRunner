using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadWTF : MonoBehaviour
{
    private void Update()
    {
        gameObject.transform.Translate(new Vector3(0, 0, 2) * PlayerController1.speed * Time.deltaTime * 5, Space.World);
    }
}
