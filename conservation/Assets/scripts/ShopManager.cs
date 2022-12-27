using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;

    [SerializeField] private TextMeshProUGUI moneyInShopText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateMoneyInShopUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateMoneyInShopUI()
    {
        moneyInShopText.text = PlayerMoney.Instance.ReturnCurrentpaper() + " PAPER";
    }

    public void AddPaperDebug()
    {
        PlayerMoney.Instance.AddPaperAndSave(1000);
        UpdateMoneyInShopUI();
    }
}
