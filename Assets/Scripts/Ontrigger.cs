using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ontrigger : MonoBehaviour {

	//public int contador;
	public Coche1Behavior coche;

	public bool isLast = false;

	private void OnTriggerEnter (Collider collider) {
		if (collider.tag.Equals("Player")) {

            coche.contador++;
			this.gameObject.SetActive(isLast);
		}
	}
}
