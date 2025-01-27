using System.Collections;
using System.Collections.Generic;
using CaseSimulator.Gameplay.ClickerSystem;
using UnityEngine;

public class ResetAutoClickButton : MonoBehaviour{
    [SerializeField] private Clicker clicker;
    [SerializeField] private BuyNewClick _buyNewClick;

    public void ResetButton() {
        clicker.NowAutoClick = 0;
        clicker.Save();
        
        _buyNewClick.SetText();
    }
}
