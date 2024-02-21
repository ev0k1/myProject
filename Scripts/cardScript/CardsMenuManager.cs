using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsMenuManager : MonoBehaviour
{
    public static CardsMenuManager Instance;
    [Header("Cells Parametres")]
    private Button _addButton;
    [SerializeField]private GameObject _menuCellPref;
    [SerializeField]private List<GameObject> _menuCellsList = new List<GameObject>();
    [Header("Settings Menu Paramenres")]
    [SerializeField]private GameObject _settingsMenuPref;
    [SerializeField]private RectTransform _settingsMenuParent;
    [SerializeField]private List<GameObject> _settingsMenuCells = new List<GameObject>();
    public List<GameObject> SettingsMenuCells{get{return _settingsMenuCells;} private set{value = _settingsMenuCells;}}
    private GameObject _menuCell;
    private Button exitSettingMenuButton;
    private Button _currentUpModelButon;
    private Button _currentUpCoolingButton;
    private Button _currentUpProductivityButton;
    private Button _currentUpProfitFromClickButton;
    
    void Start(){
        Instance = this;
        _addButton = transform.GetChild(0).GetComponent<Button>();
        _addButton.onClick.AddListener(AddCardsMenu);
         
    }
    public void AddCardsMenu(){
        _menuCell = Instantiate(_menuCellPref, transform);
        _menuCellsList.Add(_menuCell);
        LeanTween.scale(_menuCell, new Vector3(1,1,1), 0.5f).setEase(LeanTweenType.easeOutBack);
        GameObject settingMenu = Instantiate(_settingsMenuPref, _settingsMenuParent);
        exitSettingMenuButton = settingMenu.transform.GetChild(0).GetComponent<Button>();
        SettingsMenuScript startMenuSett = settingMenu.GetComponent<SettingsMenuScript>();
        _settingsMenuCells.Add(settingMenu);
        
        _menuCell.GetComponent<Button>().AddEventIndex(this._settingsMenuCells.IndexOf(settingMenu), CheckCurrentSettingMenuSelect);
        exitSettingMenuButton.AddEventIndex(this._settingsMenuCells.IndexOf(settingMenu), ExitSettingsMenuButton);
        
    }
    public void ExitSettingsMenuButton(int index){
        StartCoroutine(ExitCoroutine(index));
    }
    public void UpdateCurrentCardModel(int index){
        CardManager curCard = _menuCellsList[index].GetComponentInChildren<CardManager>();
        SettingsMenuScript setMenu = _settingsMenuCells[index].GetComponent<SettingsMenuScript>();
        curCard.ModelUP();
        ShowCurrentCardInMenu currentCardInMenu = setMenu.GetComponentInChildren<ShowCurrentCardInMenu>();
        currentCardInMenu.ModelUP();
        setMenu.UpdateModelUpParametres(curCard.CurrentModelCount, curCard.CoolingUpCurrentLvl, curCard.ProductivityUpCurrentLvl);
    }
    public void UpdateCurrentCoolingUp(int index){
        CardManager curCard = _menuCellsList[index].GetComponentInChildren<CardManager>();
        SettingsMenuScript setMenu = _settingsMenuCells[index].GetComponent<SettingsMenuScript>();
        ShowCurrentCardInMenu currentCardInMenu = setMenu.GetComponentInChildren<ShowCurrentCardInMenu>();
        curCard.CoolingUP();
        currentCardInMenu.CoolingUP();
        setMenu.UpdateCoolingParametres(curCard.CoolingUpCurrentLvl);
    }
    public void UpdateCurrentProdictivityUp(int index){
        CardManager curCard = _menuCellsList[index].GetComponentInChildren<CardManager>();
        SettingsMenuScript setMenu = _settingsMenuCells[index].GetComponent<SettingsMenuScript>();
        curCard.ProductivityUP();
        setMenu.UpdateProductivityUpParametres(curCard.ProductivityUpCurrentLvl);
    }
    
    public void CheckCurrentSettingMenuSelect(int index){
        Debug.Log("Check Index" + index);
        _currentUpModelButon = _settingsMenuCells[index].transform.GetChild(1).GetComponentInChildren<Button>();
        _currentUpModelButon.AddEventIndex(index, UpdateCurrentCardModel);
        _currentUpCoolingButton = _settingsMenuCells[index].transform.GetChild(2).GetComponentInChildren<Button>();
        _currentUpCoolingButton.AddEventIndex(index, UpdateCurrentCoolingUp);
        _currentUpProductivityButton = _settingsMenuCells[index].transform.GetChild(3).GetComponentInChildren<Button>();
        _currentUpProductivityButton.AddEventIndex(index, UpdateCurrentProdictivityUp);
        _settingsMenuCells[index].SetActive(true);
        LeanTween.moveLocal(_settingsMenuCells[index], new Vector3(0,0,0),0.2f).setEase(LeanTweenType.easeInOutQuad);
    }
    public IEnumerator ExitCoroutine(int index){
        for(int i = 0; i < _settingsMenuCells.Count; i++){
                if(i == index){
                    LeanTween.moveLocal(_settingsMenuCells[index], new Vector3(0,-1900,0),0.2f).setEase(LeanTweenType.easeInOutQuad);
                    yield return new WaitForSeconds(0.2f);
                    _settingsMenuCells[index].SetActive(false);
                }
                
        }
    }
    
}
