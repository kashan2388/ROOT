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
        //Ŭ���� ���� ������ ������ ����
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
                //������ ���� Fruit�� GetFruit ȣ��
                //���� ���� EnemyMovement�� �޾Ƽ� TakeDamage
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
