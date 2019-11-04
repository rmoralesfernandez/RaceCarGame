using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartBehaviour : MonoBehaviour
{

    // Use this for initialization
    public Coche1Behavior coche;
    public GameObject _gameObject;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag.Equals("Player"))
        {

            coche.contador = 0;
            coche.vueltas++;
            _gameObject.SetActive(true);
        }
    }
}
