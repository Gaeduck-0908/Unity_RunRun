using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObj : MonoBehaviour
{
    private int hp = 10; //10�� �¾ƾ���
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "bullet") //�Ѿ˰� �浹��
        {
            hp -= bullet.damage; //ü��-������
        }
    }

    private void Update()
    {
        if (hp == 0) //ü���� 0 �� �ɽ�
        {
            Destroy(gameObject); //������Ʈ ����
        }
    }
}
