using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tenggelem : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject aer;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            GameOver.SetActive(true);

            GameData.instance.isOver = true;
        }
    }

    void update (){
        if(GameData.instance.isSwitchOn == true){
            aer.SetActive(false);
        }
    }
    public void YaBtn ()
        {
            aer.SetActive(false);
            
        }

    public void TidakBtn ()
        {
            aer.SetActive(true);
        }


}
