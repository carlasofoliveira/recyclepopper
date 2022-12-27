using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ShopItem : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemPriceText;

    [Header("Values")]
    public ShopItems ItemType;
    public enum ShopItems
    {
        strongerOars,
        placeholder
    }

    [SerializeField] private string itemName = "Placeholder";
    [SerializeField] private int itemPrice = 10;
    [SerializeField] private int itemLevel;
    [SerializeField] private int itemLevelMax = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }
     
    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        UpdateItemUI();
        ShopManager.Instance.UpdateMoneyInShopUI();
    }

    public void BuyItem()
    {
        if (itemLevel < itemLevelMax && PlayerMoney.Instance.ReturnCurrentpaper() >= itemPrice)
        {
            itemLevel++;
            PlayerPrefs.SetInt(ItemType.ToString(), itemLevel);

            PlayerMoney.Instance.AddPaperAndSave(-itemPrice);

            UpdateItemUI();
            ShopManager.Instance.UpdateMoneyInShopUI();
        }
    }

    private void UpdateItemUI()
    {
        itemLevel = PlayerPrefs.GetInt(ItemType.ToString());

        itemNameText.text = "LV. " + itemLevel + " " + itemName;
        itemPriceText.text = itemPrice + " G";

        if (itemLevel == itemLevelMax)
        {
            itemNameText.text = "MAX LV: " + itemName;
            itemPriceText.text = "0 G";
        }
    }
}
