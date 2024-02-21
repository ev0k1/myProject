using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "GraphCard")]
public class CardSO : ScriptableObject
{

[Header("Main Card Settings")]
public CardType type;
public Sprite image;
public float modelLvl;
public float profitFromTime;
[Header("Cooling & Vints")]
public Sprite imageCoolingUp;
public GameObject[] mainVintPref;
public GameObject[] coolingVintPref;
[Header("Profit & Boost")]
public float modelUpProfit;
public float coolingUpMultimlier;
public float productivityUpMultiplier;
public float profitFromClickMultiplier;
}
public enum CardType{
    gt9600,
    rtx2060,
    rtx2060S
}
