using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.CharacterBuilder.Builder
{
    public abstract class Character: MonoBehaviour
    {
        public float Speed { protected get; set; } = 0f;
        protected Rigidbody enemyRb;
        protected GameObject player;

        private void Start()
        {
            enemyRb = GetComponent<Rigidbody>();
            player = GameObject.FindGameObjectWithTag("Player");
        }

        public abstract void FixedUpdate();
    }
}
