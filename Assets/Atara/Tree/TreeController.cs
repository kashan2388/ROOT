using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public GameObject bamboo;
    [NonSerialized] public Vector3 cameraPoint;
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
            Debug.Log(point.ToString());

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, -Camera.main.transform.position.z));

            Instantiate(bamboo, new Vector3 (point.x, 0, 0), Quaternion.Euler(-90f, 0, 0));
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

                }
            }
        }

        
    }

}
