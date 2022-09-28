using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Switch : MonoBehaviour
{
    public static Switch instance;
    public GameObject S;
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player"){
            S.SetActive(true);
        }
    }

    public void Close ()
        {
            S.SetActive(false);
        }


}
