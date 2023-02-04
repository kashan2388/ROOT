using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    private void Update()
    {
        OnClick();
    }
    private void OnClick()
    {
        //클릭한 곳의 정보를 저장할 변수
        RaycastHit hit;

        if(Input.GetMouseButtonDown(0))
        {
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
                }
            }
        }
    }
}
