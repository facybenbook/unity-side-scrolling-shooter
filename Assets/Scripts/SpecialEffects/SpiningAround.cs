﻿using UnityEngine;

public class SpiningAround : MonoBehaviour
{
    [SerializeField] float rotSpeed = 0.1f;

    void Update()
    {

        transform.Rotate(0, 0, rotSpeed);
    }
}
