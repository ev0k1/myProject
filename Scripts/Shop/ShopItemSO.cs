using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using TMPro;
[CreateAssetMenu(menuName ="ShopItem")]
public class ShopItemSO : ScriptableObject
{
    public Sprite image;
    public string price;
    public Purpose purpose;
}

public enum Purpose{
    forHead,
    forBody,
    forLegs,
    forFace
}
