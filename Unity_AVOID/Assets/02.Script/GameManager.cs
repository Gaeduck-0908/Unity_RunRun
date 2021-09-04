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
        GameManager.Instance.babynum = 0; //todo 데이터저장

        if (SceneManager.GetActiveScene().name == "2.Game") //level1 난이도일시
        {
            GameManager.Instance.Level1.transform.GetChild(GameManager.Instance.babynum).gameObject.SetActive(true); //현재레벨 장애물 활성화
            GameManager.Instance.babynumlength = GameManager.Instance.Level1.transform.childCount; //레벨의 갯수 체크
        }

        Debug.Log("레벨의갯수:" + GameManager.Instance.babynumlength);
        Debug.Log("현재레벨:" + GameManager.Instance.babynum);
    }
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
