using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items/New Item", menuName ="Item")]
    public class Item : ScriptableObject
    {
        public Sprite mSprite;
        public Animation mAnimation;
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
    }

