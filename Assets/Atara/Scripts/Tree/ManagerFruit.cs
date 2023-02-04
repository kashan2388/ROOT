using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerFruit : MonoBehaviour
{
    //Ʈ���� ������ ���
    private TreeMovement treeMovement;

    [SerializeField]
    private float lastFruitTime;    //�������� ���� ����(���Ű� ������ �ֱ�)
    [SerializeField]
    private float createSpeed;      //���� ���� Ÿ��(��Ÿ��)

    [SerializeField]
    private Transform[] positions;     //������ ���� ��ġ��
    [SerializeField]
    private GameObject fruitPrefab;    //����

    [SerializeField]
    private int achiveCount;       //��ǥ ���� �� -> ���⿡ �����ϸ� �������� Ŭ����
    [SerializeField]
    private int currentCount;      //���� ���� ��
    private bool isCreate = false;  //������ �����ƴ°�?

    private void Awake()
    {
        treeMovement = GetComponent<TreeMovement>();

        currentCount = 0;
    }

    private void Update()
    {
        CheckFruit();
        CreateFruit();
    }

    //������ ���� Ȯ���Ѵ�
    private void CheckFruit()
    {
        
    }

    //������ ������
    private void CreateFruit()
    {
        if(Time.time - lastFruitTime > createSpeed)
        {
            lastFruitTime = Time.time;
            if(isCreate)
            {
                return;
            }

            //���� ����
            GameObject newFruit = Instantiate(fruitPrefab);
            newFruit.GetComponent<Fruit>().SetUp(this);
            newFruit.transform.position = positions[Random.Range(0, positions.Length)].position;

            isCreate = true;
        }
    }

    public void GetFruit()
    {
        //���� ���� �� ����
        currentCount++;
        isCreate = false;
    }
}
