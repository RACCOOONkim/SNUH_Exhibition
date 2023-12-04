using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class GuideUIMovement : MonoBehaviour
{
    public Transform pivot;
    public float y = 1f;
    private Tweener _tweener;
    public TextMeshProUGUI text;
    private Coroutine _coroutine;
    private void Start()
    {
        _tweener = transform.DOMove(pivot.position, 0f).SetAutoKill(false);
    }

    void Update()
    {
        var pos = pivot.position;
        pos = new Vector3(pos.x, y, pos.z);
        _tweener.ChangeEndValue(pos, 1f).Restart();
    }

    private void OnEnable()
    {
        _coroutine = StartCoroutine(UpdateText());
    }

    private void OnDisable()
    {
        if (_coroutine != null) StopCoroutine(_coroutine);
    }

    private IEnumerator UpdateText()
    {
        var waitForSeconds = new WaitForSeconds(0.5f);
        for (var i = 0; i < 100; i++)
        {
            text.text = "안내 중 입니다.";
            yield return waitForSeconds;
            text.text = "안내 중 입니다..";
            yield return waitForSeconds;
            text.text = "안내 중 입니다...";
            yield return waitForSeconds;
        }
    }
}
