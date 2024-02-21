using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class SettingsMenuScript : MonoBehaviour
{
    public static SettingsMenuScript Instance;
    public int CurrentCount = 0;
    [Header("Button Settings")]
    public Button UpModelButton;
    public Button UpCoolingButton;
    public Button UpProdictivityButton;
    public Button UpProfitFromClickButton;
    public Image CurrentCard;

    [Header("FillAmountSettings")]
    
    [SerializeField]private Image _fillAmUpModel;
    [SerializeField]private Image _fillAmUpCooling;
    [SerializeField]private Image _fillAmUpProductivity;
    [SerializeField]private Image _fillAmUpProfitFromClick;
    [Header("Start Settings")]
    private float _startFillAmUpModel = 1;
    private float _startFillAmCooling = 1;
    private float _startFillAmProdictivity = 1;
    private float _startFillAmProfitFromCkick = 1;

    private float _modelCount;
    private float _coolingUpCount;
    private float _productivityUpCount;
    private float _profitFromClickUpCount;
    
    private void StartInitialise(){
        _modelCount = CardManager.Instance.ModelCount;
        _coolingUpCount = CardManager.Instance.CoolingUpCount;
        _productivityUpCount = CardManager.Instance.ProductivityUpCount;
        _profitFromClickUpCount = CardManager.Instance.ProfitFromCkickCount;

        _fillAmUpModel.fillAmount = _startFillAmUpModel/_modelCount;
        _fillAmUpCooling.fillAmount = _startFillAmCooling/_coolingUpCount;
        _fillAmUpProductivity.fillAmount = _startFillAmProdictivity/_productivityUpCount;
        _fillAmUpProfitFromClick.fillAmount = _startFillAmProfitFromCkick/_profitFromClickUpCount;

    }
    private void Buttons(){
        UpModelButton = transform.GetChild(1).GetComponentInChildren<Button>();
        UpCoolingButton = transform.GetChild(2).GetComponentInChildren<Button>();
        UpProdictivityButton = transform.GetChild(3).GetComponentInChildren<Button>();
        UpProfitFromClickButton = transform.GetChild(4).GetComponentInChildren<Button>();
    }
    void Start(){
        
        StartInitialise();
        Instance = this;
        Buttons();
    }
    public void UpdateModelUpParametres(float modelCount, float coolingUpCount, float productivityUpCount){
        _fillAmUpModel.fillAmount = modelCount/_modelCount;
        _fillAmUpCooling.fillAmount = coolingUpCount/_coolingUpCount;
        _fillAmUpProductivity.fillAmount = productivityUpCount/_productivityUpCount;
    }
    public void UpdateCoolingParametres(float coolingUpCount){
        _fillAmUpCooling.fillAmount = coolingUpCount/_coolingUpCount;
    }
    public void UpdateProductivityUpParametres(float productivityUpCount){
        _fillAmUpProductivity.fillAmount = productivityUpCount/_productivityUpCount;
    }
}
