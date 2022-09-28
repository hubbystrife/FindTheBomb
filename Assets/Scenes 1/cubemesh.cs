using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubemesh : MonoBehaviour
{
    public GameObject M;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroyer();
        }
    }

    public void Destroyer()
    {
        Debug.Log("Destroooyyy");
        StartCoroutine("Destroyit");
    }

    private IEnumerator Destroyit(){
        yield return new WaitForSeconds(2);
        Destroy(M);
    }

}
