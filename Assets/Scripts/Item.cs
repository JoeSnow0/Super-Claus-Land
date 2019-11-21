using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items/New Item", menuName ="Item")]
    public class Item : ScriptableObject
    {
        public string mName;
        public Sprite mSprite;
        public Collider2D mCollider;
        public bool mMoves;
        public bool mJumps;
        public Animation mAnimation;
    }

