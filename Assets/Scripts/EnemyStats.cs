using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Entities/New Enemy")]
public class EnemyStats : ScriptableObject
{
    [Header("Sprite")]
    [Tooltip("Choose an appropriate sprite")]
    public Sprite mSprite;
    [Header("Animator")]
    [Tooltip("connect the approriate animation controller")]
    public RuntimeAnimatorController mAnimationController;
    [Header("Movement")]
    [Tooltip("Can it move?")]
    public bool mMoves;
    [Tooltip("How fast is this entity?")]
    [Range(0, 10)]
    public float mSpeed;
    [Header("Jumping")]
    [Tooltip("Can it jump?")]
    public bool mJumps;
    [Tooltip("How high can it jump?")]
    [Range(0, 10)]
    public float mJumpPower;
    [Tooltip("Time between jumps in seconds")]
    [Range(0, 20)]
    public float mJumpInterval;
}
