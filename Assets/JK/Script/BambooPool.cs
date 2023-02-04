using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BambooPool : MonoBehaviour
{
    public bool more = true;
    public static BambooPool instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }


    private void Start()
    {
        CreateBamboo();
    }

    public GameObject bullet;
    private List<GameObject> bambooPool;
    public int bambooCreateCount;
    private void CreateBamboo()
    {
        bambooPool = new List<GameObject>();
        for (int i = 0; i < bambooCreateCount; i++)
        {
            GameObject obj = Instantiate(bullet);
            obj.SetActive(false);
            bambooPool.Add(obj);
        }
    }


    public GameObject GetBamboo()
    {
        foreach (GameObject obj in bambooPool)
        {
            if (!obj.activeInHierarchy) { return obj; }
        }

        //오브젝트가 모두 활성화일 때
        if (more)
        {
            GameObject obj = Instantiate(bullet);
            obj.SetActive(false);
            bambooPool.Add(obj);
            return obj;
        }
        else
        {
            return null;
        }
    }
}

