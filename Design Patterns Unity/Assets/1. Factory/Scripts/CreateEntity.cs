using DesignPatterns.Factory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEntity : MonoBehaviour
{
    [SerializeField]
    private Vector2 offsetRange;
    [SerializeField]
    private Factory[] factories;

    private Factory factory;
    private float offset;

    // Update is called once per frame
    void Update()
    {
        SpawnEntity();
    }

    private void SpawnEntity()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            factory = factories[Random.Range(0, factories.Length)];
            offset = Random.Range(offsetRange.x, offsetRange.y);

            factory.GetEntity(new Vector2(transform.position.x + offset, transform.position.y));
        }
    }
}
