using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpawnWheel : MonoBehaviour
{
    [SerializeField]private Button _casinoButton;
    [SerializeField]private Button _casinoExitButton;
    [SerializeField]private GameObject _casino;


    void Start()
    {
        _casinoButton.onClick.AddListener(OnCasino);
        _casinoExitButton.onClick.AddListener(OffCasino);
    }
    public void OffCasino(){
        StartCoroutine(OffCasCoroutine());
        
    }
    public void OnCasino(){
        _casino.SetActive(true);
        LeanTween.moveLocal(_casino, new Vector3(0,0,0), 0.5f).setEase(LeanTweenType.easeInOutQuad);
    }
    private IEnumerator OffCasCoroutine(){
        LeanTween.moveLocal(_casino, new Vector3(2000,0,0), 0.5f).setEase(LeanTweenType.easeInOutQuad);
        yield return new WaitForSeconds(0.5f);
        _casino.SetActive(false);
    }
}
