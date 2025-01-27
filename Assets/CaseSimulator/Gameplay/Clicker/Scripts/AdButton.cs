using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class AdButton : MonoBehaviour{
    [SerializeField] private int _countOfCoins;
    
    public void GetCoins() {
        AdManager.ShowRewardAd(1, _countOfCoins);
    }
}
