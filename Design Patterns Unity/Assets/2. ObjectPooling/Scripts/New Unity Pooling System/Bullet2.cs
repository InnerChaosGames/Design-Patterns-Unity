using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace DesignPatterns.ObjectPool
{
    public class Bullet2 : MonoBehaviour
    {
        [SerializeField]
        private float lifespan;

        private Rigidbody2D rb;
        private IObjectPool<Bullet2> objectPool;

        public IObjectPool<Bullet2> ObjectPool { set => objectPool = value; }

        private void Awake()
        {
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

            objectPool.Release(this);
        }
    }
}