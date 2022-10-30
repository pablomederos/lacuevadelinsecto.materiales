using Assets.Scripts.CharacterBuilder.Builder;
using UnityEngine;

namespace Assets.Scripts.CharacterBuilder.Player
{
    internal class Player1Builder : IBuilder
    {
        private readonly Player1Controller _player;
        private readonly GameObject _playerprefab;
        private Vector3 position;
        private float velocity;

        public Player1Builder()
        {
            this._playerprefab = Resources.Load("Prefabs/Player") as GameObject;
            this._player = _playerprefab.GetComponent<Player1Controller>();
        }

        public IBuilder SetPosition(Vector3 position)
        {
            this.position = position;
            return this;
        }

        public IBuilder SetVelocity(float velocity)
        {
            this.velocity = velocity;
            return this;
        }

        public Character Build()
        {
            Player1Controller player = Object.Instantiate(_player, position, _playerprefab.transform.rotation);
            player.Speed = velocity;

            return player;
        }
    }
}
