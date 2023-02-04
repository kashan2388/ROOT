using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    private ScenesManager scenes;
    [SerializeField]
    private int scenesNumber;
    private void Awake()
    {
        scenes = FindObjectOfType<ScenesManager>();

        Button button = this.GetComponent<Button>();
        button.onClick.AddListener(ChangeScenes);
    }

    private void ChangeScenes()
    {
        Time.timeScale = 1;
        scenes.ScenesChange(scenesNumber);
    }
}
