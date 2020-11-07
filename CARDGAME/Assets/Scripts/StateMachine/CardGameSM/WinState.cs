using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinState : CardGameState
{

    [SerializeField] Text _WinTextUI = null;


    public override void Enter()
    {
        Debug.Log("Entering Win State... Congrats!");
        _WinTextUI.gameObject.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
}
