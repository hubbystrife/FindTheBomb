using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalMouse1 : MonoBehaviour
{
    public Transform T;
    public float Jarak = 5.0f;
    public float kecY = 120.0f;
    public float kecX = 120.0f;
    public float Yminlimit = -20.0f;
    public float Ymaxlimit =  80.0f;
    public float jarakMin =  0.5f;
    public float jarakMax = 15.0f;
    private Rigidbody RB;
    float x= 0f;
    float y = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 angle = transform.eulerAngles;
        x =  angle.y;
        y = angle.x;
        RB = GetComponent<Rigidbody>();
        if (RB != null){
            RB.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        x += Input.GetAxis("Mouse X")*kecX*Jarak*0.02f;
        Quaternion rotation=Quaternion.Euler(y,x,0);
        Vector3 Jarakneg = new Vector3 (0.0f,0.0f,-Jarak);
        Vector3 Posisi = rotation * Jarakneg + T.position;
        transform.rotation=rotation;
        transform.position=Posisi;
    }
    public static float ClampAngle(float A, float min, float max)
    {
        if (A < -360F)
        {
            A += 360F;
        }
        if (A > 360F)
        {
            A -= 360F;
        }
        return Mathf.Clamp(A,min,max);
    }
}
