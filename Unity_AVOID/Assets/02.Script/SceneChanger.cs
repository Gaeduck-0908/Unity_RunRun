using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void GameScene()
    {
        SceneManager.LoadScene("2.Game");
        Debug.Log("¾Àº¯°æµÊ");
    }
}
