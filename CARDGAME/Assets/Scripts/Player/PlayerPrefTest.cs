using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefTest : MonoBehaviour
{
    public Text testTxt;

    public int testNum =10;

    // Start is called before the first frame update
    void Start()
    {
        testTxt.text = PlayerPrefs.GetInt("Number", 10).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            testNum = Random.Range(1, 5);

            PlayerPrefs.SetInt("Number", testNum);
        }

        
    }
}
