using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coche1Behavior : MonoBehaviour
{


    public float _speed = 10;
    public float _aceleracion = 1f;
    public float _deceleracion = -1f;
    public float _rotatespeed = 80;
    public float _motorForce = 15f;
    public float _maxSpeed = 270f;
    public float _initialSpeed = 20f;

    public Text _texto;
    public Text _texto2;

    public float tiempo;

    public GameObject game;



    public int contador;
    public int vueltas;
    public GameObject[] checkpoint;

   
    private Rigidbody _rigidbody;
    private Vector3 _inputDirection;
    private Vector3 _direction;
    [SerializeField]
    private bool _isGrounded = false;
    [SerializeField]
    private BoxCollider _Grounded = null;

    // Use this for initialization
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _speed = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        CheckGrounded();
        // if (Input.GetKey(KeyCode.W)) {
        // 	_speed = _speed + _aceleracion;
        // 	transform.Translate(Vector3.right * _speed * Time.deltaTime,Space.Self);
        // 	//rb.AddForce(Vector3.right * _motorForce * Time.deltaTime);			
        // }

        // if (Input.GetKey(KeyCode.S)) {
        // 	//transform.Translate(-Vector3.right * _speed * Time.deltaTime);
        // 	rb.AddForce(-Vector3.right * _motorForce);
        // }

        // if (Input.GetKey(KeyCode.A)) {
        // 	transform.Rotate(-Vector3.up * _rotatespeed * Time.deltaTime, Space.Self);
        // }

        // if (Input.GetKey(KeyCode.D)) {
        // 	transform.Rotate(Vector3.up * _rotatespeed * Time.deltaTime, Space.Self);
        // }


        if (Input.GetKeyDown(KeyCode.W) && _isGrounded && _speed <= _initialSpeed)
        {
            _speed = _initialSpeed;
        }

        if (Input.GetKey(KeyCode.W) && _isGrounded && _speed <= _maxSpeed)
        {
            _speed += _aceleracion * Time.deltaTime;
        }
        else
        {
            _speed += _deceleracion * Time.deltaTime;
            if (_speed < 0f)
            {
                _speed = 0f;
            }
        }

        if (Input.GetKey(KeyCode.S) && _isGrounded)
        {
            _speed += _deceleracion * Time.deltaTime;
        }

        this.transform.Rotate(0f, Input.GetAxis("Horizontal"), 0f);

        float previousY = _direction.y;
        _direction = this.transform.forward * _speed;
        _direction.y = previousY;
        if (!_isGrounded)
        {
            _rigidbody.useGravity = true;
            _direction.y += Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            _rigidbody.useGravity = false;
        }


        _rigidbody.velocity = _direction;

        TimeCounter();

        restart();
        
        _texto.text = vueltas.ToString();

        Finish();
    }

    private void CheckGrounded()
    {
        Vector3 center = _Grounded.transform.position + Vector3.Scale(_Grounded.center, _Grounded.transform.localScale);
        Vector3 halfExtends = Vector3.Scale(_Grounded.size * 0.5f, _Grounded.transform.localScale);
        Collider[] colliders = Physics.OverlapBox(center, halfExtends);

        _isGrounded = false;
        for (int i = 0; i < colliders.Length; i++)
        {
            if (!colliders[i].isTrigger && !colliders[i].tag.Equals("Player") && !colliders[i].tag.Equals("Wheel"))
            {
                _isGrounded = true;
            }
        }
    }

    private void restart()
    {
        if (contador == checkpoint.Length)
        {
            vueltas++;
            contador = 0;
            tiempo = 0;
            for (int i = 0; i < checkpoint.Length; i++)
            {
                checkpoint[i].SetActive(true);
            }
        }
    }

    private void TimeCounter() {
       
        tiempo += Time.deltaTime;
        _texto2.text = tiempo.ToString();
        
        }


    private void Finish()
    {
        if(vueltas >= 3) {
            _speed = 0f;
            game.SetActive(true);
            
        }
    }


}
