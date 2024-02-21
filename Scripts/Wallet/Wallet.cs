using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DamageNumbersPro;


public class Wallet : MonoBehaviour
{
    public static Wallet instance{get; set;}
    [SerializeField]private TextMeshProUGUI moneyCount;
    [SerializeField]private float wallet;
    public float Money {get{return wallet;} set { wallet = value;}}
    [Header("DamNumPro")]
    [SerializeField]private DamageNumber numberPrefab;
    void Start()
    {
        instance = this;
        moneyCount.text = wallet.ToString();
    }
    public void AddMoney(float mon, Transform position, bool isDamNum){
        wallet += mon;
        string lastCount = NumbersRounding.FormatNums(wallet);
        string money = NumbersRounding.FormatNums(mon);
        if(isDamNum){
        DamageNumber damageNumber = numberPrefab.Spawn(Vector3.zero, money);
        damageNumber.SetAnchoredPosition(position,new Vector2(0,100));
        }
        moneyCount.text = lastCount;
    }
}
