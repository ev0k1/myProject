using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardManager : MonoBehaviour
{
    public static CardManager Instance;
    [Header("Main Settings")]
    private CardSO _card;
    public Image _image;
    private int _cardCount;
    public CardSO[] _cards;
    [Header("Current Card Settings")]
    private float _currentProfit;
    private float _model;
    public float CurrentModelCount{get{return _model;}  set{value = _model;}}
    public float CoolingUpCurrentLvl;
    public float ProductivityUpCurrentLvl;
    public float ProfitFromClickUpCurrentLvl;
    [Header("Lvl Settings")]
    [SerializeField]private float _modelCount;
    public float ModelCount{get{return _modelCount;} private set{value = _modelCount;}}
    [SerializeField]private float _coolingUpCount;
    public float CoolingUpCount{get{return _coolingUpCount;} private set{value = _coolingUpCount;}}
    [SerializeField]private float _prodictivityUpCount;
    public float ProductivityUpCount{get{return _prodictivityUpCount;} private set{value = _prodictivityUpCount;}}
    [SerializeField]private float _profitFromCkickCount;
    public float ProfitFromCkickCount{get{return _profitFromCkickCount;}private set{value = _profitFromCkickCount;}}
    [Header("Boost Settings")]
    private float _coolingMultiplier;
    private float _productivityMultiplier;
    private float _profitFromClickMultiplier;
    private float _currentModelProfit;

    [Header("Vint Settings")]
    private GameObject[] _vintPref;
    private GameObject[] _vints;
    [Header("Timer")]
    private float _timer;
    [SerializeField]private float _profitFromTimer;
    
    void Start(){
        Instance = this;
        _cardCount = 0;
        _card = _cards[_cardCount];
        InitialiseCard(_card);
    }
    public void InitialiseCard(CardSO newCard){
        _card = newCard;
        _image.sprite = newCard.image;
        _model = newCard.modelLvl;
        CoolingUpCurrentLvl = 1;
        ProductivityUpCurrentLvl = 1;
        ProfitFromClickUpCurrentLvl = 1;
        _currentModelProfit = newCard.modelUpProfit;
        _productivityMultiplier = newCard.productivityUpMultiplier;
        _coolingMultiplier = newCard.coolingUpMultimlier;
        _profitFromClickMultiplier = newCard.profitFromClickMultiplier;
        _currentProfit = _currentModelProfit;
        _profitFromTimer = newCard.profitFromTime;
        
        _vintPref = newCard.mainVintPref;
        _vints = new GameObject[_vintPref.Length];
        SpawnCollection(_vints, _vintPref);
        
    }

    private void SpawnCollection(GameObject[]vint, GameObject[]spawningItem){
        for(int i = 0; i < vint.Length; i++){
            vint[i] = Instantiate(spawningItem[i], transform);
        }
    }
    private void ClearCollection(GameObject[]vint){
        for(int i = 0; i < vint.Length; i++){
                Destroy(vint[i]);
            }
    }
    private void MoneyFromTimer(float time){
         _timer += Time.deltaTime;
        if(_timer >= time){
            Wallet.instance.AddMoney(_currentProfit, transform, true);
            _timer = 0f;
        }
    }
    private void ProfitBoost(ref float baseParametres, float multiplier, float lvl){
        float parametres = baseParametres * Mathf.Pow(multiplier, lvl);
        _currentProfit = parametres;
        
    }
    private void VisualCoolingUP(CardSO newCard){
        _image.sprite = newCard.imageCoolingUp;
        ClearCollection(_vints);
        _vintPref = newCard.coolingVintPref;
        _vints = new GameObject[_vintPref.Length];
        SpawnCollection(_vints, _vintPref);
    }
    public void ModelUP(){
        _cardCount++;
        _card = _cards[_cardCount];
        ClearCollection(_vints);
        InitialiseCard(_card);  
    }
    public void CoolingUP(){
        if(CoolingUpCurrentLvl <= _coolingUpCount){
            CoolingUpCurrentLvl++;
            ProfitBoost(ref _currentProfit, _coolingMultiplier, CoolingUpCurrentLvl);
            VisualCoolingUP(_card);
            }
        else
            return;  
        
    }
    public void ProductivityUP(){
        if(ProductivityUpCurrentLvl <= ProductivityUpCount){
        ProductivityUpCurrentLvl++;
        ProfitBoost(ref _currentProfit, _productivityMultiplier, ProductivityUpCurrentLvl);
        }
        else
            return;
    }
    void Update(){
        MoneyFromTimer(_profitFromTimer);
    }






}

