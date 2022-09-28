using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector_ADVController : MonoBehaviour
{
    [SerializeField] private float knockbackStrength;
    public static  Inspector_ADVController instance;

    [Header("Main Settings")]
    public CharacterController TP;
    public Camera TC;
    public Animator TA;
    public GameObject TW1;
    public GameObject TW2;
    public GameObject W1;
    public GameObject W2;
    public float mouseSensitivity = 2f;
    public float PS;
    public float JS;
    public float VerticalSpeed;
    public float Gravity;
    public float upLimit = -50;
    public float downLimit = 50;
    Vector3 moveDirection;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //variable gerak dan rotasi
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");

        //perubahan rotasi brdsrkn mouse
        TP.transform.Rotate(0,horizontalRotation*mouseSensitivity,0);
        TC.transform.Rotate(-verticalRotation*mouseSensitivity,0,0);

        //clam nilai rotasi
        Vector3 currentRotation = TC.transform.localEulerAngles;
        if(currentRotation.x>180) 
        {
            currentRotation.x -= 360;
        }
        currentRotation.x = Mathf.Clamp(currentRotation.x, upLimit, downLimit);
        TC.transform.localRotation = Quaternion.Euler(currentRotation);

        //cek nilai kec loncat/gravitasi
        if(TP.isGrounded) VerticalSpeed=0;
        else VerticalSpeed -=Gravity*Time.deltaTime;
        Vector3 gravityMove = new Vector3(0,VerticalSpeed,0);

        //Var Maju ke depan

        Vector3 move = TP.transform.forward*verticalMove+TP.transform.right*horizontalMove;
        if(Input.GetButton("Jump") ) 
        {
            move.y=JS;
        }
        TP.Move(PS*Time.deltaTime*move+gravityMove*Time.deltaTime);


        //Jalankan Animasi
        if(Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d") ) {
            TA.SetBool("Run",true);
        }
        else {
            TA.SetBool("Run",false);
        }
        if(Input.GetKey("space"))
        {
            TA.SetBool("Jump",true);
        }
        else{
            TA.SetBool("Jump",false);
        }
        if(Input.GetKeyDown("mouse 0"))
        {
            SoundManager.instance.Sword();
            TW1.SetActive(true);
            TW2.SetActive(true);
            W1.SetActive(true);
            W2.SetActive(true);
            TA.SetBool("Atk1",true);
            TA.SetBool("Atk2",true);
            TA.SetBool("Atk3",true);

 
            
        }
        else{
            TA.SetBool("Atk1",false);
            TA.SetBool("Atk2",false);
            TA.SetBool("Atk3",false);
        }
        
    }
    void LateUpdate()
    {
        if(Input.GetKeyUp("mouse 0"))
        {
            Invoke("HideWeaponCollider",1);
        }
    }
    void HideWeaponCollider()
    {
        TW1.SetActive(false);
        TW2.SetActive(false);
        W1.SetActive(false);
        W2.SetActive(false);

        
    }
    private void OnCollisionEnter(Collision col)
        {
            Rigidbody rb = col.collider.GetComponent<Rigidbody>();

            //SoundManager.instance.BallBouncesfx();
            if(col.gameObject.tag == "Enemy" && rb != null)
            {
                TA.SetTrigger("Hurt");
                TA.SetBool("Idle",true);
                Vector3 direction=col.transform.position - transform.position;
                direction.y = 1;
                rb.AddForce(direction.normalized*knockbackStrength, ForceMode.Impulse);
            }
        }
}
