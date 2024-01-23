using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName ="newPlayerData", menuName ="Data/Player Data/Base")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 15f;
    public float sprintSpeed = 25f;

    [Header("Jump State")]
    public float jumpVelocity = 15f;

    [Header("Dash State")]
    public float dashCooldown = 0.5f;
    public float maxHoldTime = 1f;
    public float holdTimeScale = 0.25f;
    public float dashTime = 0.2f;
    public float dashVelocity = 30f;
    public float drag = 10f;
    public float dashEndYMultiplier = 0.2f;
    public float distBetweenAfterImages = 0.5f;

    [Header("Crouch States")]
    public float crouchMovementVelocity = 5f;
    public float crouchColliderHeight = 0.8f;
    public float standColliderHeight = 1.6f;

    [Header("PlayerColliderIdle")]
    public float idleOffsetX = -0.1f;
    public float idleOffsetY = -1.15f;
    public float idleSizeX = 3;
    public float idleSizeY = 6.7f;

    [Header("PlayerColliderMove")]
    public float moveOffsetX = -0.5f;
    public float moveOffsetY = 0f;
    public float moveSizeX = 6.7f;
    public float moveSizeY = 1.8f;
}
