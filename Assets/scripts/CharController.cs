using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
	public Transform cameraFollowPoint;
	public Vector2 defaultCameraOffset;
	public float maxLookDistance;
	public float jumpSpeed;
	//public float maxSlopeAngle = 45;
	public float maxWalkSpeed = 5;
	public float walkAccel = 80;
	public float minSlideSpeed = 1;
	public float fricPerSecScalar = 0.999f;
	public float maxAirSpeed = 5;
	public float airAccel = 20;
	public SmoothFollow2D visuals;
	public float platDropYThresh = -0.75f;
	public Platform plat;
	public float platDropTimeDisable = 0.2f;

	public Rigidbody2D rigid;
	private CharInput input;
	private bool jumpReleased = false;
	//private ContactPoint2D[] contacts = new ContactPoint2D[256];
	private int numContacts;
	private Rigidbody2D relativeRigid = null;

	//private RaycastHit2D rh;
	//private CircleCollider2D cc;

	[SerializeField]
	private bool grounded = false;
	[SerializeField]
	private Vector2 velocity;
	[SerializeField]
	private float speed;

	public bool disable = false;
	
	// animation stuff
	public Animator ani;
	private float minRunSpeed = 0.4f;

	void Start ()
	{
		rigid = GetComponent<Rigidbody2D>();
		input = GetComponent<CharInput>();
		cameraFollowPoint.localPosition = defaultCameraOffset;
		ani.SetBool("run", true);
	}

	void Update()
	{
		if (!disable)
		{
			Jump();
			Look();
			Walk();
			Drift();
			PlatDrop();
		}

		velocity = rigid.velocity;
		speed = rigid.velocity.magnitude;

		if (Mathf.Abs(velocity.x) > minRunSpeed)
		{
			ani.SetBool("run", true);
		}
		else
		{
			ani.SetBool("run", false);
		}
	}

	private void FixedUpdate()
	{
		if (!disable)
		{
			RelativeRigidUpdate();
		}
	}

	/*private void OnCollisionEnter2D(Collision2D collision)
	{
		CheckGrounded(collision);
		Debug.Log("OnCollisionEnter2D, grounded = " + grounded);
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		CheckGrounded(collision);
		Debug.Log("OnCollisionExit2D, grounded = " + grounded);
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		CheckGrounded(collision);
		//Debug.Log("OnCollisionStay2D, grounded = " + grounded);
	}

	private void CheckGrounded(Collision2D col)
	{
		numContacts = col.GetContacts(contacts);

		bool groundedThisCheck = false;

		for (int i = 0; i < numContacts; i++)
		{
			if (Vector2.Angle(contacts[i].normal, Vector2.up) < maxSlopeAngle)
			{
				groundedThisCheck = true;
			}
		}

		grounded = groundedThisCheck;
	}*/

	private void OnTriggerEnter2D(Collider2D collision)
	{
		grounded = true;
		relativeRigid = collision.attachedRigidbody;
		//plat = collision.GetComponent<Platform>();
		if (/*plat == null &&*/ collision.GetComponent<TogglePlat>() != null)
		{
			plat = collision.GetComponent<TogglePlat>().plat;
		}

		//Debug.Log("Character entering collision with " + collision.gameObject.name);
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		grounded = false;
		if (relativeRigid != null && relativeRigid == collision.attachedRigidbody)
		{
			rigid.velocity += relativeRigid.velocity; // keep momentum
			relativeRigid = null;
		}
		if (plat == collision.GetComponent<Platform>()) { plat = null; }
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		grounded = true;
	}

	/*
	private void AlternativeGrounded() // not used, don't bother
	{
		rh = Physics2D.CircleCast
		(
			new Vector2(transform.position.x + cc.offset.x, transform.position.y + cc.offset.y), //origin
			cc.radius, //radius
			Vector2.zero, //direction
			0, //distance
			~(1<<9) //layer mask
		);

		if (rh)
		{
			if (rh.collider.GetComponent<TogglePlat>() != null)
			{
				plat = rh.collider.GetComponent<TogglePlat>().plat;
				// not sure how to make this work for leaving collision though...
			}
		}
	}
	*/

	private void Jump()
	{
		if (input.jump)
		{
			if (grounded && jumpReleased)
			{
				rigid.velocity = new Vector2(rigid.velocity.x, jumpSpeed);
				jumpReleased = false;
			}
		}
		else
		{
			jumpReleased = true;
		}
	}

	public void IceJump(float jumpSpd)
	{
		if (!grounded)
		{
			rigid.velocity = new Vector2(rigid.velocity.x, jumpSpd);
		}
	}

	public void Stop()
	{
		rigid.velocity = Vector2.zero;
	}

	private void Look()
	{
		/*if (input.move.y < -0.5)
		{
			cameraFollowPoint.localPosition = new Vector3(0, -maxLookDistance, 0);
		}
		else
		{
			cameraFollowPoint.localPosition = defaultCameraOffset;
		}*/

		cameraFollowPoint.localPosition = new Vector3(input.aim.x * maxLookDistance, input.aim.y * maxLookDistance, 0);
	}

	private void Walk()
	{
		/*if (grounded)
		{
			rigid.velocity = rigid.velocity + new Vector2(input.move.x * walkAccel, 0) * Time.deltaTime;

			rigid.velocity -= new Vector2(rigid.velocity.x, 0) * fricPerSecScalar * Time.deltaTime;

			if (rigid.velocity.magnitude > maxWalkSpeed && rigid.velocity.x > 0)
			{
				rigid.velocity = new Vector2(maxWalkSpeed, rigid.velocity.y);
			}

			if (rigid.velocity.magnitude > maxWalkSpeed && rigid.velocity.x < 0)
			{
				rigid.velocity = new Vector2(-maxWalkSpeed, rigid.velocity.y);
			}
		}*/

		if (grounded)
		{
			if (rigid.velocity.magnitude > maxWalkSpeed)
			{
				if (rigid.velocity.x > 0 && input.move.x < 0)
				{
					rigid.velocity += new Vector2(input.move.x, 0) * walkAccel * Time.deltaTime;
				}

				if (rigid.velocity.x < 0 && input.move.x > 0)
				{
					rigid.velocity += new Vector2(input.move.x, 0) * walkAccel * Time.deltaTime;
				}
			}
			else
			{
				rigid.velocity += new Vector2(input.move.x, 0) * walkAccel * Time.deltaTime;
			}

			//rigid.velocity *= 1 - (fricPerSecScalar * Time.deltaTime); // this makes jump heights inconsistent, it seems
			rigid.velocity -= new Vector2(rigid.velocity.x, 0) * fricPerSecScalar * Time.deltaTime;
		}
	}

	private void Drift()
	{
		if (!grounded)
		{
			if (Mathf.Abs(rigid.velocity.x) > maxAirSpeed)
			{
				if (rigid.velocity.x > 0 && input.move.x < 0)
				{
					rigid.velocity += new Vector2(input.move.x, 0) * airAccel * Time.deltaTime;
				}

				if (rigid.velocity.x < 0 && input.move.x > 0)
				{
					rigid.velocity += new Vector2(input.move.x, 0) * airAccel * Time.deltaTime;
				}
			}
			else
			{
				rigid.velocity += new Vector2(input.move.x, 0) * airAccel * Time.deltaTime;
			}

		}
	}

	private void RelativeRigidUpdate()
	{
		if (relativeRigid != null)
		{
			//rigid.MovePosition(rigid.position + relativeRigid.velocity * Time.deltaTime);
			rigid.position += relativeRigid.velocity * Time.fixedDeltaTime;
			//rigid.velocity += relativeRigid.velocity * Time.deltaTime;

			//visuals.useApproximation = true;
			//visuals.targetLerpVal = 29f;
		}
		else
		{
			//visuals.useApproximation = false;
			//visuals.targetLerpVal = 1;
		}
	}

	private void PlatDrop()
	{
		if (plat != null)
		{
			if (input.move.y < platDropYThresh)
			{
				//Debug.Log("drop thresh hit");
				plat.Disable(platDropTimeDisable);
				//rigid.position = new Vector2(rigid.position.x, rigid.position.y - plat.leniency);
			}
		}
	}
}
