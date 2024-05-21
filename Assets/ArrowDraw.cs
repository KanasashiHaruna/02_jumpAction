using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;


public class ArrowDraw : MonoBehaviour
{
    [SerializeField]
   public Image arrowImage;
   private Vector3 clickposition;

// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            clickposition = Input.mousePosition;
            arrowImage.gameObject.SetActive(true);
        }
        if(Input.GetMouseButton(0)) { 
           Vector3 dist=clickposition-Input.mousePosition;
            // Debug.Log(dist);
            //�x�N�g���̒������Z�o
            float size = dist.magnitude;
            //�x�N�g������p�x���Z�o
            float angleRad=Mathf.Atan2(dist.y, dist.x);
            //���̉摜���N���b�N�����ꏊ�ɉ摜���ړ�
            arrowImage.rectTransform.position =  clickposition;
            //���̉摜���x�N�g������Z�o�����p�x��x���@�ɕϊ����Ă�����]
            arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);
            //���̉摜�̑傫�����h���b�O���������ɍ��킹��
                arrowImage.rectTransform.sizeDelta=new Vector2(size, size);
        }
        if(Input.GetMouseButtonUp(0))
        {
            arrowImage.gameObject.SetActive(false);
        }
    }
}
