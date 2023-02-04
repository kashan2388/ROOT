using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPool  //오브젝트를 생성, 삭제하는 것이 아니라 재사용한다
{
    //메모리 풀로 관리되는 오브젝트 정보
    private class PoolItem
    {
        public bool isActive;  //활성화/비활성화 정보
        public GameObject gameObject;  //화면에 보이는 오브젝트
    }

    private int increaseCount = 5;   //오브젝트 부족시 추가로 생성하는 수
    private int maxCount;  //현재 리스트에 등록된 오브젝트 개수
    private int activeCount;   //현재 사용되고 있는 오브젝트 개수

    private GameObject poolObject;  //풀링에서 관리하는 오브젝트 프리팹
    private List<PoolItem> poolItems;   //관리되는 오브젝트를 저장하는 리스트

    public int MaxCount => maxCount;   //외부에서 현재 리스트에 등록된 오브젝트 개수를 확인하기 위한 프로퍼티
    public int ActiveCount => activeCount;   //외부에서 현재 활성화된 오브젝트 개수를 확인하기 위한 프로퍼티

    //오브젝트가 임시로 보관되는 위치
    private Vector3 tempPosition = new Vector3(40, 1, 40);
    public MemoryPool(GameObject poolObject)   //생성자 -> 초기화
    {
        maxCount = 0;
        activeCount = 0;
        this.poolObject = poolObject;

        poolItems = new List<PoolItem>();

        InstantiateObjects();
    }

    //오브젝트를 생성한다
    public void InstantiateObjects()
    {
        maxCount += increaseCount;

        for (int i = 0; i < increaseCount; i++)
        {
            PoolItem poolItem = new PoolItem();

            poolItem.isActive = false;
            poolItem.gameObject = GameObject.Instantiate(poolObject);
            poolItem.gameObject.transform.position = tempPosition;   //임시 위치로 이동
            poolItem.gameObject.SetActive(false);

            poolItems.Add(poolItem);
        }
    }

    //관리하는 모든 오브젝트를 삭제한다 -> 종료 시 호출(1번만)
    public void DestroyObjects()
    {
        if (poolItems == null)
        {
            return;
        }

        int count = poolItems.Count;
        for (int i = 0; i < count; i++)
        {
            GameObject.Destroy(poolItems[i].gameObject);
        }
        poolItems.Clear();
    }

    public GameObject ActivePoolItem()
    {
        if(poolItems == null)  //관리중인 오브젝트가 없다면 null
        {
            return null;
        }

        //현재 생성해서 관리하는 모든 오브젝트의 개수와 활성화중인 오브젝트 개수 비교
        //모든 오브젝트가 활성화된 상태라면 새로운 오브젝트 활성해야 함
        if (maxCount == activeCount)
        {
            InstantiateObjects();
        }

        int count = poolItems.Count;
        for (int i = 0; i < count; ++i)
        {
            PoolItem poolItem = poolItems[i];
            if (poolItem.isActive == false)
            {
                activeCount++;
                poolItem.isActive = true;
                poolItem.gameObject.SetActive(true);

                return poolItem.gameObject;
            }
        }

        return null;
    }

    //사용 중인 특정 오브젝트 비활성화
    public void DeactivePoolItem(GameObject removeObject)
    {
        if (poolItems == null || removeObject == null)  //관리중인 오브젝트가 없다면 null
        {
            return;
        }

        int count = poolItems.Count;
        for (int i = 0; i < count; ++i)
        {
            PoolItem poolItem = poolItems[i];
            if (poolItem.gameObject == removeObject)  //비활성화시킬 게임 오브젝트라면
            {
                activeCount--;
                poolItem.gameObject.transform.position = tempPosition;  //임시 위치로 이동
                poolItem.isActive = false;
                poolItem.gameObject.SetActive(false);

                return;
            }
        }
    }


    //모든 오브젝트 비활성화
    public void DeactiveAllPoolItem()
    {
        if (poolItems == null)  //관리중인 오브젝트가 없다면 return
        {
            return;
        }

        int count = poolItems.Count;
        for (int i = 0; i < count; ++i)
        {
            PoolItem poolItem = poolItems[i];
            if (poolItem.gameObject != null || poolItem.isActive == true)  //오브젝트가 존재하고, 활성화 상태라면
            {
                poolItem.gameObject.transform.position = tempPosition;  //임시 위치로 이동
                poolItem.isActive = false;
                poolItem.gameObject.SetActive(false);
            }
        }
        activeCount = 0;
    }
}
