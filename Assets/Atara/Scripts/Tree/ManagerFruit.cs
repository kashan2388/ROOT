using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerFruit : MonoBehaviour
{
    //Ʈ���� ������ ���
    private TreeMovement treeMovement;
    [SerializeField]
    private UIManager uIManager;

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

    [SerializeField]
    private AudioClip getCilp;
    [SerializeField]
    private AudioClip victoryCilp;

    public int CurrentCount => currentCount;

    [SerializeField]
    private GameObject nextStage;

    private void Awake()
    {
        treeMovement = GetComponent<TreeMovement>();
        currentCount = 0;
        uIManager.SetFruit(currentCount, achiveCount);
    }

    private void Update()
    {
        CreateFruit();
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
            int rand = Random.Range(0, positions.Length);
            //���� ����
            GameObject newFruit = Instantiate(fruitPrefab);
            newFruit.GetComponent<Fruit>().SetUp(this);
            newFruit.transform.position = positions[rand].position;
            newFruit.transform.parent = positions[rand].transform;

            isCreate = true;
        }
    }

    public void GetFruit()
    {
        //���� ���� �� ����
        currentCount++;
        SoundManager.instance.PlaySound(getCilp);
        isCreate = false;
        uIManager.SetFruit(currentCount, achiveCount);
        CheckFruit();
    }

     //������ ���� Ȯ���Ѵ�
    private void CheckFruit()
    {
        //��ǥġ ����
        if(currentCount >= achiveCount)
        {
            SoundManager.instance.PlaySound(victoryCilp);
            nextStage.SetActive(true);
            Time.timeScale = 0;
        }
        //����
        if(currentCount % 4 == 0)
        {
            treeMovement.GrowUpTree();
        }
    }


    public bool CheckFruitCount(int count)
    {
        //�ʿ��� ������ �޾Ƽ� ���� ������ ���� ��, �����ϸ� false, ����ϸ� true -> ��ȭ��
        if(currentCount >= count)
        {
            return true;
        }
        return false;
    }
}
