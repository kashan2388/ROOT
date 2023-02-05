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
        if(Input.GetMouseButtonDown(1))
        {
            isPause = !isPause;
            pausePanel.SetActive(isPause);
            if (isPause) { Time.timeScale = 0; }
            if (!isPause) { Time.timeScale = 1; }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
