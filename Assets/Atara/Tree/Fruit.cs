using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private ManagerFruit manager;

    public void SetUp(ManagerFruit manager)
    {
        this.manager = manager;
    }

    public void GetFruit()
    {
        manager.GetFruit();
        Destroy(this.gameObject);   //°úÀÏ ÆÄ±«
    }
}
