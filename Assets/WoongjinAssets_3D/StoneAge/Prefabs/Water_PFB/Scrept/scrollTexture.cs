using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollTexture : MonoBehaviour
{
    #region field
    public System.Action ActionCreditScrollFinished = null;
    public float scrollX = 0.5F;
    public float scrollY = 0.5F;
    public bool scrollLoop = false;
    private float elapsed = 0f;
    bool _startScroll = false;
    private float _limitY = 0f;
    #endregion

    #region unity mono
    private void Start()
    {
        elapsed = 0;
    }
    void Update()
    {
        if (!_startScroll && !scrollLoop)
            return;

        elapsed += Time.deltaTime;
        float OffsetX = elapsed * scrollX;
        float OffsetY = elapsed * scrollY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);

        if (OffsetY < _limitY) {
            _startScroll = false;
            if (ActionCreditScrollFinished != null)
                ActionCreditScrollFinished();
        }
    }
    #endregion

    #region method
    public void StartScroll()
    {
        _startScroll = true;
    }
    public void StopScroll()
    {
        _startScroll = false;
    }
    public void SetScrollLimitY(float y)
    {
        _limitY = y;
    }
    #endregion
}