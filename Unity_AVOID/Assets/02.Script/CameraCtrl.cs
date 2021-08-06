using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public Transform target; //���� ������Ʈ
    public float speed; //ī�޶� �ӵ�

    public Vector2 center; //�߾�
    public Vector2 size; //ũ��

    float height; //����
    float width; //�ʺ�

    private void Start()
    {
        height = Camera.main.orthographicSize; //������ ����
        width = height * Screen.width / Screen.height; //���� = ����*��ũ������ / ���� (���α���)
    }
    private void OnDrawGizmos() //ī�޶� ��������
    {
        Gizmos.color = Color.red; 
        Gizmos.DrawWireCube(center, size); 
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed); //ī�޶� ��ġ �̵�
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f); //�ӵ��� ���� �����

        //������� ���� ���� ��ǥ�� �������� ��ȯ�Ͽ� ������ �ȳ�������
        float lx = size.x * 0.5f - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

        //������� ���� ���� ��ǥ�� �������� ��ȯ�Ͽ� ������ �ȳ�������
        float ly = size.x * 0.5f - height;
        float clampy = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        transform.position = new Vector3(clampX, clampy, -10f); //��ġ����
    }
}