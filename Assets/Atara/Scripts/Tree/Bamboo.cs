using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bamboo : MonoBehaviour
{
    public float bambooDelayTime;

    // Update is called once per frame
    void Update()
    {
        bambooDelayTime -= Time.deltaTime;
        if (bambooDelayTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
