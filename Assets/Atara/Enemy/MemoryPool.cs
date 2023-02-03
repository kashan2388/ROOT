using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPool  //������Ʈ�� ����, �����ϴ� ���� �ƴ϶� �����Ѵ�
{
    //�޸� Ǯ�� �����Ǵ� ������Ʈ ����
    private class PoolItem
    {
        public bool isActive;  //Ȱ��ȭ/��Ȱ��ȭ ����
        public GameObject gameObject;  //ȭ�鿡 ���̴� ������Ʈ
    }

    private int increaseCount = 5;   //������Ʈ ������ �߰��� �����ϴ� ��
    private int maxCount;  //���� ����Ʈ�� ��ϵ� ������Ʈ ����
    private int activeCount;   //���� ���ǰ� �ִ� ������Ʈ ����

    private GameObject poolObject;  //Ǯ������ �����ϴ� ������Ʈ ������
    private List<PoolItem> poolItems;   //�����Ǵ� ������Ʈ�� �����ϴ� ����Ʈ

    public int MaxCount => maxCount;   //�ܺο��� ���� ����Ʈ�� ��ϵ� ������Ʈ ������ Ȯ���ϱ� ���� ������Ƽ
    public int ActiveCount => activeCount;   //�ܺο��� ���� Ȱ��ȭ�� ������Ʈ ������ Ȯ���ϱ� ���� ������Ƽ

    //������Ʈ�� �ӽ÷� �����Ǵ� ��ġ
    private Vector3 tempPosition = new Vector3(40, 1, 40);
    public MemoryPool(GameObject poolObject)   //������ -> �ʱ�ȭ
    {
        maxCount = 0;
        activeCount = 0;
        this.poolObject = poolObject;

        poolItems = new List<PoolItem>();

        InstantiateObjects();
    }

    //������Ʈ�� �����Ѵ�
    public void InstantiateObjects()
    {
        maxCount += increaseCount;

        for (int i = 0; i < increaseCount; i++)
        {
            PoolItem poolItem = new PoolItem();

            poolItem.isActive = false;
            poolItem.gameObject = GameObject.Instantiate(poolObject);
            poolItem.gameObject.transform.position = tempPosition;   //�ӽ� ��ġ�� �̵�
            poolItem.gameObject.SetActive(false);

            poolItems.Add(poolItem);
        }
    }

    //�����ϴ� ��� ������Ʈ�� �����Ѵ� -> ���� �� ȣ��(1����)
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
        if(poolItems == null)  //�������� ������Ʈ�� ���ٸ� null
        {
            return null;
        }

        //���� �����ؼ� �����ϴ� ��� ������Ʈ�� ������ Ȱ��ȭ���� ������Ʈ ���� ��
        //��� ������Ʈ�� Ȱ��ȭ�� ���¶�� ���ο� ������Ʈ Ȱ���ؾ� ��
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

    //��� ���� Ư�� ������Ʈ ��Ȱ��ȭ
    public void DeactivePoolItem(GameObject removeObject)
    {
        if (poolItems == null || removeObject == null)  //�������� ������Ʈ�� ���ٸ� null
        {
            return;
        }

        int count = poolItems.Count;
        for (int i = 0; i < count; ++i)
        {
            PoolItem poolItem = poolItems[i];
            if (poolItem.gameObject == removeObject)  //��Ȱ��ȭ��ų ���� ������Ʈ���
            {
                activeCount--;
                poolItem.gameObject.transform.position = tempPosition;  //�ӽ� ��ġ�� �̵�
                poolItem.isActive = false;
                poolItem.gameObject.SetActive(false);

                return;
            }
        }
    }


    //��� ������Ʈ ��Ȱ��ȭ
    public void DeactiveAllPoolItem()
    {
        if (poolItems == null)  //�������� ������Ʈ�� ���ٸ� return
        {
            return;
        }

        int count = poolItems.Count;
        for (int i = 0; i < count; ++i)
        {
            PoolItem poolItem = poolItems[i];
            if (poolItem.gameObject != null || poolItem.isActive == true)  //������Ʈ�� �����ϰ�, Ȱ��ȭ ���¶��
            {
                poolItem.gameObject.transform.position = tempPosition;  //�ӽ� ��ġ�� �̵�
                poolItem.isActive = false;
                poolItem.gameObject.SetActive(false);
            }
        }
        activeCount = 0;
    }
}
