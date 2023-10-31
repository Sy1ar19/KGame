using System;

namespace Assets.Scripts.Data
{
    [Serializable]
    public class PositionOnLevel
    {
        public string level;
        public Vector3Data Position;

        public PositionOnLevel(string initialLevel)
        {
            level = initialLevel;
        }

        public PositionOnLevel(string level, Vector3Data position)
        {
            this.level = level;
            Position = position;
        }
    }
}