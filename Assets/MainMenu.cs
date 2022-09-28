using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Main Menu Panel List")]
    public GameObject MainPanel;
    public GameObject Splash;
    // Start is called before the first frame update
    void Start()
    {
        MainPanel.SetActive(false);
        Splash.SetActive(true);
        changepanel();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayBtn()
    {
        SceneManager.LoadScene("Gameplay");
        SoundManager.instance.UIClicksfx();
    }

    public void changepanel()
    {
        Debug.Log("Change");
        StartCoroutine("MainmenuPanel");
    }

    private IEnumerator MainmenuPanel()
    {
        yield return new WaitForSeconds(2);
        Splash.SetActive(false);
        MainPanel.SetActive(true);
    }

    
}
