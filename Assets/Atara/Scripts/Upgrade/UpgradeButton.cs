using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField]
    private GameObject upObject;
    [SerializeField]
    private int id;

    private UpgradeManager upgradeManager;

    private void Awake()
    {
        upgradeManager = GetComponentInParent<UpgradeManager>();
    }

    public void AddAnimals()
    {
        upgradeManager.AddAnimals(id, upObject);
    }

    public void UpAnimals()
    {
        upgradeManager.UpgradeAnimals(id, upObject);
    }
}
