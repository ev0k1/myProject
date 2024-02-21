using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopItemExempl : MonoBehaviour
{
    [SerializeField]private ShopItemSO _shopItem;
    [SerializeField]private Image _showImage;
    [SerializeField]private TextMeshProUGUI _showText;
    [SerializeField]private Button _buyButton;
    [SerializeField]private Button _exitMenuButton;
    [SerializeField]private GameObject _menu;
    private TextMeshProUGUI _priceText;
    private Image _mainImage;
    void Start(){
        _priceText = GetComponentInChildren<TextMeshProUGUI>();
        _priceText.text = _shopItem.price;
        _showText.text = _shopItem.price;
        _mainImage = GetComponent<Image>();
        _mainImage.sprite = _shopItem.image;
        _showImage.sprite = _shopItem.image;
        _buyButton.onClick.AddListener(SpawnMenu);
        _exitMenuButton.onClick.AddListener(DeleteMenu);

    }
    private void SpawnMenu(){
        _menu.SetActive(true);
        LeanTween.scale(_menu, new Vector3(1,1,1), 0.5f).setEase(LeanTweenType.easeInOutQuint);
    }
    private void DeleteMenu(){
        StartCoroutine(DelMenuCor());
    }
    private IEnumerator DelMenuCor(){
        LeanTween.scale(_menu, new Vector3(0,0,0), 0.5f).setEase(LeanTweenType.easeInOutQuint);
        yield return new WaitForSeconds(0.5f);
        _menu.SetActive(false);
    }
}
