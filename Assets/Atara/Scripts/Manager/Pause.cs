using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    private bool isPause;

    private void Update()
    {        
        if(Input.anyKeyDown && isPause)
        {
            isPause = false;
            pausePanel.SetActive(isPause);
            Time.timeScale = 1;
        }
        if(Input.GetMouseButtonDown(1))
        {
            isPause = true;
            pausePanel.SetActive(isPause);
            Time.timeScale = 0;
        }
    }
}
