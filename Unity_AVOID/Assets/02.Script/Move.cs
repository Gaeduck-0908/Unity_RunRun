using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    float speed = 10.0f; //������ �ӵ�
    float jumppower = 25.0f; //��������

    Vector3 pos;

    bool isGround = false; //�� ����ִ� üũ ����

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spr;

    private void Start() //������� ����
    {
        rigid = GetComponent<Rigidbody2D>(); //Rigidbody2d�� �ҷ���
        anim = GetComponent<Animator>(); //�ִϸ��̼�
        spr = GetComponent<SpriteRenderer>();
        pos = this.gameObject.transform.position;
        Debug.Log("������ġ:" + pos);
    }

    private void OnCollisionEnter2D(Collision2D col) //������Ʈ ���˽�
    {
        switch(col.gameObject.tag)
        {
            case "Ground":
                {
                    isGround = true; //���� ����ִٰ� �ٲ�
                }
                break;
            case "obstacle":
                {
                    SceneManager.LoadScene("2.Game"); //����
                    Debug.Log("������");
                }
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D col2)
    {
        switch(col2.gameObject.tag)
        {
            case "Goal":
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        Debug.Log("����!");
                        transform.position = pos;
                    }
                }
                break;
        }
    }

    void Update() //�� �����Ӹ��� ����
    {
        if (Input.GetKey(KeyCode.D)) //D�� �Է½�
        {
            spr.flipX = false;
            transform.Translate(Vector2.right * speed * Time.deltaTime); //Vector X+ �������� speed * �����ӵ��޽ð��� ���� �ڿ������� �����ӱ���
        }

        if (Input.GetKey(KeyCode.A))
        {
            spr.flipX = true;
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (isGround == true) //���� ���������
        {
            if (Input.GetKeyDown(KeyCode.Space)) //�����̽��� ��������
            {
                rigid.AddForce(Vector2.up * jumppower, ForceMode2D.Impulse); //Vector Y+ �������� * ��������,���������� �ѹ��� ��
                isGround = false; //������ ������
            }
        }
    }
}