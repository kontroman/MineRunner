using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationController : MonoBehaviour
{
    public static GameObject location_Village; //длина 263.2 //263.1 для фореста, не знаю почему
    public static GameObject location_Forest; //длина 262.4
    public static GameObject location_Desert;
    private static GameObject location;
    private static int lastLocation;

    public static Vector3 position;
    private void Start()
    {
        position = new Vector3(0, 0, 262.4f);
        location_Forest = GameObject.FindGameObjectWithTag("Forest");
        location_Village = GameObject.FindGameObjectWithTag("Village");
        location_Desert = GameObject.FindGameObjectWithTag("Desert");
        lastLocation = 0; // 0 - деревня, 1 - лес, 2 - пустыня
    }
    public static void CreateNewLocation()
    {
        int random = Random.Range(0, 3);

        switch (lastLocation)
        {
            case 0:
                position = new Vector3(0, 0, position.z + 263.1f);
                break;
            case 1:
                position = new Vector3(0, 0, position.z + 262.4f);
                break;
            case 2:
                position = new Vector3(0, 0, position.z + 262.4f);
                break;
        }

        switch (random)
        {
            case 0:
                location = location_Village;
                lastLocation = 0;
                break;
            case 1:
                location = location_Forest;
                lastLocation = 1;
                break;
            case 2:
                location = location_Desert;
                lastLocation = 2;
                break;
        }
        Instantiate(location, position, Quaternion.identity);
    }
}
