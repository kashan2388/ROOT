using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bamboo : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public float bambooDelayTime;

    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f)
        {
            Destroy(this.gameObject);
        }
        
        //bambooDelayTime -= Time.deltaTime;
        //if (bambooDelayTime <= 0)
        //{
        //    Destroy(this.gameObject);
        //}
    }
}
