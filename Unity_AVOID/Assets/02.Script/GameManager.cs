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
