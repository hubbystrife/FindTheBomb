using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomScrpt : MonoBehaviour
{
    public GameObject bomb;

    void OnTriggerEnter(Collider col)
    {
        
        if(col.gameObject.tag == "Player")
        {
            
            GameData.instance.Bom++;
            Destroy(bomb);
            
        }
    }
    

}
