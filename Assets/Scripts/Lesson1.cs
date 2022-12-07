using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Lesson1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Observable.EveryUpdate()
        //     .Where(_ => Input.GetMouseButtonDown(0))
        //     .Subscribe((x) => { Debug.Log("onnext:点击了鼠标左键"); }, () => { Debug.Log("onComplete"); });


        var clickStream = Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0));
        clickStream.Buffer(clickStream.Throttle(TimeSpan.FromMilliseconds(250)))
            .Where(xs => xs.Count >= 2)
            .Subscribe(xs => Debug.Log("双击事件"));
    }

    // Update is called once per frame
    void Update()
    {
    }
}