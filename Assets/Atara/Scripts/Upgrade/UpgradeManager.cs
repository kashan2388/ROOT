//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Hamzzi
//{
//    public int maxHamzziLv;
//    public int currentHamzziLv;
//}
//public class UpgradeManager : MonoBehaviour
//{
//    [Header("Tree")]
//    [SerializeField]
//    private Status tree;    //������ �ɷ�ġ
//    [SerializeField]
//    private int maxTreeLv = 9;
//    [SerializeField]
//    private int currentTreeLv = 1;

//    [Header("Animals")]
//    private Hamzzi[] hamzzi = new Hamzzi[2];
//    //[SerializeField]
//    //private GameObject[] Hamzzi;    //�ܽ���
//    //[SerializeField]
//    //private int maxHamzziLv = 2;
//    //[SerializeField]
//    //private int currentHamzziLv = 1;

//    private void Awake()
//    {
//        for(int i = 0; i < hamzzi.Length; ++i)
//        {
//            hamzzi[i].maxHamzziLv = 2;
//            hamzzi[i].currentHamzziLv = 1;
//        }
//    }

//    //���� ��ȭ
//    public void UpgradeTree()
//    {
//        //���� ������ �ƽ� ������ �� -> �ƽ����� ũ�ų� ������ return
//        //���� ���� ���
//        //������ ������++ -> status�� ������ ��ȭ �޼��� �����, ȣ��
//    }

//    //���� ���� -> ��ư�� id�� �޾ƿͼ� �ش� ���̵��� ���� �ر�
//    public void AddAnimals(int id, GameObject hamzziObject)
//    {
//        if (hamzzi[id].currentHamzziLv >= 1)
//        {
//            return;
//        }
//        //���� 1�� ����
//        hamzzi[id].currentHamzziLv = 1;
//        //�ܽ��� ��ȭ -> ���� ������Ʈ���� �������ͽ� �����ͼ�
//    }

//    //���� ��ȭ
//    public void UpgradeAnimals(int id)
//    {
//        //�ƽ� ���� �� �ѱ�
//        if(hamzzi[id].currentHamzziLv >= hamzzi[id].maxHamzziLv)
//        {
//            return;
//        }
//        hamzzi[id].currentHamzziLv++;
//        //�ܽ��� ��ȭ
//    }
//}
