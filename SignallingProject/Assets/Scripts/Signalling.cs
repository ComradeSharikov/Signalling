using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signalling : MonoBehaviour
{
    [SerializeField] private Door _door;

    private AudioSource _audioSource;
    private Coroutine _setAudioVolumeJob;
    private float _maxVolume = 1f;
    private float _minVolume = 0.15f; 

    private void OnEnable()
    {
        _door.Reached += OnDoorReached;
    }

    private void OnDisable()
    {
        _door.Reached -= OnDoorReached;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnDoorReached()
    {
        if (_door.IsReached)
        {
            _setAudioVolumeJob = StartCoroutine(SetAudioVolume());
        }
        else
        {
            _audioSource.Stop();
            StopCoroutine(_setAudioVolumeJob);
        }
    }

    private IEnumerator SetAudioVolume()
    {
        _audioSource.volume = _maxVolume;
        bool isFading = true;

        while (true)
        {
            if (isFading)
            {
                _audioSource.volume -= Time.deltaTime / 2f;
                if (_audioSource.volume <= _minVolume)
                {
                    isFading = false;
                }
            }
            else
            {
                _audioSource.volume += Time.deltaTime / 2f;
                if (_audioSource.volume >= _maxVolume)
                {
                    isFading = true;
                }
            }

            yield return null;
        }
    }
}