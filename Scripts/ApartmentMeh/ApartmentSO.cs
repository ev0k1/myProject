using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Apartment")]
public class ApartmentSO : ScriptableObject
{
    [Header("Main Parametres")]
    public Sprite image;
    public ApartmentType type;
}
public enum ApartmentType{
    BadApartment,
    MiddleApartment,
    RichApartment
}