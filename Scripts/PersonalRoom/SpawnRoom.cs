using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnRoom : MonoBehaviour
{
    [SerializeField]private Button _roomButton;
    [SerializeField]private Button _roomExitButton;
    [SerializeField]private GameObject _room;


    void Start()
    {
        _roomButton.onClick.AddListener(OnCasino);
        _roomExitButton.onClick.AddListener(OffCasino);
    }
    public void OffCasino(){
        StartCoroutine(OffCasCoroutine());
        
    }
    public void OnCasino(){
        _room.SetActive(true);
        LeanTween.moveLocal(_room, new Vector3(0,0,0), 0.5f).setEase(LeanTweenType.easeInOutQuad);
    }
    private IEnumerator OffCasCoroutine(){
        LeanTween.moveLocal(_room, new Vector3(-2000,0,0), 0.5f).setEase(LeanTweenType.easeInOutQuad);
        yield return new WaitForSeconds(0.5f);
        _room.SetActive(false);
    }
}
