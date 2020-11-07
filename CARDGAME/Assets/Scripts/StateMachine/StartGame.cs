using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    [SerializeField] GameObject menu;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        
    }


    public void startTheGame()
    {
        SceneManager.LoadScene("CardTest");
    }

    public void restart()
    {
        SceneManager.LoadScene("CardTest");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
