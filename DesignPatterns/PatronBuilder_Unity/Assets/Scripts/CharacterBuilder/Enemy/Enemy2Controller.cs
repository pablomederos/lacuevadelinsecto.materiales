using Assets.Scripts.CharacterBuilder.Builder;
using UnityEngine;

namespace Assets.Scripts.CharacterBuilder
{
    public class Enemy2Controller: Character
    {

        public override void FixedUpdate()
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * (Speed * 1.2f));

            if (transform.position.y < -10)
            {
                Destroy(gameObject);
            }
        }
    }
}
