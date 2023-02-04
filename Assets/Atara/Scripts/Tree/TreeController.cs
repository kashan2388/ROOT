using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    [NonSerialized] public Vector3 cameraPoint;

    public GameObject bamboo;
    public float bambooDelayTime;
    bool bambooOn = false;
    private void FixedUpdate()
    {
        OnClick(cameraPoint);

        if(bambooOn == true)
        {
            bambooDelayTime -= Time.deltaTime;
            bambooOn = false;
        }


    }
    private void OnClick(Vector3 point)
    {
        //클릭한 곳의 정보를 저장할 변수
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(point.ToString()); // 마우스 클릭 위치 확인

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                //과일일 때는 Fruit의 GetFruit 호출
                //적일 때는 EnemyMovement를 받아서 TakeDamage
                if (hit.transform.gameObject.CompareTag("Fruit"))
                {
                    hit.transform.GetComponent<Fruit>().GetFruit();
                }
                else if (hit.transform.gameObject.CompareTag("Enemy"))
                {
                    CreateBamboo();
                    hit.transform.GetComponent<EnemyMovement>().TakeDamage(10);

                    
                }
            }
        }        

    }

    private Vector3 CreateBamboo()
    {
        // 임시로 포인트를 잡아서 마우스의 위치를 잡고, 포인트의 x 축을 기준으로 생성되게끔 함
        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
        Input.mousePosition.y, -Camera.main.transform.position.z));

        bamboo.transform.position = new Vector3(point.x, 0, 0);
        bamboo.transform.rotation = Quaternion.Euler(-90f, 0, 0);

        Instantiate(bamboo);
        bambooOn = true;

        if (bambooDelayTime <= 0)
        {
            Destroy(bamboo);
        }
        return point;
    }

}
