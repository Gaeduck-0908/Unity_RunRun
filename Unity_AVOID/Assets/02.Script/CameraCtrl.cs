using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public Transform target; //따라갈 오브젝트
    public float speed; //카메라 속도

    public Vector2 center; //중앙
    public Vector2 size; //크기

    float height; //높이
    float width; //너비

    private void Start()
    {
        height = Camera.main.orthographicSize; //세로의 절반
        width = height * Screen.width / Screen.height; //가로 = 세로*스크린가로 / 세로 (가로길이)
    }
    private void OnDrawGizmos() //카메라 구역제한
    {
        Gizmos.color = Color.red; 
        Gizmos.DrawWireCube(center, size); 
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed); //카메라 위치 이동
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f); //속도에 맞춰 따라옴

        //기즈모의 값을 빼서 좌표가 낮아질시 반환하여 밖으로 안나가게함
        float lx = size.x * 0.5f - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

        //기즈모의 값을 빼서 좌표가 낮아질시 반환하여 밖으로 안나가게함
        float ly = size.x * 0.5f - height;
        float clampy = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        transform.position = new Vector3(clampX, clampy, -10f); //위치저장
    }
}