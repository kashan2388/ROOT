using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpgradeManager : MonoBehaviour
{
    [Header("Component")]
    [SerializeField]
    private ManagerFruit managerFruit;  //���� ������
    [SerializeField]
    private GameObject upgradeWindow;   //���׷��̵� â

    [Header("Tree")]
    [SerializeField]
    private Status tree;    //������ �ɷ�ġ
    [SerializeField]
    private int maxTreeLv = 9;
    [SerializeField]
    private int currentTreeLv = 1;
    [SerializeField]
    private int needEnergy;  //�䱸�ϴ� ������

    [Header("Animals")]
    [SerializeField]
    private int maxHamzziLv = 2;
    [SerializeField]
    private int[] currentHamzziLv = { 0, 0 };
    private int[] needAnimalsEnergy;

    //���� ��ȭ
    public void UpgradeTree()
    {
        //���� ������ �ƽ� ������ �� -> �ƽ����� ũ�ų� ������ return
        if (currentTreeLv >= maxTreeLv || managerFruit.CheckFruitCount(needEnergy) == false)
        {
            return;
        }
        //���� ���� ���
        currentTreeLv++;
        //������ ������++
        tree.UpDamage(1);
        //��ȭ ��ȭ ����
        Debug.Log("���� ��ȭ");
    }

    //���� ���� -> ��ư�� id�� �޾ƿͼ� �ش� ���̵��� ���� �ر�
    public void AddAnimals(int id, GameObject hamzzi)
    {
        if(currentHamzziLv[id] > 0 || managerFruit.CheckFruitCount(needAnimalsEnergy[id]) == false)
        {
            return;
        }
        //�ܽ��� ��ȭ -> ���� ������Ʈ���� �������ͽ� �����ͼ�
        currentHamzziLv[id] = 1;
        hamzzi.SetActive(true);
        hamzzi.GetComponent<Status>().UpDamage(1);
        Debug.Log("�ܽ��� ����");
    }

    //���� ��ȭ
    public void UpgradeAnimals(int id, GameObject hamzzi)
    {
        //�ƽ� �������� ������ ��ȭ �Ұ���
        if ((currentHamzziLv[id] >= maxHamzziLv || currentHamzziLv[id] == 0) || managerFruit.CheckFruitCount(needAnimalsEnergy[id]) == false)
        {
            return;
        }
        currentHamzziLv[id]++;
        hamzzi.GetComponent<Status>().UpDamage(1);
        Debug.Log("�ܽ��� ��ȭ");
    }

    public void OpenUpgrade()
    {
        upgradeWindow.SetActive(true);
        //�ð� ����
    }

    public void CloseUpgrade()
    {
        upgradeWindow.SetActive(false);
        //�ð� ���� ����
    }
}
