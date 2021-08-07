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
            Debug.Log("초기화면 돌아감");
        }
    }

    public void GameScene()
    {
        //Todo 레벨구현후 레벨에 맞게 이동
        SceneManager.LoadScene("2.Game");
        Debug.Log("씬변경됨");
    }

    public void escape()
    {
        Debug.Log("게임종료됨");
        Application.Quit();
    }

}
