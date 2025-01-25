using System.Collections;
using System.Collections.Generic;
using CaseSimulator.Gameplay.ClickerSystem;
using CaseSimulator.Gameplay.MoneySystem;
using UnityEngine;
using YG;

public class AdManager : MonoBehaviour
{

    private void OnEnable()
    {
		  YandexGame.RewardVideoEvent += Rewarded;
    }

    // Отписываемся от события открытия рекламы в OnDisable
    private void OnDisable()
    {
		  YandexGame.RewardVideoEvent -= Rewarded;
    }

    // Подписанный метод получения награды
    void Rewarded(int id)
    {
        if(id == 0)
        {
            AudioListener.volume = 1f;
            OpenPan.OnOpenPan?.Invoke();
            CaseSimulator.Gameplay.CaseSystem.Case.OnOpenCase?.Invoke();
        }

        if (id == 1) {
            Bank.AddMoney(100); //For example
        }
    }

    public static void ShowRewardAd(int id)
    {
        AudioListener.volume = 0f;
        YandexGame.RewVideoShow(id);
    }
}
