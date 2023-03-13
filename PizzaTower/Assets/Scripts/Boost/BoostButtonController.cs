using cky.Reuseables.Managers;
using DG.Tweening;
using PizzaTower.Helpers;
using PizzaTower.Managers;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace PizzaTower.Boost
{
    public class BoostButtonController : MonoBehaviour
    {
        [SerializeField] GameObject boostButtonGO;
        [SerializeField] Button boostButton;
        [SerializeField] float boostValue = 2.0f;
        [SerializeField] float boostTime = 5.0f;
        [SerializeField] float animationTime = 1.0f;
        WaitForSeconds _boostWfs;
        bool _isBoosting;
        EventManager _eventManager;

        private void Start()
        {
            _eventManager = (EventManager)EventManagerAbstract.Instance;
            _boostWfs = new WaitForSeconds(boostTime);

            BoostButtonActivate(false);
            boostButton.onClick.AddListener(Boost);

            EventManager.AddFloor += PopAfterFirstFloorAdded;
        }

        private void Boost()
        {
            if (_isBoosting == true) return;

            BoostButtonActivate(false);
            _eventManager.TriggerBoost(boostValue);
            _isBoosting = true;

            StartCoroutine(FinishBoost());
        }

        IEnumerator FinishBoost()
        {
            yield return _boostWfs;

            BoostButtonActivate(true);
            _eventManager.TriggerBoost();
            _isBoosting = false;
        }

        private void BoostButtonActivate(bool active)
        {
            if (active == true) BoostButtonOpeningAnimation();

            boostButtonGO.SetActive(active);
        }

        private void BoostButtonOpeningAnimation()
        {
            boostButtonGO.transform.BoostButtonOpeningAnimation(animationTime);
        }

        private void PopAfterFirstFloorAdded(int obj)
        {
            BoostButtonActivate(true);

            EventManager.AddFloor -= PopAfterFirstFloorAdded;
        }
    }
}