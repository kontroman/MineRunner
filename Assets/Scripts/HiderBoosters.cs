using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiderBoosters : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(HideAllBoosters(transform));
    }

    IEnumerator HideAllBoosters(Transform _object)
    {
        foreach (Transform child in _object.transform)
        {
            Debug.Log(child.GetType());
                Color _color = child.GetComponent<Image>().color;
                _color = new Color(_color.r, _color.g, _color.b, 0);
                StartCoroutine(HideAllBoosters(child));
                //Text _text = child.GetComponent<Text>();
                //_text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 0);
        }
        yield return null;
    }

    IEnumerator ShowAllBoosters(Transform _object)
    {
        foreach(Transform child in _object.transform)
        {
            Color _color = child.GetComponent<Image>().color;
            _color = new Color(_color.r, _color.g, _color.b, 255);
            StartCoroutine(ShowAllBoosters(child));
        }
        yield return null;
    }
}
