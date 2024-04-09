using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.ObjectPool
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private float lifespan;

        private PooledObject pooledObject;
        private Rigidbody2D rb;

        // Start is called before the first frame update
        void Awake()
        {
            pooledObject = GetComponent<PooledObject>();
            rb = GetComponent<Rigidbody2D>();
        }

        public void Deactivate()
        {
            StartCoroutine(DeactivateBullet(lifespan));
        }

        private IEnumerator DeactivateBullet(float delay)
        {
            yield return new WaitForSeconds(delay);

            rb.velocity = Vector3.zero;

            pooledObject.Release();
            gameObject.SetActive(false);
        }
    }
}