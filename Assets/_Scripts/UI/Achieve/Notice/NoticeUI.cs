using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeUI : Singleton<NoticeUI>
{
    WaitForSecondsRealtime _threeSeconds = new WaitForSecondsRealtime(3);
    [SerializeField] DonepieceNotice _donepieceNotice = new DonepieceNotice();
    Image _noticePanel;

    void Awake()
    {
        _noticePanel = GetComponent<Image>();
        _noticePanel.color = Color.clear;
        _donepieceNotice.HideNotice();
    }
    Coroutine _noticeCoHandle;
    IEnumerator GetPieceCo()
    {
        _noticePanel.color = Color.white;
        _donepieceNotice.GetPiece();
        yield return _threeSeconds;
        _donepieceNotice.HideNotice();
        _noticePanel.color = Color.clear;
    }

    public void GetPiece()
    {
        _noticeCoHandle = StartCoroutine(GetPieceCo());
    }

    public void NoticeStopCoHandle()
    {
        if (_noticeCoHandle != null)
        {
            StopCoroutine(_noticeCoHandle);
        }
    }
}
