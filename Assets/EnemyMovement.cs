using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [Header("Main Setting")]
    public Animator anim;
    public float lookRadius = 50f;
    public NavMeshAgent enemy;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(Player.position, transform.position);
        Vector3 temp = Player.transform.position;
        if (distance <= lookRadius)
        {
            temp.y =  transform.position.y;
            transform.LookAt(temp);
            enemy.SetDestination(Player.position);
            if (temp != Vector3.zero  )
            {
                anim.SetBool("Seek",true);
            }
            else {
                anim.SetBool("Seek",false);
            }
        }
        if (distance <= 10f)
        {
            anim.SetBool("Attack",true);
        }
        
        
    }
}
