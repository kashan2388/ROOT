using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    [NonSerialized] public Vector3 cameraPoint;

    public GameObject bamboo;
    private void Update()
    {
        OnClick(cameraPoint);
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
                    
                    hit.transform.GetComponent<EnemyMovement>().TakeDamage(10);
                    CreateBamboo();

                }
            }
        }


    }

    private Vector3 CreateBamboo()
    {
        GameObject bamboo = BambooPool.instance.GetBamboo();
        // 임시로 포인트를 잡아서 마우스의 위치를 잡고, 포인트의 x 축을 기준으로 생성되게끔 함
        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
        Input.mousePosition.y, -Camera.main.transform.position.z));

        bamboo.transform.position = new Vector3(point.x, 0, 0);
        bamboo.transform.rotation = Quaternion.Euler(-90f, 0, 0);
        bamboo.SetActive(true);
        // 등장 애니메이션 ( 물결 ) 


        //Invoke("DeleteBamboo", 1f);
        // 퇴장 애니메이션 ( 스르륵 ) 
        return point;
    }

    //public void DeleteBamboo()
    //{
    //    GameObject bamboo = BambooPool.instance.GetBamboo();
    //    bamboo.SetActive(false);
    //    Debug.Log("죽순삭제");
    //}
}
