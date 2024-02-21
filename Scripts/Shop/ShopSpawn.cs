using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSpawn : MonoBehaviour
{
    [SerializeField]private GameObject _shop;
    [SerializeField]private Button _shopButton;
    [SerializeField]private Button _exitButton;
    

    void Start(){
        _shopButton.onClick.AddListener(SpawnShop);
        _exitButton.onClick.AddListener(ShopOff);
    }
    public void SpawnShop(){
        _shop.SetActive(true);
        LeanTween.moveLocal(_shop, new Vector3(0,0,0), 0.5f).setEase(LeanTweenType.easeInOutQuint);
    }
    public void ShopOff(){
        StartCoroutine(OffShopCor());
    }
    IEnumerator OffShopCor(){
        LeanTween.moveLocal(_shop, new Vector3(0,-2000,0), 0.5f).setEase(LeanTweenType.easeInOutQuint);
        yield return new WaitForSeconds(0.5f);
        _shop.SetActive(false);
    }
}
