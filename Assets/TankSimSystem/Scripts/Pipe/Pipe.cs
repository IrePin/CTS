﻿using UnityEngine;

namespace TankSimSystem
{
    public class Pipe : MonoBehaviour
    {
        [field: SerializeField] public float WaterFlowRate { get; private set; }
        public float Level { get; private set; }

        public void SetLevel(float level)
        {
            Level = level;
        }
    }
}