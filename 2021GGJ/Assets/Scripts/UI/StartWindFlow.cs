using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartWindFlow : MonoBehaviour
{
    public RectTransform ttr;
    public RectTransform mtr;

    public Vector3 startPos;
    public Vector3 targetPos;

    public float moveRate = 5.0f;
    public float currentPos = 0;
    public bool movetag = true;

    private void Start()
    {
        mtr = GetComponent<RectTransform>();
        startPos = mtr.localPosition;
        targetPos = ttr.localPosition;
    }

    private void Update()
    {
        if (movetag)
        {
            currentPos += Time.deltaTime * moveRate;
            if (currentPos >= 1)
                movetag = !movetag;
        }
        else
        {
            currentPos -= Time.deltaTime * moveRate;
            if (currentPos <= 0)
                movetag = !movetag;
        }

        mtr.localPosition = (targetPos - startPos) * currentPos + startPos;
    }


}
