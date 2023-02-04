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
//    private Status tree;    //나무의 능력치
//    [SerializeField]
//    private int maxTreeLv = 9;
//    [SerializeField]
//    private int currentTreeLv = 1;

//    [Header("Animals")]
//    private Hamzzi[] hamzzi = new Hamzzi[2];
//    //[SerializeField]
//    //private GameObject[] Hamzzi;    //햄스터
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

//    //나무 강화
//    public void UpgradeTree()
//    {
//        //현재 레벨과 맥스 레벨을 비교 -> 맥스보다 크거나 같으면 return
//        //현재 레벨 상승
//        //나무의 데미지++ -> status에 데미지 강화 메서드 만들고, 호출
//    }

//    //동물 구매 -> 버튼의 id를 받아와서 해당 아이디의 동물 해금
//    public void AddAnimals(int id, GameObject hamzziObject)
//    {
//        if (hamzzi[id].currentHamzziLv >= 1)
//        {
//            return;
//        }
//        //레벨 1로 설정
//        hamzzi[id].currentHamzziLv = 1;
//        //햄스터 강화 -> 햄찌 오브젝트에서 스테이터스 가져와서
//    }

//    //동물 강화
//    public void UpgradeAnimals(int id)
//    {
//        //맥스 레벨 못 넘김
//        if(hamzzi[id].currentHamzziLv >= hamzzi[id].maxHamzziLv)
//        {
//            return;
//        }
//        hamzzi[id].currentHamzziLv++;
//        //햄스터 강화
//    }
//}
