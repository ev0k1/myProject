using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class NewWheelScript : MonoBehaviour
{
    private RectTransform _rectTransform;
    private Vector3 rotate = new Vector3(0,0,1);
    [SerializeField]private float _speed;
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }
    void FixedUpdate(){
        StartCoroutine(Rotate());
    }
    public IEnumerator Rotate(){
        transform.eulerAngles += rotate * -_speed * Time.fixedDeltaTime;
        yield return new WaitForSeconds(2);
        transform.eulerAngles -= rotate * -_speed * Time.fixedDeltaTime;
    }
    public void Ishak(){
        StartCoroutine(Rotate());
    }
}
