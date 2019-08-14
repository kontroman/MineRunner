using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShaker : MonoBehaviour
{
    public static GameObject _camera;
     
    private void Start()
    {
        _camera = gameObject;
    }

    public IEnumerator ShakeCam(float duration, float magnitude)
    {
        Vector3 originalPos = _camera.transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude * 2;
            //float z = Random.Range(-.1f, .1f) * magnitude;

            _camera.transform.localPosition = new Vector3(x, originalPos.y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }
        _camera.transform.localPosition = originalPos;
    }
}
