using System;
using System.Linq;
using CaseSimulator.Gameplay.ClickerSystem;
using CaseSimulator.Gameplay.MoneySystem;
using UnityEngine;
using UnityEngine.UI;

public class BuyNewClick : MonoBehaviour{
    [SerializeField] private Text text, text2;
    [SerializeField] private Clicker clicker;

    private void Start() => SetText();
    
    public void Buy() { 
        if(clicker.NowAutoClick > clicker.Clicks.Length-1) 
            return;
        
        if(Bank.GetMoney() <= clicker.Clicks[clicker.NowAutoClick+1].UpgradeCost)
            return;
        
        Bank.RemoveMoney(clicker.Clicks[clicker.NowAutoClick+1].UpgradeCost);
        clicker.NowAutoClick++;
        
        SetText();

        clicker.Save();
    }

    public void SetText() {
        if (clicker.Clicks.Length-1 == clicker.NowAutoClick) {
            text2.text = "Максимальный уровень";
            text.text = "Уровень: "+clicker.NowAutoClick.ToString();
        } else
        {
            text2.GetComponentInChildren<Text>().text = "Цена следующего уровеня: "+clicker.GetNextPrice();
            text.text = "Уровень: "+clicker.NowAutoClick.ToString();
        }
    }
}