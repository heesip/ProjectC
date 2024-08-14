using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeUI : Singleton<NoticeUI>
{
    CanvasGroup _canvasGroup;
    WaitForSecondsRealtime _threeSeconds = new WaitForSecondsRealtime(3);
    [SerializeField] DonepieceNotice _donepieceNotice = new DonepieceNotice();
    [SerializeField] MadnessNotice _madnessNotice = new MadnessNotice();
    [SerializeField] ClearEyesNotice _clearEyesNotice = new ClearEyesNotice();
    [SerializeField] Tier0Notice _tier0Notice = new Tier0Notice();
    
    void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        Hide();
    }
    
    public void DonePieceNotice()
    {
        _noticeCoHandle = StartCoroutine(NoticeCo(_donepieceNotice));
    }

    public void MadnessNotice()
    {
        _noticeCoHandle = StartCoroutine(NoticeCo(_madnessNotice));
    }

    public void ClearEyesNotice()
    {
        _noticeCoHandle = StartCoroutine(NoticeCo(_clearEyesNotice));
    }

    public void Tier0Notice()
    {
        _noticeCoHandle = StartCoroutine(NoticeCo(_tier0Notice));
    }

    public void NoticeStopCoHandle()
    {
        if (_noticeCoHandle != null)
        {
            StopCoroutine(_noticeCoHandle);
            Hide();
        }
    }

    Coroutine _noticeCoHandle;

    IEnumerator NoticeCo(NoticeSystem noticeSystem)
    {
        Show();
        noticeSystem.Show();
        yield return _threeSeconds;
        Hide();
    }

    void Hide()
    {
        transform.localScale = Vector3.zero;
        _canvasGroup.alpha = 0;
        _donepieceNotice.Hide();
        _madnessNotice.Hide();
        _clearEyesNotice.Hide();
        _tier0Notice.Hide();
    }

    void Show()
    {
        transform.localScale = Vector3.one;
        _canvasGroup.alpha = 1;
    }
}
