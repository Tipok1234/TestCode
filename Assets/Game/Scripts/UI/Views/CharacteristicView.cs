using System;
using Datas;
using DG.Tweening;
using Interfaces;
using DataUtils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class CharacteristicView : View<CharacteristicData>, IBuyingView
    {
        public event Action BuyAction;
        
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private TMP_Text valueText;
        [SerializeField] private TMP_Text priceText;
        
        [SerializeField] private Button buyButton;
        
        [SerializeField] private float duration;
        
        public CharacteristicData Data { get; private set; }
        
        private Tween _tween;

        private void OnDisable()
        {
            _tween?.Kill();
        }

        public override void Setup(CharacteristicData data)
        {
            Data = data;
            Refresh();
        }

        public override void Refresh()
        {
            AnimateShow();
            ShowDescription();
            ShowValue();
            ShowPrice();
            SetStateButton();
        }

        public void OnBuyButtonClicked()
        {
            GameSaves.Instance.RemoveCoin((int)Data.Price);
            GameSaves.Instance.SaveCharacteristic(Data);
            BuyAction?.Invoke();   
        }
        
        private void AnimateShow()
        {
            transform.localScale = Vector3.zero;
            _tween = transform.DOScale(Vector3.one, duration);
        }

        private void SetStateButton()
        {
            if (buyButton)
                buyButton.interactable = GameSaves.Instance.GetCoin() >= Data.Price;
        }
        
        private void ShowDescription()
        {
            if(descriptionText)
                descriptionText.text = Data.Description;
        }

        private void ShowValue()
        {
            if(valueText)
                valueText.text = Data.Value.ToString();
        }

        private void ShowPrice()
        {
            if(priceText)
                priceText.text = Data.Price.ToString();
        }
    }
}
