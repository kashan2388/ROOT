using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerFruit : MonoBehaviour
{
    //트리의 성장을 담당
    private TreeMovement treeMovement;
    [SerializeField]
    private UIManager uIManager;

    [SerializeField]
    private float lastFruitTime;    //마지막에 열린 열매(열매가 열리는 주기)
    [SerializeField]
    private float createSpeed;      //과일 생산 타임(쿨타임)

    [SerializeField]
    private Transform[] positions;     //과일이 열릴 위치들
    [SerializeField]
    private GameObject fruitPrefab;    //과일

    [SerializeField]
    private int achiveCount;       //목표 과일 수 -> 여기에 도달하면 스테이지 클리어
    [SerializeField]
    private int currentCount;      //현재 과일 수
    private bool isCreate = false;  //과일이 생성됐는가?

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
    //과일이 열린다
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
            //과일 생성
            GameObject newFruit = Instantiate(fruitPrefab);
            newFruit.GetComponent<Fruit>().SetUp(this);
            newFruit.transform.position = positions[rand].position;
            newFruit.transform.parent = positions[rand].transform;

            isCreate = true;
        }
    }

    public void GetFruit()
    {
        //현재 과일 수 증가
        currentCount++;
        SoundManager.instance.PlaySound(getCilp);
        isCreate = false;
        uIManager.SetFruit(currentCount, achiveCount);
        CheckFruit();
    }

     //과일의 수를 확인한다
    private void CheckFruit()
    {
        //목표치 도달
        if(currentCount >= achiveCount)
        {
            SoundManager.instance.PlaySound(victoryCilp);
            nextStage.SetActive(true);
            Time.timeScale = 0;
        }
        //성장
        if(currentCount % 4 == 0)
        {
            treeMovement.GrowUpTree();
        }
    }


    public bool CheckFruitCount(int count)
    {
        //필요한 갯수를 받아서 현재 과일의 수와 비교, 부족하면 false, 충분하면 true -> 강화용
        if(currentCount >= count)
        {
            return true;
        }
        return false;
    }
}
