using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.UIElements;
using DG.Tweening.Core.Easing;

public class WheelScript : MonoBehaviour
{
    [Header("Win Settings")]
    private GameObject spawnObj;
    private GameObject spawnPart;
    [SerializeField]private GameObject _particlePref;
    [SerializeField]private RectTransform _particlePrefParent;
    [SerializeField]private GameObject _winTextPref;
    [SerializeField]private RectTransform _winTextParent;
    [SerializeField]private GameObject _blackFon;
    private GameObject _butSpawn;
    [SerializeField]private GameObject _buttonPref;
    [Header("Spin Settings")]
    [SerializeField]private float _minRotatePower;
    [SerializeField]private float _maxRotatePower;
    [SerializeField]private float _minStopPower;
    [SerializeField]private float _maxStopPower;
    private Rigidbody2D _rb;
    private bool _inRot;
    private RectTransform _rectTransform;
    private GameObject _thisGO;



    private float timer;
    void Start()
    {
        _thisGO = GetComponent<GameObject>();
        _rectTransform = GetComponent<RectTransform>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(_rb.angularVelocity > 0){
            _rb.angularVelocity -= Random.Range(_minStopPower, _maxStopPower) * Time.fixedDeltaTime;
            _rb.angularVelocity = Mathf.Clamp(_rb.angularVelocity, 0, 1440);
        }

        if(_rb.angularVelocity == 0 && _inRot){
            timer += Time.fixedDeltaTime;
            if(timer >= 0.5f){
                AddReward();
                _inRot = false;
                timer = 0;
            }
        }

    }
    public void Rotate(){
        if(!_inRot){
            _rb.AddTorque(Random.Range(_minRotatePower, _maxRotatePower));
            _inRot = true;
        }
    }
    public void AddReward(){
        float rot = transform.eulerAngles.z;

        if(rot > 0+15 && rot < 30 + 15){
            _rectTransform.DORotate(new Vector3(0,0,30), 0.5f);
            Debug.Log(100);
            StartCoroutine(IncreaseNumber( 1000, 15,5));
        }
        else if(rot > 30 + 15 && rot < 60 + 15){
            _rectTransform.DORotate(new Vector3(0,0,60), 0.5f);
            Debug.Log(200);
            StartCoroutine(IncreaseNumber( 1000, 15,5));
        }
        else if(rot > 60 + 15 && rot < 90 + 15){
            _rectTransform.DORotate(new Vector3(0,0,90), 0.5f);
            StartCoroutine(IncreaseNumber( 1000, 15,5));
        }
        else if(rot > 90 + 15 && rot < 120 + 15){
            _rectTransform.DORotate(new Vector3(0,0,120), 0.5f);
            Debug.Log(400);
            StartCoroutine(IncreaseNumber( 1000, 15,5));
        }
        else if(rot > 120 + 15 && rot < 150 + 15){
            _rectTransform.DORotate(new Vector3(0,0,150), 0.5f);
            Debug.Log(500);
            StartCoroutine(IncreaseNumber( 1000, 15,5));
        }
        else if(rot > 150 + 15 && rot < 180 + 15){
            _rectTransform.DORotate(new Vector3(0,0,180), 0.5f);
            Debug.Log(600);
            StartCoroutine(IncreaseNumber( 1000, 15,5));
        }
        else if(rot > 180 + 15 && rot < 210 + 15){
            _rectTransform.DORotate(new Vector3(0,0,210), 0.5f);
            Debug.Log(700);
            StartCoroutine(IncreaseNumber( 1000, 15,5));
        }
        else if(rot > 210 + 15 && rot < 240 + 15){
            _rectTransform.DORotate(new Vector3(0,0,240), 0.5f);
            Debug.Log(800);
            StartCoroutine(IncreaseNumber(1000, 15,5));
        }
        else if(rot > 240 + 15 && rot < 270 + 15){
            _rectTransform.DORotate(new Vector3(0,0,270), 0.5f);
            Debug.Log(900);
            StartCoroutine(IncreaseNumber( 1000, 15,5));
        }
        else if(rot > 270 + 15 && rot < 300 + 15){
            _rectTransform.DORotate(new Vector3(0,0,300), 0.5f);
            Debug.Log(1000);
            StartCoroutine(IncreaseNumber( 1000, 15,5));
        }
        else if(rot > 300 + 15 && rot < 330 + 15){
            _rectTransform.DORotate(new Vector3(0,0,330), 0.5f);
            Debug.Log(1100);
            StartCoroutine(IncreaseNumber( 1000, 15,5));
        }
        else if(rot > 330 + 15 && rot < 360 + 15 || rot <= 15){
            _rectTransform.DORotate(new Vector3(0,0,0), 0.5f);
            Debug.Log(1200);
            StartCoroutine(IncreaseNumber( 1000, 15,5));
        }
    }
    public void DeleteWinPanel(){
        _blackFon.SetActive(false);
        Destroy(spawnPart);
        LeanTween.scale(spawnObj, new Vector3(0,0,0), 0.15f).setEase(LeanTweenType.easeInOutSine);
        Destroy(spawnObj, 0.15f);
        
    }
    
    public IEnumerator IncreaseNumber(float currentNumber, float multiplierNumber,float time){
        _blackFon.SetActive(true);
        _blackFon.SetActive(true);
        spawnPart = Instantiate(_particlePref, _particlePrefParent);
        spawnObj = Instantiate(_winTextPref, _winTextParent);
        LeanTween.scale(spawnObj, new Vector3(1,1,1), 0.5f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(spawnObj.transform.GetChild(0).gameObject, new Vector3(1.5f,1.5f,1.5f), 0.5f).setLoopPingPong(6).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(spawnObj.transform.GetChild(1).gameObject, new Vector3(1.3f,1.3f,1.3f), 0.5f).setLoopPingPong(6).setEase(LeanTweenType.easeInOutSine);
        
        TextMeshProUGUI textObj = spawnObj.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        float finalNumber = currentNumber * multiplierNumber;
        float delayTime = time / 259;
        float amount = finalNumber / time * delayTime;
        textObj.text = currentNumber.ToString();
        while(currentNumber < finalNumber){
            currentNumber += (int)amount;
            textObj.text = currentNumber.ToString();
            yield return new WaitForSeconds(delayTime);
            if(currentNumber >= finalNumber){
                currentNumber = finalNumber;
                textObj.text = currentNumber.ToString();
                Wallet.instance.AddMoney(finalNumber, transform, false);
                break;
            }
        }
        yield return new WaitForSeconds(0.5f);
        _butSpawn = Instantiate(_buttonPref, spawnObj.transform);
        _butSpawn.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(DeleteWinPanel);
        LeanTween.scale(_butSpawn, new Vector3(1,1f,1f), 0.3f).setEase(LeanTweenType.easeInOutSine);
        yield return new WaitForSeconds(0.3f);
        _butSpawn.transform.localScale = new Vector3(1,1,1);
        LeanTween.scale(_butSpawn, new Vector3(1.2f,1.2f,1.2f), 0.5f).setLoopPingPong().setEase(LeanTweenType.easeInOutSine);
    }
}
