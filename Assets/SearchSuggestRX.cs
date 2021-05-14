using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using System;

public class SearchSuggestRX : MonoBehaviour
{
    private readonly string _apiUrlFormat
        = "http://www.google.com/complete/search?hl=ja&output-toolbar&q={0}";

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<InputField>()
        //    .OnValueChangedAsObservable()
        //    .Throttle(TimeSpan.FromMilliseconds(200))
        //    .Where(word => word.Length > 0)
        //    .SelectMany(word => ObservableWWW.Get(string.Format(_apiUrlFormat, WWW.EscapeURL(word))))
        //    .Select(xml => xml.Substring)



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
