using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    [SerializeField] private float fallPanAmount = 0.25f;
    [SerializeField] private float fallPanTime = 0.35f;

    public float _fallSpeedYDampingChangeThreshold = -15f;

    public bool IsLerpingYDamping { get; private set; }
    public bool LerpedFromPlayerFalling { get; set; }

    private Coroutine _lerpYPanCoroutine;

    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }
    }
}
