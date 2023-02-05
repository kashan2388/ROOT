using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    [NonSerialized] public Vector3 cameraPoint;
    private TreeMovement treeMovement;

    [SerializeField]
    private AudioClip hitCilp;

    public GameObject bamboo;
    //public float bambooDelayTime;
    //bool bambooOn = false;

    private void Awake()
    {
        treeMovement = GetComponent<TreeMovement>();
    }
    private void FixedUpdate()
    {
        OnClick(cameraPoint);

        //if(bambooOn == true)
        //{
        //    bambooDelayTime -= Time.deltaTime;
        //    bambooOn = false;
        //}


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
                    CreateBamboo();
                    SoundManager.instance.PlaySound(hitCilp);
                    hit.transform.GetComponent<EnemyMovement>().TakeDamage(treeMovement.attackDamage);                    
                }
                else if(hit.transform.gameObject.CompareTag("Plane"))
                {
                    //CreateBamboo();
                    SoundManager.instance.PlaySound(hitCilp);
                    hit.transform.GetComponent<EnemyMovement>().TakeDamage(treeMovement.attackDamage);
                }
            }
        }        

    }

    private Vector3 CreateBamboo()
    {
        // �ӽ÷� ����Ʈ�� ��Ƽ� ���콺�� ��ġ�� ���, ����Ʈ�� x ���� �������� �����ǰԲ� ��
        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
        Input.mousePosition.y, -Camera.main.transform.position.z));

        bamboo.transform.position = new Vector3(point.x, 0, 0);
        bamboo.transform.rotation = Quaternion.Euler(-90f, 0, 0);

        Instantiate(bamboo);
       // bambooOn = true;

        //if (bambooDelayTime <= 0)
        //{
        //    Destroy(bamboo);
        //}
        return point;
    }
}
