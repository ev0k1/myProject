using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class TweenUI : MonoBehaviour
{
    public static TweenUI instance;
    [Header("MainApartmentButton")]
    [SerializeField]private GameObject _allMenu;
    [SerializeField]private GameObject _mainMenu;
    [SerializeField]private GameObject _badApartButton;
    [SerializeField]private GameObject _middleApartButton;
    [SerializeField]private GameObject _richApartButton;
    [Header("Price Button")]
    private GameObject _badApartmentPrice;
    private GameObject _middleApartmentPrice;
    private GameObject _richApartmentPrice;
    [Header("Timer")]
    private float _lastTapTime;
    private float _delay = 0.9f;
    void Start(){
        _lastTapTime = 0.9f;
        instance = this;
        _badApartmentPrice = _badApartButton.transform.GetChild(0).GameObject();
        _middleApartmentPrice = _middleApartButton.transform.GetChild(0).GameObject();
        _richApartmentPrice = _richApartButton.transform.GetChild(0).GameObject();
    }
    private void MoveOpen(){
        _allMenu.SetActive(true);
        LeanTween.moveLocal(_mainMenu, new Vector2(0, 0), 0.5f).setDelay(0.1f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveLocal(_badApartButton, new  Vector2(0, 520), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeOutQuint);
        LeanTween.moveLocal(_middleApartButton, new  Vector2(0, 130), 0.5f).setDelay(0.4f).setEase(LeanTweenType.easeOutQuint);
        LeanTween.moveLocal(_richApartButton, new  Vector2(0, -260), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutQuint);
    }
    private void MoveClose(){
        StartCoroutine(MoveMenuClose());
    }
    public void MainMenuOpen(){
        if(_lastTapTime >= _delay){
            _lastTapTime = 0;
            MoveOpen();
            PriceMoveOpen();
        }
        else return;
    }
    private void PriceMoveOpen(){
       
        LeanTween.moveLocal(_badApartmentPrice, new Vector2(0, -165), 0.3f).setDelay(0.45f).setOnComplete(MoveOpen).setEase(LeanTweenType.easeOutQuad);
        LeanTween.moveLocal(_middleApartmentPrice, new Vector2(0, -165), 0.3f).setDelay(0.55f).setOnComplete(MoveOpen).setEase(LeanTweenType.easeOutQuad);
        LeanTween.moveLocal(_richApartmentPrice, new Vector2(0, -165), 0.3f).setDelay(0.65f).setOnComplete(MoveOpen).setEase(LeanTweenType.easeOutQuad);
    }
    private void PriceMoveClose(){
        LeanTween.moveLocal(_badApartmentPrice, new Vector2(0, 0), 0.3f).setDelay(0.45f).setEase(LeanTweenType.easeOutQuad);
        LeanTween.moveLocal(_middleApartmentPrice, new Vector2(0, 0), 0.3f).setDelay(0.45f).setEase(LeanTweenType.easeOutQuad);
        LeanTween.moveLocal(_richApartmentPrice, new Vector2(0, 0), 0.3f).setDelay(0.45f).setEase(LeanTweenType.easeOutQuad);
    }
    public void CloseMenu(){
        if(_lastTapTime >= _delay){
            _lastTapTime = 0;
            MoveClose();
        }
        else return;
    }
    void Update(){
        _lastTapTime += Time.deltaTime;
    }
    IEnumerator MoveMenuClose(){
        LeanTween.moveLocal(_mainMenu, new Vector2(0, -1900), 0.5f).setDelay(0.1f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveLocal(_badApartButton, new  Vector2(0, -1900), 0.5f).setDelay(0.15f).setEase(LeanTweenType.easeOutBack);
        LeanTween.moveLocal(_middleApartButton, new  Vector2(0, -1900), 0.5f).setDelay(0.25f).setEase(LeanTweenType.easeOutBack);
        LeanTween.moveLocal(_richApartButton, new  Vector2(0, -1900), 0.5f).setDelay(0.35f).setEase(LeanTweenType.easeOutBack);
        PriceMoveClose();
        yield return new WaitForSeconds(1f);
        _allMenu.SetActive(false);
    }
}
