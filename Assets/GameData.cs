using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameData : MonoBehaviour
{
    public static GameData instance;

    public float Bom;
    public bool isSwitchOn = false;
    public bool isOver = false;
    public bool isWin = false;



    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }   

}
