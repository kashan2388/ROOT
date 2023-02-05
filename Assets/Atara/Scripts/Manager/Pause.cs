using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            PauseGame();
        }
        if(Input.anyKey)
        {
            PlayGame();
        }
    }
    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void PlayGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
