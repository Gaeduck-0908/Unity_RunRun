using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject bullet; //총알 오브젝트
    public Transform pos; //총알이 발사될 위치
    public float cooltime; //총알 발사 간격
    private float time; //현재 간격
    private void Update()
    {
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //마우스의 좌표값을 월드좌표로 환산후 플레이어 위치를 뺌
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg; //Rad2Deg = 라디안값을 도로 바꿔줌 Atan을 이용해 거리 측정을 함
        transform.rotation = Quaternion.Euler(0, 0, z); //각도 회전을 위한 코드


        if (time <=0) //발사 대기시간 없을시
        {
            if (Input.GetMouseButton(0)) //마우스 누르고 있을시
            {
                Instantiate(bullet, pos.position, transform.rotation); //오브젝트 생성
            }
            time = cooltime; //쿨타임 적용
        }
        time -= Time.deltaTime; //프레임 만큼 빼줌
    }
}
