using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToTitle : MonoBehaviour
{
    private ScenesManager scenes;

    private void Awake()
    {
        scenes = GameObject.FindObjectOfType<ScenesManager>();

        Invoke("GoTitle", 10);
    }

    void GoTitle()
    {
        scenes.ScenesChange(0);
    }
}
