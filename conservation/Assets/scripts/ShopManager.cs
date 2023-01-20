using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;

    [SerializeField] private TextMeshProUGUI moneyInShopText;
    [SerializeField] private GameObject StorePanel;
    private bool wentToFactory = false;

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

    public void DisplayStore()
    {
        PlayerMoney.Instance.GetAndSavePaper();
        Time.timeScale = 0;
        StorePanel.SetActive(true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        wentToFactory = true;
    }

    public bool WentToFactory()
    {
        return wentToFactory;
    }

    public void SetWentToFactory(bool newVal)
    {
        StorePanel.SetActive(false);
        wentToFactory = newVal;
    }
}
