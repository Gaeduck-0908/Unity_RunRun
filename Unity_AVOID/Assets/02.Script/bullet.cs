using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public static int damage = 1;
    public float speed; //�Ѿ��� �ӵ�


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground") //���� ������
        {
            Destroy(gameObject); //������Ʈ ����
        }
    }
    private void Start()
    {
        Invoke("DestroyBullet", 0.7f); //2�ʵ� ������Ŵ
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); //������*���ǵ�*������
    }

    void DestroyBullet()
    {
        Destroy(gameObject); //������Ʈ ����
    }
}
