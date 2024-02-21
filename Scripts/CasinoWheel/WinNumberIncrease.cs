using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WinNumberIncrease : MonoBehaviour
{
    public static WinNumberIncrease instance;
    private TextMeshProUGUI _text;

    void Start(){
        instance = this;
        _text = GetComponent<TextMeshProUGUI>();
    }
    public void CoroutineNumber(float currentNumber, float multiplierNumber, float time, float periodacity, float partOfTime){
        StartCoroutine(IncreaseNumber(currentNumber, multiplierNumber, time, periodacity, partOfTime));
    }
    public IEnumerator IncreaseNumber(float currentNumber, float multiplierNumber, float time, float periodacity, float partOfTime){
        float finalNumber = currentNumber * multiplierNumber;
        float delayTime = time / periodacity;
        float amount = finalNumber / partOfTime;
        _text.text = currentNumber.ToString();
        while(currentNumber < finalNumber){
            currentNumber += amount;
            _text.text = currentNumber.ToString();
            yield return new WaitForSeconds(delayTime);
        }
    }
}
