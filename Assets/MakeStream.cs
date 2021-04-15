using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class MakeStream : MonoBehaviour
{
    public int a = 10;

    public ReactiveProperty<int> b = new ReactiveProperty<int>();

    // Start is called before the first frame update
    void Start()
    {
        b.Value = 10;

        this.ObserveEveryValueChanged(_ => a)
            .Subscribe(a => Debug.LogError(a));

        b.Subscribe(b => Debug.LogError(b));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
