using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public GameObject Panel;
    bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            isPaused = !isPaused;
            Panel.SetActive(isPaused);

            if(isPaused){
                Time.timeScale = 0f;
            }
            else{
                Time.timeScale = 1f;
            }
        }
    }

    public void BackMenu(){
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1.0f;
    }
}
