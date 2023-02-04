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
    private GameObject fruitPrefab;     //����

    [SerializeField]
    private int achiveCount;       //��ǥ ���� �� -> ���⿡ �����ϸ� �������� Ŭ����
    [SerializeField]
    private int currentCount;   //���� ���� ��

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

            //���� ����
            GameObject newFruit = Instantiate(fruitPrefab);
            newFruit.GetComponent<Fruit>().SetUp(this);
            newFruit.transform.position = positions[Random.Range(0, positions.Length)].position;
        }
    }

    public void GetFruit()
    {
        //���� ���� �� ����
        currentCount++;
    }
}
