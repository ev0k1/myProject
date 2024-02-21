using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundAnim : MonoBehaviour
{
    private RawImage _image;
    [SerializeField]private float _directionX;
    [SerializeField]private float _directionY;
    [SerializeField]private float _speed;

    void Start(){
        _image = GetComponent<RawImage>();

    }
    void Update(){
        _directionX += _speed * Time.deltaTime;
        _directionY += _speed * Time.deltaTime;

        _image.uvRect = new Rect(_directionX, _directionY, _image.uvRect.width, _image.uvRect.height);
    }
}
