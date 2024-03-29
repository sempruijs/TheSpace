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
    private Vector3 _startGrabPosition;


    private void Start()
    {
        _startGrabPosition = grabPosition.localPosition;
    }

    private void Update()
    {
        if (_canGrab && Input.GetKey(KeyCode.Space) && GameManager.Instance.state == GameManager.State.InGame)
        {
            if (_lastPersonTouched != null)
            {
                _lastPersonTouched.transform.position = grabPosition.position;
            }
        }

        _isGrabbing = _canGrab && Input.GetKey(KeyCode.Space);
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