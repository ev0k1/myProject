using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApartmentItem : MonoBehaviour
{
   [SerializeField]private ApartmentSO _apartmentSO;
   [SerializeField]private Image _image;
   
    public void InitialiseItem(ApartmentSO newApartment){
        _apartmentSO = newApartment;
        _image.sprite = newApartment.image;
    }
    

    
    
   
}
