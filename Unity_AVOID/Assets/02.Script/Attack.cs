using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject bullet; //�Ѿ� ������Ʈ
    public Transform pos; //�Ѿ��� �߻�� ��ġ
    public float cooltime; //�Ѿ� �߻� ����
    private float time; //���� ����
    private void Update()
    {
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //���콺�� ��ǥ���� ������ǥ�� ȯ���� �÷��̾� ��ġ�� ��
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg; //Rad2Deg = ���Ȱ��� ���� �ٲ��� Atan�� �̿��� �Ÿ� ������ ��
        transform.rotation = Quaternion.Euler(0, 0, z); //���� ȸ���� ���� �ڵ�


        if (time <=0) //�߻� ���ð� ������
        {
            if (Input.GetMouseButton(0)) //���콺 ������ ������
            {
                Instantiate(bullet, pos.position, transform.rotation); //������Ʈ ����
            }
            time = cooltime; //��Ÿ�� ����
        }
        time -= Time.deltaTime; //������ ��ŭ ����
    }
}
