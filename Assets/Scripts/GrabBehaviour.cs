﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBehaviour : MonoBehaviour
{
    private bool _canGrab = false;
    private bool _isGrabbing;
    public Transform grabPosition;
    private GameObject _lastPersonTouched;
    private SpriteRenderer _spriteRenderer;

    public Color canGrabColor;
    public Color normalColor;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _spriteRenderer.color = (_canGrab) ? canGrabColor : normalColor;
        if (_canGrab && Input.GetKey(KeyCode.Space))
        {
            _lastPersonTouched.transform.position = grabPosition.position;
        }
        _isGrabbing = Input.GetKey(KeyCode.Space);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Person"))
        {
            _canGrab = true;
            if (!_isGrabbing)
            {
                _lastPersonTouched = other.gameObject;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Person") && !_isGrabbing)
        {
            _canGrab = false;
        }
    }
}