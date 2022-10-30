using Assets.Scripts.CharacterBuilder.Builder;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.CharacterBuilder
{

    [RequireComponent(typeof(Rigidbody))]
    public class Player1Controller : Character
    {
        public bool hasPowerup = false;
        public float powerUpStrength = 15f;

        private Rigidbody rb;
        private GameObject focalPoint; // Este gameobject rota y cambia su dirección (forward)
        GameObject powerupIndicator;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            focalPoint = GameObject.Find("Focal Point");
            powerupIndicator = GameObject.Find("PowerupIndicator");
            powerupIndicator.SetActive(false);
        }

        // Update is called once per frame
        public override void FixedUpdate()
        {
            float forwardInput = Input.GetAxis("Vertical");
            // uso el forward del game object para modificar la dirección de la fuerza aplicada.
            rb.AddForce(forwardInput * Speed * focalPoint.transform.forward);
            powerupIndicator.transform.position = rb.transform.position + new Vector3(0, -0.5f, 0);
        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag("powerup"))
            {
                hasPowerup = true;
                powerupIndicator.SetActive(true);
                Destroy(other.gameObject);
                StartCoroutine(PowerupCountdownRoutine());
            }
        }

        private IEnumerator PowerupCountdownRoutine()
        {
            yield return new WaitForSeconds(7);
            powerupIndicator.SetActive(false);
            hasPowerup = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("enemy") && hasPowerup)
            {
                Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

                // calculo la distancia entre el enemigo y el jugador
                Vector3 awayFromEnemy = collision.transform.position - transform.position;

                enemyRigidbody.AddForce(awayFromEnemy * powerUpStrength, ForceMode.Impulse);
            }
        }
    }
}