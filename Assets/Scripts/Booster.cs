using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Booster : MonoBehaviour
{
    private int _boosterCount;
    private BoosterType _type;
    private int _boosterPrice;

    public int GetPrice { get { return _boosterPrice; } }
    public int GetCount { get { return _boosterCount; } }

    public void AddBooster()
    {
        _boosterCount += 1;
    }

    public void UseBooster()
    {
        if (_boosterCount <= 0) return;

        _boosterCount -= 1;

        _type.Effect.Activate();
    }
}