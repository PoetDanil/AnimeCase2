using System;
using System.Linq;
using CaseSimulator.Gameplay.ClickerSystem;
using CaseSimulator.Gameplay.MoneySystem;
using UnityEngine;
using UnityEngine.UI;

public class BuyNewClick : MonoBehaviour{
    [SerializeField] private Button but;
    [SerializeField] private Text text;
    [SerializeField] private Clicker clicker;

    private void Start() {
        SetText();
    }

    public void Buy() { 
        if(Clicker.NowAutoClick > clicker.Clicks.Length-1) 
            return;
        
        if(Bank.GetMoney() <= clicker.Clicks[Clicker.NowAutoClick].UpgradeCost)
            return;
            
        Clicker.NowAutoClick++;
        Bank.RemoveMoney(clicker.Clicks[Clicker.NowAutoClick].UpgradeCost);
            
        SetText();

        clicker.Save();
    }

    void SetText() {
        if (clicker.Clicks.Length-1 == Clicker.NowAutoClick) {
            but.GetComponentInChildren<Text>().text = "Максимальный уровень";
            text.text = "Текущий уровень: "+Clicker.NowAutoClick.ToString();
        } else
        {
            but.GetComponentInChildren<Text>().text = "Следующий уровень: "+clicker.GetPrice();
            text.text = "Текущий уровень: "+Clicker.NowAutoClick.ToString();
        }
    }
}