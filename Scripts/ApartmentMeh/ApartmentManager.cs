using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D;
using UnityEngine.UI;

public static class ButtonEventSys{
    public static void AddEventIndex<T> (this Button button, T param, Action<T> OnClick){
        button.onClick.AddListener(delegate(){
            OnClick(param);
        });
    }
}
public class ApartmentManager : MonoBehaviour
{ 
    [SerializeField]private List<ApartmentSO> apartments = new List<ApartmentSO>();
    [SerializeField]private GameObject _backgroundPref;
    [SerializeField]private GameObject _selectionMenu;
    [SerializeField]private RectTransform _backgroundParent;
    [SerializeField]private GameObject _addButton;
    [SerializeField]private List<GameObject> _apartmenList = new List<GameObject>();

    [Header("MainCard menu")]
    [SerializeField]private List<GameObject> _menuCards = new List<GameObject>();
    [SerializeField]private GameObject _mainMenuPrefab;
    [SerializeField]private RectTransform _mainMenuParent;
    [Header("Buttons")]
    [SerializeField]private Button _addBedApart;
    [SerializeField]private Button _addMiddleApart;
    [SerializeField]private Button _addRichApart;

    public static UnityEvent<ApartmentSO> onBadApartmentAddedEvent = new UnityEvent<ApartmentSO>();
    public static UnityEvent<ApartmentSO> onMiddleApartmentAddedEvent = new UnityEvent<ApartmentSO>();
    public static UnityEvent<ApartmentSO> onRichApartmentAddedEvent = new UnityEvent<ApartmentSO>();


    public void OpenSelectionMenu(){
       
    }
    public void AddApartment(ApartmentSO newApart){
        
        GameObject background = Instantiate(_backgroundPref, _backgroundParent);
        GameObject mainMenu = Instantiate(_mainMenuPrefab, _mainMenuParent);
        mainMenu.transform.SetSiblingIndex(2);
        _apartmenList.Add(background);
        _menuCards.Add(mainMenu);
        Button backgroundButton = background.GetComponentInChildren<Button>();   
        backgroundButton.AddEventIndex(this._apartmenList.IndexOf(background), CheckCurrentApartmentSelect);
        ApartmentItem apartmentItem = background.GetComponentInChildren<ApartmentItem>();
        apartmentItem.InitialiseItem(newApart);
        LeanTween.scale(background, new Vector3(1,1,1), 0.5f).setDelay(0.3f).setOnComplete(TweenUI.instance.CloseMenu).setEase(LeanTweenType.easeInOutBack);
        _addButton.transform.SetAsLastSibling();
        TweenUI.instance.CloseMenu();
        
    }
    public void BadApartmentAdded(){
        for(int i = 0; i < apartments.Count; i++){
            if(apartments[i].type == ApartmentType.BadApartment){
                onBadApartmentAddedEvent.Invoke(apartments[i]);
            }
        }
    }
    public void MiddleApartmentAdded(){
        for(int i = 0; i < apartments.Count; i++){
            if(apartments[i].type == ApartmentType.MiddleApartment){
                onMiddleApartmentAddedEvent.Invoke(apartments[i]);
            }
        }
    }
    public void RichApartmentAdded(){
        for(int i = 0; i < apartments.Count; i++){
            if(apartments[i].type == ApartmentType.RichApartment){
                onRichApartmentAddedEvent.Invoke(apartments[i]);
            }
        }
    }
    public void CheckCurrentApartmentSelect(int index){
        Debug.Log("Apartment Index" + index);
        for(int i = 0; i < _apartmenList.Count; i++){
                LeanTween.moveLocal(_menuCards[i], new Vector3(850,0,0), 0.5f).setEase(LeanTweenType.easeInOutCubic);
                if(i == index){
                    _menuCards[index].SetActive(true);
                    LeanTween.moveLocal(_menuCards[index], new Vector3(0,0,0), 0.5f).setEase(LeanTweenType.easeInOutCubic);
                }
        }
        
    }
    void Start()
    {
        onBadApartmentAddedEvent.AddListener(AddApartment);
        onMiddleApartmentAddedEvent.AddListener(AddApartment);
        onRichApartmentAddedEvent.AddListener(AddApartment);
        _addBedApart.onClick.AddListener(BadApartmentAdded);
        _addMiddleApart.onClick.AddListener(MiddleApartmentAdded);
        _addRichApart.onClick.AddListener(RichApartmentAdded);
        
    }

    
}
