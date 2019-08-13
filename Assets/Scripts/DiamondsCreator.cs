using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class DiamondsCreator : MonoBehaviour
{
    private Vector3 prefabPosition;
    private Sprite diamondSprite;
    private float time = 1;

    public DiamondsCreator() { }

    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = 1;
            if (prefabPosition.z - PlayerController1.player.transform.position.z <= 100)
                SelectTypeOfDiamonds();
        }
    }
    private void Start()
    {
        prefabPosition = new Vector3(0, .4f, 95f);
        diamondSprite = Resources.Load<Sprite>("Textures/diamond");
    }

    public void CreateDiamond(Vector3 position)  // создает 1 алмазик
    {
        GameObject diamond = new GameObject("diamond") as GameObject;
        diamond.transform.position = position;
        diamond.transform.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        AddComponents(diamond);
    }

    void AddComponents(GameObject target) // добавляет нужные штуки на алмазик
    {
        target.AddComponent<BoxCollider>().isTrigger = true;
        target.AddComponent<Rigidbody>().isKinematic = true;
        target.AddComponent<SpriteRenderer>().sprite = diamondSprite;
        target.AddComponent<Diamonds>();
    }

    public void CreateLineDiamonds(Vector3 position) //создать одну линию из 10 алмазиков
    {
        for(int i = 0; i < 10; i++)
        {
            CreateDiamond(position);
            position.z += 2;
        }
    }

    public void CreateThreeLinesDiamonds(Vector3 position) //создать 3 линии алмазиков
    {
        CreateLineDiamonds(new Vector3(1.4f, position.y, position.z));
        CreateLineDiamonds(new Vector3(0f, position.y, position.z));
        CreateLineDiamonds(new Vector3(-1.4f, position.y, position.z));
    }

    public void CreateTwoLinesDiamonds(Vector3 position) //создать 2 линии алмазиков
    {
        // сейчас херня, но я не знаю как сделать лучше что бы 
        // выбирались 2 рандомные линии, тк в SelectLine при вызове 
        // они могут наложиться друг на друга

        int line = Random.Range(0, 3);
        switch (line)
        {
            case 0:
                CreateLineDiamonds(new Vector3(1.4f, position.y, position.z));
                CreateLineDiamonds(new Vector3(-1.4f, position.y, position.z));
                break;
            case 1:
                CreateLineDiamonds(new Vector3(0f, position.y, position.z));
                CreateLineDiamonds(new Vector3(-1.4f, position.y, position.z));
                break;
            case 2:
                CreateLineDiamonds(new Vector3(1.4f, position.y, position.z));
                CreateLineDiamonds(new Vector3(0f, position.y, position.z));
                break;
        }
    }

    public Vector3 SelectLine(Vector3 position) //выбрать одну линию из трех на дороге
    {
        int rLine = Random.Range(0, 3);
        switch (rLine)
        {
            case 0: return position;
            case 1: return new Vector3(-1.4f, position.y, position.z);
            case 2: return new Vector3(1.4f, position.y, position.z);
        }
        return position;
    }

    private void SelectTypeOfDiamonds() //выбираем сколько "линий" создавать
    {
        int rPref = Random.Range(0, 10);
        if (rPref < 4)
            CreateLineDiamonds(SelectLine(prefabPosition));
        else if (rPref < 9)
            CreateTwoLinesDiamonds(prefabPosition);
        else CreateThreeLinesDiamonds(prefabPosition);
        prefabPosition.z += 30;
    }
}
