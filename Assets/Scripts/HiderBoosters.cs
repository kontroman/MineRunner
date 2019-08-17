using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HiderBoosters : MonoBehaviour
{
    public float speed;
    private static Component[] imageComponents;
    private static Component[] textComponents;
    public static GameObject boostersGameObject;

    public static float timeLastUseBooster = 15;

    private void Update()
    {
        timeLastUseBooster -= Time.deltaTime;
        if (timeLastUseBooster <= 0)
        {
            StartCoroutine(HideAllBoosters());
            timeLastUseBooster = 15;
        }
    }

    private void Start()
    {
        boostersGameObject = gameObject;
        imageComponents = gameObject.GetComponentsInChildren<Image>();
        textComponents = gameObject.GetComponentsInChildren<Text>();
    }

    IEnumerator HideAllBoosters()
    {
        StartCoroutine(DeactivateBoosters());
        float time = 0;
        while ( time < 1)
        {
            time += speed;
            foreach (Image image in imageComponents)
            {
                Color _color = image.color;
                _color = new Color(_color.r, _color.g, _color.b, 0);
                image.color = Color.Lerp(image.color, _color, time);
            }
            foreach (Text text in textComponents)
            {
                Color _color = text.color;
                _color = new Color(_color.r, _color.g, _color.b, 0);
                text.color = Color.Lerp(text.color, _color, time);
            }
            yield return null;
        }
    }

    public static IEnumerator ShowAllBoosters()
    {
        foreach (Image image in imageComponents)
        {
            Color _color = image.color;
            _color = new Color(_color.r, _color.g, _color.b, 1);
            image.color = _color;
        }
        foreach (Text text in textComponents)
        {
            Color _color = text.color;
            _color = new Color(_color.r, _color.g, _color.b, 1);
            text.color = _color;
        }
        yield return null;
    }

    IEnumerator DeactivateBoosters()
    {
        yield return new WaitForSeconds(2f);
        boostersGameObject.SetActive(false);
    }
}
