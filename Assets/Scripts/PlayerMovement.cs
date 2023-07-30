using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    [SerializeField]
    private float _forwardSpeed;
    
    [SerializeField]
    private float _horizontalSpeed;

   [SerializeField]
   private Rigidbody _rigidbody;
    Vector3 _velocity = new Vector3();
    [SerializeField]
    private float _jumpPower;
    [SerializeField]
    private float _maxHoritontalDistance;
    private bool _isGrounded;
    [SerializeField]
    
    

    private void Update() 
    {
       if (!GameInstance.Instance.IsGameStarted)
		{
			_velocity = Vector3.zero;
			return;
		}
      
       
       

        _velocity.z = _forwardSpeed;
        _velocity.y = _rigidbody.velocity.y;
        _velocity.x = Input.GetAxis("Horizontal") *_horizontalSpeed ;
     
     if(Input.GetKeyDown(KeyCode.Space) && _isGrounded )
     {
          Debug.Log("_isGrounded: " + _isGrounded);
          Debug.Log("_velocit.y: " + _velocity.y);
          Debug.Log("_jumpPower: " +_jumpPower);
      //_velocity.y = _jumpPower;
       _rigidbody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
        _isGrounded = false;
        
     }

    }

    private void FixedUpdate() 
    {   
        if(Mathf.Abs(_rigidbody.position.x ) > _maxHoritontalDistance)
        {
            var clampedPosition = _rigidbody.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, -_maxHoritontalDistance, _maxHoritontalDistance);
            _rigidbody.position = clampedPosition;
            
        }

        _rigidbody.velocity = _velocity;

        Debug.DrawRay(transform.position, Vector3.down * 1.05f);
      _isGrounded = (Physics.Raycast(transform.position, Vector3.down, 1.05f)); // if statementının içinde _isGrounded = true demekle aynı
        
        
    }
   
}
