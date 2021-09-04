using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    float speed = 10.0f; //움직임 속도
    float jumppower = 25.0f; //점프강도

    Vector3 pos;

    bool isGround = false; //땅 닿아있는 체크 여부

    Rigidbody2D rigid;
    SpriteRenderer spr;

    private void Start() //가장먼저 실행
    {
        rigid = GetComponent<Rigidbody2D>(); //Rigidbody2d를 불러옴
        spr = GetComponent<SpriteRenderer>();
        pos = this.gameObject.transform.position;
        Debug.Log("현재위치:" + pos);
    }
    private void OnCollisionEnter2D(Collision2D col) //오브젝트 접촉시
    {
        switch(col.gameObject.tag)
        {
            case "Ground":
                {
                    isGround = true; //땅에 닿아있다고 바꿈
                }
                break;
            case "obstacle":
                {
                    transform.position = pos; //죽음
                    Debug.Log("죽으심");
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
                        Debug.Log("골인!");
                        transform.position = pos;

                        if(GameManager.Instance.Level1.activeSelf == true) //level1일때
                        {
                            if (GameManager.Instance.babynum == GameManager.Instance.babynumlength-1) //레벨체크가 초과할시 시작화면보내버림
                            {
                                GameManager.Instance.babynum = 0;
                                SceneManager.LoadScene("1.start");
                            }

                            else
                            {
                                GameManager.Instance.Level1.transform.GetChild(GameManager.Instance.babynum).gameObject.SetActive(false); //현재레벨 꺼버림
                                GameManager.Instance.Level1.transform.GetChild(GameManager.Instance.babynum + 1).gameObject.SetActive(true); //다음레벨 켜버림
                                GameManager.Instance.babynum++; //레벨증가
                                Debug.Log(GameManager.Instance.babynum); //현재레벨
                            }
                        }
                    }
                }
                break;
        }
    }

    void Update() //매 프레임마다 실행
    {
        if (Input.GetKey(KeyCode.D)) //D를 입력시
        {
            spr.flipX = false;
            transform.Translate(Vector2.right * speed * Time.deltaTime); //Vector X+ 방향으로 speed * 프레임도달시간을 곱해 자연스러운 움직임구현
        }

        if (Input.GetKey(KeyCode.A))
        {
            spr.flipX = true;
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (isGround == true) //땅에 닿아있을시
        {
            if (Input.GetKeyDown(KeyCode.Space)) //스페이스바 눌렀을시
            {
                rigid.AddForce(Vector2.up * jumppower, ForceMode2D.Impulse); //Vector Y+ 방향으로 * 점프강도,순간적으로 한번에 줌
                isGround = false; //땅에서 떨어짐
            }
        }
    }
}