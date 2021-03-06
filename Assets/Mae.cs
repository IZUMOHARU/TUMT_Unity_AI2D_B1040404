﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mae : MonoBehaviour
{
    [Header("速度"), Range(0, 10)]
    public float speed = 3;
    private Transform target;

    private void Start()
    {
        target = GameObject.Find("HITO").transform;
    }
    private void LateUpdate()
    {
        Vector3 cam = transform.position;
        Vector3 tar = target.position;
        tar.z = -10;
        tar.y = Mathf.Clamp(tar.y, -0.6f, 0.6f);
        tar.x = Mathf.Clamp(tar.x, -6.8f, 91f);
        transform.position = Vector3.Lerp(cam, tar, 0.3f * Time.deltaTime * speed);

    }
}