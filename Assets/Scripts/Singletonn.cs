using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singletonn : MonoBehaviour
{
    private static Singletonn _instance;
    public static Singletonn Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
