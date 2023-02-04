using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    private void Start()
    {
        Invoke("SceneChange", 3);
    }

    public void SceneChange(string sceneNum)
    {
        SceneManager.LoadScene(sceneNum); // 메인씬을 로드 


    }
}
