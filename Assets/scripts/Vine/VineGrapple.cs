using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineGrapple : MonoBehaviour
{
	public float speed;
	public float pullSpeed;
	public float minGrappleLength;
	private Vector2 speedVec;
	public CharState cs;

	private Vector2 targetPoint;
	private ContactPoint2D[] asdf;

	private Rigidbody2D rigid;

	void Start()
	{
		speedVec = speed * new Vector2(Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad), Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad));
		rigid = GetComponent<Rigidbody2D>();
		rigid.velocity = speedVec;
		asdf = new ContactPoint2D[1];
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		col.GetContacts(asdf);
		targetPoint = asdf[0].point;
		Destroy(rigid);
		Destroy(GetComponent<CircleCollider2D>());

		cs.ctrl.disable = true;
	}

	void FixedUpdate()
	{
		if (targetPoint != null && cs.ctrl.disable)
		{
			cs.ctrl.rigid.velocity = (targetPoint - cs.ctrl.rigid.position).normalized * pullSpeed;
			if (Vector2.Distance(targetPoint, cs.ctrl.rigid.position) < minGrappleLength)
			{
				Delete();
			}
		}
	}

	private void Delete()
	{
		cs.ctrl.disable = false;
		GetComponent<VineSections>().Delete();
		Destroy(this.gameObject);
	}
}
