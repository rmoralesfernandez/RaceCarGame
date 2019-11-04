using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBehavoir : MonoBehaviour {

public Coche1Behavior _coche;
public float _speed = 10;
private Vector3 _direction;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(0f, _coche._speed * _speed, 0f);

		float previousY = _direction.y;
		_direction = this.transform.forward  * _speed;
		_direction.y = previousY;
		
	}
}
