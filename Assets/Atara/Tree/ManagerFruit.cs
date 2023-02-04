using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerFruit : MonoBehaviour
{
    //트리의 성장을 담당
    private TreeMovement treeMovement;

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

    //과일의 수를 확인한다
    private void CheckFruit()
    {
        
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

            //과일 생성
            GameObject newFruit = Instantiate(fruitPrefab);
            newFruit.GetComponent<Fruit>().SetUp(this);
            newFruit.transform.position = positions[Random.Range(0, positions.Length)].position;

            isCreate = true;
        }
    }

    public void GetFruit()
    {
        //현재 과일 수 증가
        currentCount++;
        isCreate = false;
    }
}
