using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObj : MonoBehaviour
{
    private int hp = 10; //10대 맞아야함
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "bullet") //총알과 충돌시
        {
            hp -= bullet.damage; //체력-데미지
        }
    }

    private void Update()
    {
        if (hp == 0) //체력이 0 이 될시
        {
            Destroy(gameObject); //오브젝트 삭제
        }
    }
}
