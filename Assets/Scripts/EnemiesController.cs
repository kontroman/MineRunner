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
        directionZ = 60; time = 0.5f;
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            time = 0.3f;
            if(directionZ - PlayerController1.player.transform.position.z <= 100)
            {
                CreateEnemy();
                directionZ += 15;
            }
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
        return new Vector3(CurrentEnemyOffset + Random.Range(MinPos, MaxPos), 0, directionZ);
    }
}
