using Assets.Scripts.CharacterBuilder.Builder;
using UnityEngine;

namespace Assets.Scripts.CharacterBuilder.Enemy
{
    internal class Enemy2Builder : IBuilder
    {
        private readonly Enemy2Controller _enemy;
        private readonly GameObject _enemyprefab;
        private Vector3 position;
        private float velocity = 0f;

        public Enemy2Builder()
        {
            this._enemyprefab = Resources.Load("Prefabs/Enemy2") as GameObject;
            this._enemy = _enemyprefab.GetComponent<Enemy2Controller>();
        }

        public IBuilder SetVelocity(float value)
        {
            this.velocity = value;
            return this;
        }

        public IBuilder SetPosition(Vector3 position)
        {
            this.position = position;
            return this;
        }

        public Character Build()
        {
            Enemy2Controller enemy = Object.Instantiate(_enemy, position, _enemyprefab.transform.rotation);
            enemy.Speed = velocity;

            return enemy;
        }
    }
}
