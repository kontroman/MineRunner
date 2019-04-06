using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiamondController : MonoBehaviour
{
    private float time = 1;

    public GameObject prefabCenter;
    public GameObject prefabLeft;
    public GameObject prefabRight;
    public int random;

    private static float directionZ = 98;

    private Vector3 LeftSide = new Vector3(-1.5f, 0.4f, directionZ);
    private Vector3 CenterSide = new Vector3(0f, 0.4f, directionZ);
    private Vector3 RightSide = new Vector3(1.5f, 0.4f, directionZ);

    private int SelectPrefabInt;


    private void CreateDiamondLine()
    {
        Instantiate(SelectPrefab(), SelectDirection(), Quaternion.identity);
    }

    private Vector3 SelectDirection() //на какую линию его пихаем
    {
        LeftSide = new Vector3(-1.4f, 0.4f, directionZ);
        CenterSide = new Vector3(0f, 0.4f, directionZ);
        RightSide = new Vector3(1.4f, 0.4f, directionZ);
        Vector3 direction = new Vector3(0f, 0f, directionZ);
        int random2;
        switch (random)
        {
            case 1:
                random2 = Random.Range(1, 3);
                switch (random2)
                {
                    case 1:
                        direction = RightSide;
                        break;
                    case 2:
                        direction = CenterSide;
                        break;
                }
                break;
            case 2:
                random2 = Random.Range(1, 4);
                switch (random2)
                {
                    case 1:
                        direction = LeftSide;
                        break;
                    case 2:
                        direction = CenterSide;
                        break;
                    case 3:
                        direction = RightSide;
                        break;
                }
                break;
            case 3:
                random2 = Random.Range(1, 3);
                switch (random2)
                {
                    case 1:
                        direction = LeftSide;
                        break;
                    case 2:
                        direction = CenterSide;
                        break;
                }
                break;
        }
        return direction;
    }

    private GameObject SelectPrefab() // какой из трех префабов создаем
    {
        random = Random.Range(1, 4);
        GameObject SelectedObject = prefabCenter;
        switch (random)
        {
            case 1:
                SelectedObject = prefabLeft;
                break;
            case 2:
                SelectedObject = prefabCenter;
                break;
            case 3:
                SelectedObject = prefabRight;
                break;
        }
        return SelectedObject;
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            time = 1;
            CreateDiamondLine();
            directionZ += 30f;
        }
    }

    private void Start()
    {
        directionZ = 98;
    }
}
