using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class PointableMarker : MonoBehaviour
{
    [Header("Model")]
    public GameObject sphere;
    public GameObject q;
    public GameObject x;
    public Ease qEase, xEase;
    public float qSpinSpeed;
    [SerializeField] private Color qNormalColor, qHoverColor, qPressedColor;
    [SerializeField] private Color xNormalColor, xHoverColor, xPressedColor;
    [SerializeField] private Color sphereNormalColor, sphereHoverColor, spherePressedColor;
    [SerializeField] private float time;
    public Action<bool> onToggle;
    public UnityEvent onToggleTrue;
    public UnityEvent onToggleFalse;
    public float ratio = 0.8f;

    public Transform targetObject;
    private Vector3 targetScale;
    public GameObject outlineObject;
    
    private Material _sphereMaterial, _qMaterial, _xMaterial;
    private bool _isOn, _isPlayingQ;
    private WaitForSeconds _waitForSeconds, _waitForHalfSeconds;
    private Tweener openQ, closeQ;
    private Transform _eyeTransform;

    private void Awake()
    {
        outlineObject.SetActive(false);
        targetScale = targetObject.localScale;
        x.SetActive(false);
        _waitForSeconds = new WaitForSeconds(time);
        _waitForHalfSeconds = new WaitForSeconds(time * 0.6f);
        _sphereMaterial = sphere.GetComponent<MeshRenderer>().material;
        _qMaterial = q.GetComponent<MeshRenderer>().material;
        _xMaterial = x.GetComponentInChildren<MeshRenderer>().material;
        _sphereMaterial.DOColor(sphereNormalColor, time);
        _qMaterial.DOColor(qNormalColor, time);
        _xMaterial.DOColor(xNormalColor, time);
    }

    private void Start()
    {
        _eyeTransform = PlayerManager.Instance.eyeTransform;
    }

    public void OnHoverEnter()
    {
        _sphereMaterial.DOColor(sphereHoverColor, time);
        if (_isOn) _xMaterial.DOColor(xHoverColor, time);
        else _qMaterial.DOColor(qHoverColor, time);
    }

    public void OnHoverExit()
    {
        _sphereMaterial.DOColor(sphereNormalColor, time);
        if (_isOn) _xMaterial.DOColor(xNormalColor, time);
        else _qMaterial.DOColor(qNormalColor, time);
    }

    public void OnSelectEnter()
    {
        _isOn = !_isOn;
        onToggle?.Invoke(_isOn);
        _sphereMaterial.DOColor(spherePressedColor, time);
        
        _qMaterial.DOColor(qPressedColor, time);
        _xMaterial.DOColor(xPressedColor, time);
        
        if (_isOn)
        {
            onToggleTrue?.Invoke();
            StartCoroutine(PlayOpenX());
            StartCoroutine(PlayCloseQ());
            targetObject.DOScale(targetScale * 1.02f, time);
            outlineObject.SetActive(true);
        }
        else
        {
            onToggleFalse?.Invoke();
            StartCoroutine(PlayOpenQ());
            StartCoroutine(PlayCloseX());
            targetObject.DOScale(targetScale, time);
            outlineObject.SetActive(false);
        }
    }

    private IEnumerator PlayOpenX()
    {
        yield return _waitForHalfSeconds;
        x.SetActive(true);
        x.transform.DOKill();
        x.transform.localScale = new Vector3();
        x.transform.DOScale(new Vector3(1, 1, 1) * ratio, time).SetEase(xEase);
    }
    
    private IEnumerator PlayCloseX()
    {
        x.transform.DOKill();
        x.transform.DOScale(new Vector3(), time).SetEase(xEase);
        yield return _waitForSeconds;
        x.SetActive(false);
    }
    
    private IEnumerator PlayOpenQ()
    {
        yield return _waitForHalfSeconds;
        openQ?.Kill();
        q.transform.DOKill();
        q.SetActive(true);
        _isPlayingQ = true;
        openQ = DOVirtual.Float(qSpinSpeed * 15, qSpinSpeed, time, Rotate).SetEase(qEase);
        q.transform.DOScale(new Vector3(100, 100, 100) * ratio, time).SetEase(qEase);
        yield return _waitForSeconds;
        _isPlayingQ = false;
    }
    
    private IEnumerator PlayCloseQ()
    {
        closeQ?.Kill();
        q.transform.DOKill();
        _isPlayingQ = true;
        closeQ = DOVirtual.Float(qSpinSpeed, qSpinSpeed * 10, time, Rotate).SetEase(qEase);
        q.transform.DOScale(new Vector3(), time).SetEase(qEase);
        yield return _waitForSeconds;
        _isPlayingQ = false;
        q.SetActive(false);
    }
    
    private void Rotate(float speed)
    {
        q.transform.Rotate(new Vector3(0f, speed * Time.deltaTime, 0f), Space.World);
    }

    private void Update()
    {
        if (x.activeSelf)
        {
            var lookRotation = Quaternion.LookRotation(_eyeTransform.position - transform.position, Vector3.up);
            x.transform.DORotateQuaternion(lookRotation, 0f);
        }

        if (!_isPlayingQ)
        {
            q.transform.Rotate(new Vector3(0f, qSpinSpeed * Time.deltaTime, 0f), Space.World);
        }
    }

    public void OnSelectExit()
    {
        _sphereMaterial.DOColor(sphereHoverColor, time);
        if (_isOn) _xMaterial.DOColor(xHoverColor, time);
        else _qMaterial.DOColor(qHoverColor, time);
    }
}
