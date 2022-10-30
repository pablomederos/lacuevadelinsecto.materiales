using Assets.Scripts.CharacterBuilder.Builder;
using UnityEngine;

namespace Assets.Scripts.CharacterBuilder.Enemy
{
    public class Enemy1Builder : IBuilder
    {
        private readonly Enemy1Controller _enemy;
        private readonly GameObject _enemyprefab;
        private Vector3 position;
        private float velocity = 0f;

        public Enemy1Builder()
        {
            this._enemyprefab = Resources.Load("Prefabs/Enemy1") as GameObject;
            this._enemy = _enemyprefab.GetComponent<Enemy1Controller>();
        }

        public IBuilder SetVelocity(float velocity)
        {
            this.velocity = velocity;
            return this;
        }

        public IBuilder SetPosition(Vector3 position)
        {
            this.position = position;
            return this;
        }

        public Character Build()
        {
            Enemy1Controller enemy = Object.Instantiate(_enemy, position, _enemyprefab.transform.rotation);
            enemy.Speed = velocity;

            return enemy;
        }
    }
}
