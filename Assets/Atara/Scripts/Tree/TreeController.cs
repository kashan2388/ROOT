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
        //Ŭ���� ���� ������ ������ ����
        RaycastHit hit;


        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(point.ToString()); // ���콺 Ŭ�� ��ġ Ȯ��

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


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
                    CreateBamboo();

                }
            }
        }


    }

    private Vector3 CreateBamboo()
    {
        GameObject bamboo = BambooPool.instance.GetBamboo();
        // �ӽ÷� ����Ʈ�� ��Ƽ� ���콺�� ��ġ�� ���, ����Ʈ�� x ���� �������� �����ǰԲ� ��
        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
        Input.mousePosition.y, -Camera.main.transform.position.z));

        bamboo.transform.position = new Vector3(point.x, 0, 0);
        bamboo.transform.rotation = Quaternion.Euler(-90f, 0, 0);
        bamboo.SetActive(true);
        // ���� �ִϸ��̼� ( ���� ) 


        //Invoke("DeleteBamboo", 1f);
        // ���� �ִϸ��̼� ( ������ ) 
        return point;
    }

    //public void DeleteBamboo()
    //{
    //    GameObject bamboo = BambooPool.instance.GetBamboo();
    //    bamboo.SetActive(false);
    //    Debug.Log("�׼�����");
    //}
}
