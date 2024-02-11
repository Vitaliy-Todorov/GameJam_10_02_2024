using System;
using System.Collections;
using UnityEngine;

public class HearingAid : MonoBehaviour
{
    [SerializeField]
    private AudioManager _audioManager;
    [SerializeField] 
    private float _minValue;

    private float _value;

    private void Awake()
    {
        StartCoroutine(Operation());
        _audioManager.SetValue(_minValue);
        _audioManager.SetBlend(_minValue);
    }

    private IEnumerator Operation()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.Space) && _value < 1)
            {
                _value += 0.005f;
                _audioManager.SetValue(_value);
                _audioManager.SetBlend(_value);
            }
            else if(_value > _minValue)
            {
                _value -= 0.005f;
                _audioManager.SetValue(_value);
                _audioManager.SetBlend(_value);
            }
            
            yield return new WaitForSeconds(.1f);
        }
    }
}