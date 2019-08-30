using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public CamShaker camShaker;
    private static float directionZ;
    public static Vector3 CenterPosition = new Vector3(0.1f, 0, directionZ);
    public static Vector3 LeftPosition = new Vector3(-1.3f, 0, directionZ);
    public static Vector3 RightPosition = new Vector3(1.5f, 0, directionZ);
    //private int currentLane = 2; по консоли нигде не юзается

    private GameObject ConstPlayer;
    public static GameObject player;
    private Vector3 _move;

    public static float speed = 1;

    private float timer = 15;

    public static int hp = 6;
    public static int armor = 0;

    public  Rigidbody rb;

    private AudioSource _as;
    private void Awake()
    {
        ConstPlayer = GameObject.FindGameObjectWithTag("PlayerConst");
        if (GameController.currentSkin != 0)
            ConstPlayer.GetComponent<Renderer>().material = ShopController.Shop.mat[GameController.currentSkin];
        speed = 1;
    }

    private void Start()
    {
        _as = gameObject.GetComponent<AudioSource>();
        hp = 6;
        armor = 0;
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetPositions();
                timer -= Time.deltaTime;
        if (speed <= 1)
            speed = 1;
        if (timer <= 0)
        {
            if (speed < 1.6)
            {
                speed += .1f;
                timer = 20;
            }

        }
        if (transform.localScale.x > 0)
        {
            _move = new Vector3(0, 0, 2);
        }
        player.transform.Translate(_move * speed * Time.deltaTime * 5, Space.World);
        SetPositions();
    }

    void SetPositions()
    {
        directionZ = player.transform.position.z;
        RightPosition = new Vector3(1.4f, 0, directionZ);
        LeftPosition = new Vector3(-1.2f, 0, directionZ);
        CenterPosition = new Vector3(0.1f, 0, directionZ);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            GetDamage(2);
            StartCoroutine(camShaker.ShakeCam(0.15f, 0.2f));
        }
        if(other.gameObject.tag == "TNT")
        {
            armor = 0;
            hp = 0;
            GameObject.FindGameObjectWithTag("TNTSOUND").GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }
    }


    void GetDamage(int damage)
    {
        PlayHitAudio();
        if (armor > 0)
            armor -= damage;
        else
            hp -= damage;

        RunnerController.DrawHP(hp);
        RunnerController.DrawArmor(armor);
    }

    void PlayHitAudio()
    {
        _as.Play();
    }

}
