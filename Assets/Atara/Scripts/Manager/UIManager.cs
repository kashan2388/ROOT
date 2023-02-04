using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textHP;
    [SerializeField]
    private TextMeshProUGUI textFruit;

    public void SetHP(int current, int max)
    {
        textHP.text = current + " / " + max;
    }
    
    public void SetFruit(int current, int max)
    {
        textFruit.text = current + " / " + max;
    }
}
