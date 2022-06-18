using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum TYPEOFJOKE { BIZARRO, NEGRO, SUCIO, INFANTIL, RELIGIOSO }

public class Obstacle : MonoBehaviour
{
    public static event Action<TYPEOFJOKE> OnExecuteJoke;

    [SerializeField] private TYPEOFJOKE _typeOfJoke;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            OnExecuteJoke?.Invoke(_typeOfJoke);
        Destroy(gameObject);
    }
}
