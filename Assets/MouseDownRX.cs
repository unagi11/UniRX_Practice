using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UniRx;
using System;
using UnityEngine;

public class MouseDownRX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this
            .OnMouseDownAsObservable()
            .Subscribe(a => Debug.LogError("cube down" + a));
    }

}
