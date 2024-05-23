using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _inputMovement;
    [SerializeField] private float _moveSpeed = 5.0f;

    private Animator _anim;

    //private PickUpItem _pickUp;
    //private Vector2 _lastDirection = Vector2.zero;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        //_pickUp = gameObject.GetComponent<PickUpItem>();
    }

    void Update()
    {
        if (name == "Player1")
        {
            _inputMovement.x = Input.GetAxisRaw("Horizontal");
            _inputMovement.y = Input.GetAxisRaw("Vertical");

            if (_inputMovement.sqrMagnitude > .1f)
            {
                //_pickUp.direction = _inputMovement.normalized;
            }
        }

        if (name == "Player2" && Input.anyKey)
        {
            if (Input.GetKey(KeyCode.I))
            {
                _inputMovement.y = _moveSpeed;
            }
            if (Input.GetKey(KeyCode.K))
            {
                _inputMovement.y = -_moveSpeed;
            }
            if (Input.GetKey(KeyCode.J))
            {
                _inputMovement.x = -_moveSpeed;
            }
            if (Input.GetKey(KeyCode.L))
            {
                _inputMovement.x = _moveSpeed;
            }
            //Debug.Log("Player2 Input: " + _inputMovement);
            if (_inputMovement.sqrMagnitude > .1f)
            {
                //_pickUp.direction = _inputMovement.normalized;
            }
        }
        else if (name == "Player2" && !Input.anyKey)
        {
            _inputMovement.x = 0f;
            _inputMovement.y = 0f;
        }

        _inputMovement.Normalize();

        Vector3 direction = new Vector3(_inputMovement.x * _moveSpeed, _inputMovement.y * _moveSpeed, 0);

        if (_inputMovement != Vector2.zero)
        {
            _anim.SetFloat("moveX", _inputMovement.x);
            _anim.SetFloat("moveY", _inputMovement.y);
            _anim.SetBool("moving", true);
        }
        else
        {
            _anim.SetBool("moving", false);
        }

        _rb.velocity = direction;
    }
}