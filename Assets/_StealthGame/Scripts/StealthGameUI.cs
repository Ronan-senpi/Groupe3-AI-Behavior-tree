using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StealthGameUI : MonoBehaviour
{
    public GameObject GameWinUI;
    public GameObject GameLoseUI;
    bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver){
            if(Input.GetKeyDown(KeyCode.Space)){
                Time.timeScale = 1;
                SceneManager.LoadScene(0);
            }
        }
    }

    public void ShowGameLoseUI(){
        Time.timeScale = 0;
        GameLoseUI.SetActive(true);
        isGameOver = true;
    }

    public void ShowGameWinUI(){
        Time.timeScale = 0;
        GameWinUI.SetActive(true);
        isGameOver = true;
    }
    
}
