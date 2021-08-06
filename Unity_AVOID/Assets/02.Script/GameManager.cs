using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private void Update()
    {
        escape();
    }

    private void escape()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("∞‘¿”¡æ∑·µ ");
            Application.Quit();
        }
    }
}
