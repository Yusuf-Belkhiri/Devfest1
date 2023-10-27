using UnityEngine;

public class PlayerController : MonoBehaviour
{
	#region FIELDS

	// Horizontal Move
	[SerializeField] private float _xSpeed = 450f;
	[Range(0, .3f)] [SerializeField] private float _moveSmooth = .05f;	
	private bool _facingRight = true; 
	private Vector3 _velocity = Vector3.zero;

	// Vertical Move
	[SerializeField] private float _jumpForce = 700;							
	[SerializeField] private LayerMask _groundLayer;							
	[SerializeField] private Transform _groundCheck;							
	[SerializeField] private float _groundRadius = .2f; 
	private bool _grounded;           
	
	// Components
	private Rigidbody2D _rb;
	private Animator animator;

	#endregion


	#region METHODs

	private void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	/// <summary>
	/// Animation
	/// </summary>
	private void Update()
	{
		animator.SetBool("IsRunning", Mathf.Abs(_rb.velocity.x) > 0.5f);
		animator.SetBool("IsGrounded", _grounded);
		animator.SetFloat("YVelocity", _rb.velocity.y);
	}

	/// <summary>
	/// CHECK IF GROUNDED
	/// </summary>
	private void FixedUpdate()
	{
		_grounded = false;
		
		Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, _groundRadius, _groundLayer);
		foreach (var coll in colliders)
		{
			if (coll.gameObject == gameObject) continue;
			_grounded = true;
		}
	}
	
	
	public void Move(float move, bool jump)
	{
		// Horizontal Move
		Vector3 targetVelocity = new Vector2(move * _xSpeed * Time.fixedDeltaTime, _rb.velocity.y);
		_rb.velocity = Vector3.SmoothDamp(_rb.velocity, targetVelocity, ref _velocity, _moveSmooth);

		switch (move)
		{
			case > 0 when !_facingRight:
			case < 0 when _facingRight:
				FlipPlayer();
				break;
		}
		// JUMPING:
		if (_grounded && jump)
		{
			_grounded = false;
			_rb.AddForce(new Vector2(0f, _jumpForce));
		}
	}
	

	private void FlipPlayer()
	{
		_facingRight = !_facingRight;
		//_spriteRenderer.flipX = !_spriteRenderer.flipX;

		var scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
	
	#endregion
}
