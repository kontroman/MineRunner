using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private static float directionZ;
    private Vector3 CenterPosition = new Vector3(0.1f, 0, directionZ);
    private Vector3 LeftPosition = new Vector3(-1.2f, 0, directionZ);
    private Vector3 RightPosition = new Vector3(1.4f, 0, directionZ);
    private int currentLane = 2;

    private GameObject ConstPlayer;
    public GameObject player;
    private Vector3 _move;

    public static float speed = 1;

    private float timer = 15;

    public static int hp = 6;
    public static int armor = 0;

    private void Awake()
    {
        ConstPlayer = GameObject.FindGameObjectWithTag("PlayerConst");
        if(GameController.currentSkin != 0)
        {
            ConstPlayer.GetComponent<Renderer>().material = ShopController.Shop.mat[GameController.currentSkin];
        }
        speed = 1;
    }


    void Update()
    {
        directionZ = player.transform.position.z;
        RightPosition = new Vector3(1.4f, 0, directionZ);
        LeftPosition = new Vector3(-1.2f, 0, directionZ);
        CenterPosition = new Vector3(0.1f, 0, directionZ);
        timer -= Time.deltaTime;
        if (speed <= 1)
            speed = 1;
        if (timer <= 0)
        {
            speed += .1f;
            timer = 15;

        }
        if (transform.localScale.x > 0)
        {
            _move = new Vector3(0, 0, 2);
        }
        player.transform.Translate(_move * speed * Time.deltaTime * 5, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            GetDamage(2);
        }
    }


    void GetDamage(int damage)
    {
        if (armor > 0)
            armor -= 1;
        else
            hp -= damage;

        RunnerController.DrawHP(hp);
        RunnerController.DrawArmor(armor);
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void MoveCharacterLeft()
    {
        if (currentLane == 2)
        {
            player.transform.position = Vector3.MoveTowards(CenterPosition, LeftPosition, 10);
            currentLane = 1;
        }
        if (currentLane == 3)
        {
            player.transform.position = Vector3.MoveTowards(RightPosition, CenterPosition, 10);
            currentLane = 2;
        }
    }

    public void MoveCharacterRight()
    {
        if (currentLane == 2)
        {
            player.transform.position = Vector3.MoveTowards(CenterPosition, RightPosition, 10);
            currentLane = 3;
        }
            if (currentLane == 1)
        {
            player.transform.position = Vector3.MoveTowards(LeftPosition, CenterPosition, 10);
            currentLane = 2;
        }

    }
}
