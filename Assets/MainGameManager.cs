using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainGameManager : MonoBehaviour
{
    [Header("Game Panel")]
    public TextMeshProUGUI BomTxt;
    public GameObject opening;
    public GameObject dialog1;
    public GameObject petunjuk;
    public GameObject gameover;
    public GameObject win;
    public GameObject Switch;
    public GameObject gameplay;
    public int i = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        opening.SetActive(true);
        GameData.instance.Bom = 0;
        GameData.instance.isSwitchOn = false;
        GameData.instance.isOver = false;
        GameData.instance.isWin = false;
    }


       // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("e"))
        {
            i += 1;
        }

        if(i == 1)
        {
            dialog1.SetActive(true);
            opening.SetActive(false);
        }

        if (i == 2)
        {
            petunjuk.SetActive(true);
            dialog1.SetActive(false);
            opening.SetActive(false);
            gameplay.SetActive(false);
        }
        if (i == 3)
        {
            petunjuk.SetActive(false);
            gameplay.SetActive(true);
        }

        if(GameData.instance.Bom == 3){
            opening.SetActive(false);
            gameplay.SetActive(false);
            win.SetActive(true);
            Winner();
        }
        BomTxt.text = GameData.instance.Bom.ToString();
    }

    public void Winner()
    {
        Debug.Log("Selamat Anda Menang");
        StartCoroutine("Winner1");
    }

    private IEnumerator Winner1()
    {
        yield return new WaitForSeconds(10);
        Application.Quit();
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
