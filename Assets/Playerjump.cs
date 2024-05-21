using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerjump : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()//------------------------------------------
    {
        rb=gameObject.GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0,-9.8f, 0);
    }

    // Update is called once per frame
    private Vector3 clickPosition;
    private float jumpPower = 10;
    private bool isCanJump;

    void Update()//------------------------------------------
    {
        //if(Input.GetKeyDown(KeyCode.Space)) { 
        //     rb.velocity = new Vector3(0,10,0);
        //}
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
        }
        if (isCanJump && Input.GetMouseButtonUp(0))
        {
            Vector3 dist =clickPosition-Input.mousePosition;
            if (dist.sqrMagnitude == 0) { return; }
            rb.velocity=dist.normalized*jumpPower;
        }
    }
    //衝突判定--------------------------------------------
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("衝突した");
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("接触中");
        isCanJump = true;

        //衝突している点の情報が複数格納されている
        ContactPoint[] contacts= collision.contacts;

        //0番目の衝突情報から、衝突している点の法線を取得]
        Vector3 otherNormal = contacts[0].normal;

        //上方向を示すベクトル
        Vector3 upVector = new Vector3(0, 1, 0);

        //上方向と法線の内積
        float dotUN=Vector3.Dot(upVector,otherNormal);
        //内積値に逆三角形関数arccosをかけて算出
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;

        if (dotDeg <= 45)
        {
            isCanJump = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("離脱した");
        isCanJump = false;
    }
}
