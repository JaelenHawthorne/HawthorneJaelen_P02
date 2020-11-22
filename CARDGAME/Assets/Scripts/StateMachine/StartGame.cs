using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    [SerializeField] GameObject menu;
    public GameObject Sbutton;
    public GameObject Rbutton;
    public AudioSource buttonSound;


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
        LeanTween.scale(Sbutton, new Vector3(2, 2, 2), .5f).setLoopPingPong(1).setOnComplete(load);
        buttonSound.Play();
    }

    public void restart()
    {
        LeanTween.scale(Rbutton, new Vector3(2, 2, 2), .5f).setLoopPingPong(1).setOnComplete(load);
        buttonSound.Play();
    }

    void load()
    {
        SceneManager.LoadScene("CardTest");
    }

    public void Quit()
    {
        buttonSound.Play();
        Application.Quit();
    }
}
