using System;
using System.Collections;
using System.Collections.Generic;
using CaseSimulator.Gameplay.MoneySystem;
using UnityEngine;
using YG;

namespace CaseSimulator.Gameplay.ClickerSystem
{
    [Serializable]
    public class Click{
        public int UpgradeCost;
        public int ClickCount;
    }
    
    public class Clicker : NewSouds
    {
        [SerializeField] private string _animatorBoolName = "OnClick";
        [SerializeField] private int _multiplier; 
        [SerializeField] private ParticlesClick _particlesClick;

        private Animator _animator;
        
        public Click[] Clicks;
        
        public static int NowAutoClick = 0;

        private void Awake()
        {
            _multiplier = YandexGame.savesData.Multipler;
            NowAutoClick = YandexGame.savesData.nowAutoClicks;
            
            _animator = GetComponent<Animator>();
        }

        private void Start() {
            StartCoroutine(AutoClick());
        }

        public void Save()
        {
            YandexGame.savesData.Multipler = _multiplier;
            YandexGame.savesData.nowAutoClicks = NowAutoClick;
            YandexGame.SaveProgress();
        }

        public void Click()
        {
            _animator.SetBool(_animatorBoolName, true);
            Bank.AddMoney(_multiplier);
            
            var mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePostion.z = 0;
            StartCoroutine(_particlesClick.ParticleSpawn(mousePostion));
            
           PlaySound(0, random: true);
        }
        
        public void AddMultipler(int toAdd)
        {
            _multiplier += toAdd;
            Save();
        }

        public void StopClickAnim()
        {
            _animator.SetBool(_animatorBoolName, false);
        }

        public int GetPrice() {
            return Clicks[NowAutoClick].UpgradeCost;
        }

        IEnumerator AutoClick() {
            while (true) {
                yield return new WaitForSeconds(1f);
                Bank.AddMoney(Clicks[NowAutoClick].ClickCount);
            }
        }
    }
}
