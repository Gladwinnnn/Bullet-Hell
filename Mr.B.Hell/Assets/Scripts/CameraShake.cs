using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    CinemachineVirtualCamera cinemachine;
    CinemachineBasicMultiChannelPerlin channelPerlin;
    float shakeTimer = 0;

    private void Awake()
    {
        cinemachine = GetComponent<CinemachineVirtualCamera>();
        channelPerlin = cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        channelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;

            if(shakeTimer <= 0)
            {
                channelPerlin.m_AmplitudeGain = 0;
            }
        }   
    }
}
