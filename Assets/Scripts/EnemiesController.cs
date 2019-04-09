using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    public GameObject TNT;
    public GameObject LEAVES_RIGHT;
    public GameObject LEAVES_LEFT;
    public GameObject FENCH_LONG;
    public GameObject FENCH_MIDDLE;
    public GameObject CACTUS;
    public GameObject SNOWMAN;
    public GameObject WEB;

    private int random;


    private float time = 0.5f;
    private static float directionZ = 42;

    private void Start()
    {
        directionZ = 42; time = 0.5f;
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            time = 0.3f;
            CreateEnemy();
            directionZ += 12;
        }
    }

    void CreateEnemy()
    {
        Instantiate(SelectEnemy(), SelectDirection(), Quaternion.identity);
    }

    GameObject SelectEnemy()
    {
        random = Random.Range(0, 7);
        GameObject Enemy = null;
        switch (random)
        {
            case 0:
                Enemy = TNT;
                break;
            case 1:
                Enemy = LEAVES_RIGHT;
                break;
            case 2:
                Enemy = LEAVES_LEFT;
                break;
            case 3:
                Enemy = FENCH_LONG;
                break;
            case 4:
                Enemy = FENCH_MIDDLE;
                break;
            case 5:
                Enemy = CACTUS;
                break;
            case 6:
                Enemy = WEB;
                break;
        }

        return Enemy;
    }

    Vector3 SelectDirection()
    {
        Vector3 direction = new Vector3(0, 0, directionZ);
        int SecondWayRandom = 0;
        switch (random)
        {
            case 0:
                SecondWayRandom = Random.Range(0, 3);
                switch (SecondWayRandom)
                {
                    case 0:
                        direction = new Vector3(-1.4f, -0.15f, directionZ);
                        break;
                    case 1:
                        direction = new Vector3(0, -0.15f, directionZ);
                        break;
                    case 2:
                        direction = new Vector3(1.5f, -0.15f, directionZ);
                        break;
                }
                break;
            case 1:
                direction = new Vector3(1.6f, 0.35f, directionZ);
                break;
            case 2:
                direction = new Vector3(-1.6f, 0.35f, directionZ);
                break;
            case 3:
                SecondWayRandom = Random.Range(0, 2);
                switch (SecondWayRandom)
                {
                    case 0:
                        direction = new Vector3(0, 0.5f, directionZ);
                        break;
                    case 1:
                        direction = new Vector3(2.6f, 0.5f, directionZ);
                        break;
                }
                break;
            case 4:
                direction = new Vector3(0, 0.5f, directionZ);
                break;
            case 5:
                SecondWayRandom = Random.Range(0, 3);
                switch (SecondWayRandom)
                {
                    case 0:
                        direction = new Vector3(0, 1.25f, directionZ);
                        break;
                    case 1:
                        direction = new Vector3(-1.4f, 1.25f, directionZ);
                        break;
                    case 2:
                        direction = new Vector3(1.5f, 1.25f, directionZ);
                        break;
                }
                break;
            case 6:
                direction = new Vector3(0f, 0.5f, directionZ);
                break;
        }

        return direction;
    }
}
