using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpgradeManager : MonoBehaviour
{
    [Header("Component")]
    [SerializeField]
    private ManagerFruit managerFruit;  //과일 에너지
    [SerializeField]
    private GameObject upgradeWindow;   //업그레이드 창

    [Header("Tree")]
    [SerializeField]
    private Status tree;    //나무의 능력치
    [SerializeField]
    private int maxTreeLv = 9;
    [SerializeField]
    private int currentTreeLv = 1;
    [SerializeField]
    private int needEnergy;  //요구하는 에너지

    [Header("Animals")]
    [SerializeField]
    private int maxHamzziLv = 2;
    [SerializeField]
    private int[] currentHamzziLv = { 0, 0 };
    private int[] needAnimalsEnergy;

    //나무 강화
    public void UpgradeTree()
    {
        //현재 레벨과 맥스 레벨을 비교 -> 맥스보다 크거나 같으면 return
        if (currentTreeLv >= maxTreeLv || managerFruit.CheckFruitCount(needEnergy) == false)
        {
            return;
        }
        //현재 레벨 상승
        currentTreeLv++;
        //나무의 데미지++
        tree.UpDamage(1);
        //강화 재화 설정
        Debug.Log("나무 강화");
    }

    //동물 구매 -> 버튼의 id를 받아와서 해당 아이디의 동물 해금
    public void AddAnimals(int id, GameObject hamzzi)
    {
        if(currentHamzziLv[id] > 0 || managerFruit.CheckFruitCount(needAnimalsEnergy[id]) == false)
        {
            return;
        }
        //햄스터 강화 -> 햄찌 오브젝트에서 스테이터스 가져와서
        currentHamzziLv[id] = 1;
        hamzzi.SetActive(true);
        hamzzi.GetComponent<Status>().UpDamage(1);
        Debug.Log("햄스터 구매");
    }

    //동물 강화
    public void UpgradeAnimals(int id, GameObject hamzzi)
    {
        //맥스 레벨보다 높으면 강화 불가능
        if ((currentHamzziLv[id] >= maxHamzziLv || currentHamzziLv[id] == 0) || managerFruit.CheckFruitCount(needAnimalsEnergy[id]) == false)
        {
            return;
        }
        currentHamzziLv[id]++;
        hamzzi.GetComponent<Status>().UpDamage(1);
        Debug.Log("햄스터 강화");
    }

    public void OpenUpgrade()
    {
        upgradeWindow.SetActive(true);
        //시간 정지
    }

    public void CloseUpgrade()
    {
        upgradeWindow.SetActive(false);
        //시간 정지 해제
    }
}
