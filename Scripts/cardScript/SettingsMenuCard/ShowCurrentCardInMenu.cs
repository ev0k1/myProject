using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCurrentCardInMenu : MonoBehaviour
{
    [Header("Main Settings")]
    private CardSO _card;
    public Image _image;
    private int _cardCount;
    

    [Header("Vint Settings")]
    private GameObject[] _vintPref;
    private GameObject[] _vints;
    
    void Start(){
        _cardCount = 0;
        _card = CardManager.Instance._cards[_cardCount];
        InitialiseCard(_card);
    }
    public void InitialiseCard(CardSO newCard){
        _card = newCard;
        _image.sprite = newCard.image;
        
        
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
    private void VisualCoolingUP(CardSO newCard){
        _image.sprite = newCard.imageCoolingUp;
        ClearCollection(_vints);
        _vintPref = newCard.coolingVintPref;
        _vints = new GameObject[_vintPref.Length];
        SpawnCollection(_vints, _vintPref);
    }
    public void CoolingUP(){
            VisualCoolingUP(_card);
    }
    public void ModelUP(){
        _cardCount++;
        _card = CardManager.Instance._cards[_cardCount];
        
            ClearCollection(_vints);
            InitialiseCard(_card);
        
        
    }

}
