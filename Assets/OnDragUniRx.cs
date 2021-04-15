using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class OnDragUniRx : MonoBehaviour
{
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        var downStream = Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0));

        var upStream = Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonUp(0));

        Observable.EveryUpdate()
            .SkipUntil(downStream)
            .Select(_ => new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")))
            .TakeUntil(upStream)
            .Repeat()
            .Subscribe(move =>
            {
                transform.rotation =
                Quaternion.AngleAxis(move.y * speed * Time.deltaTime, Vector3.right) *
                Quaternion.AngleAxis(-move.x * speed * Time.deltaTime, Vector3.up) *
                transform.rotation;
            });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
