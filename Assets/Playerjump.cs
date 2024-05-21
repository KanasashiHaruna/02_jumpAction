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
    //�Փ˔���--------------------------------------------
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("�Փ˂���");
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("�ڐG��");
        isCanJump = true;

        //�Փ˂��Ă���_�̏�񂪕����i�[����Ă���
        ContactPoint[] contacts= collision.contacts;

        //0�Ԗڂ̏Փˏ�񂩂�A�Փ˂��Ă���_�̖@�����擾]
        Vector3 otherNormal = contacts[0].normal;

        //������������x�N�g��
        Vector3 upVector = new Vector3(0, 1, 0);

        //������Ɩ@���̓���
        float dotUN=Vector3.Dot(upVector,otherNormal);
        //���ϒl�ɋt�O�p�`�֐�arccos�������ĎZ�o
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;

        if (dotDeg <= 45)
        {
            isCanJump = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("���E����");
        isCanJump = false;
    }
}
