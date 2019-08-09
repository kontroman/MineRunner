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
                CreateLineDiamonds(SelectLine(prefabPosition));
        }
    }
    private void Start()
    {
        prefabPosition = new Vector3(0, .4f, 100f);
        diamondSprite = Resources.Load<Sprite>("Textures/diamond");
        CreateThreeLinesDiamonds(prefabPosition);
    }

    public void CreateDiamond(Vector3 position)
    {
        GameObject diamond = new GameObject("diamond") as GameObject;
        diamond.transform.position = position;
        diamond.transform.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        AddComponents(diamond);
    }

    void AddComponents(GameObject target)
    {
        target.AddComponent<BoxCollider>().isTrigger = true;
        target.AddComponent<Rigidbody>().isKinematic = true;
        target.AddComponent<SpriteRenderer>().sprite = diamondSprite;
        target.AddComponent<Diamonds>();
    }

    public void CreateLineDiamonds(Vector3 position)
    {
        for(int i = 0; i < 10; i++)
        {
            CreateDiamond(position);
            position.z += 2;
        }
        prefabPosition.z += 30;
    }

    public void CreateThreeLinesDiamonds(Vector3 position)
    {
        CreateLineDiamonds(new Vector3(1.4f, position.y, position.z));
        CreateLineDiamonds(new Vector3(0f, position.y, position.z));
        CreateLineDiamonds(new Vector3(-1.4f, position.y, position.z));
    }

    public void CreateTwoLinesDiamonds(Vector3 position)
    {
        CreateLineDiamonds(new Vector3(1.4f, position.y, position.z));
        CreateLineDiamonds(new Vector3(-1.4f, position.y, position.z));
    }

    public Vector3 SelectLine(Vector3 position)
    {
        int randomLine = Random.Range(0, 3);
        switch (randomLine)
        {
            case 0: return position;
            case 1: return new Vector3(-1.4f, position.y, position.z);
            case 2: return new Vector3(1.4f, position.y, position.z);
        }
        return position;
    }
}
