using Assets.Scripts.CharacterBuilder.Builder;
using UnityEngine;

namespace Assets.Scripts.CharacterBuilder
{
    public class Enemy1Controller: Character
    {

        public override void FixedUpdate()
        {
            if(player != null)
            {
                Vector3 lookDirection = (player.transform.position - transform.position).normalized;
                enemyRb.AddForce(lookDirection * Speed);

                if (transform.position.y < -10)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
