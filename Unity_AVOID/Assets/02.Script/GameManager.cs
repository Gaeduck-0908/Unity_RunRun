using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Lib;

public class GameManager : Singleton<GameManager>
{


    public int babynum;
    public int babynumlength;

    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Level4;

    private void Start()
    {
        GameManager.Instance.babynum = 0; //todo ����������

        if (SceneManager.GetActiveScene().name == "2.Game") //level1 ���̵��Ͻ�
        {
            GameManager.Instance.Level1.transform.GetChild(GameManager.Instance.babynum).gameObject.SetActive(true); //���緹�� ��ֹ� Ȱ��ȭ
            GameManager.Instance.babynumlength = GameManager.Instance.Level1.transform.childCount; //������ ���� üũ
        }

        Debug.Log("�����ǰ���:" + GameManager.Instance.babynumlength);
        Debug.Log("���緹��:" + GameManager.Instance.babynum);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("1.start");
            Debug.Log("�ʱ�ȭ�� ���ư�");
        }
    }

    public void GameScene()
    {
        //Todo ���������� ������ �°� �̵�
        SceneManager.LoadScene("2.Game");
        Debug.Log("�������");
    }

    public void escape()
    {
        Debug.Log("���������");
        Application.Quit();
    }

}
