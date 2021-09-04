using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public static int damage = 1;
    public float speed; //총알의 속도


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground") //땅에 닿을시
        {
            Destroy(gameObject); //오브젝트 삭제
        }
    }
    private void Start()
    {
        Invoke("DestroyBullet", 0.7f); //2초뒤 삭제시킴
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); //오른쪽*스피드*프레임
    }

    void DestroyBullet()
    {
        Destroy(gameObject); //오브젝트 삭제
    }
}
