using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsBehavoiur : MonoBehaviour 
{	

	private void Awake() {
		for (int i = 0; i < _registerFPS.Length; i++)
		{
			_registerFPS[i] = 60;

		}
	}

		private void Update () 
		{

		_count++;
		_timer += Time.deltaTime;

		if (_timer > 1f)
		 {
			_timer -= 1f;

			_registerFPS[_index] = _count;
			_index = ++_index % _registerFPS.Length;

			for (int i = 0; i < _registerFPS.Length; i++)
			{
				_averageFPS += _registerFPS[i];
			}

			_averageFPS /= _registerFPS.Length;

			_counterText.text = _count.ToString() + "/" + _averageFPS.ToString();

			_count = 0;
			
		}
	}
	[SerializeField]
	private Text _counterText;
	private int _count;
	private float _timer;
	private int[] _registerFPS = new int[60];

	private float _averageFPS;

	private int _index;
}
