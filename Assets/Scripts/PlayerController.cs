using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public int collectables;

	private Rigidbody rb;
	public Text points;

	void Start()
	{
		Debug.Log("Start");
		rb = GetComponent<Rigidbody>();
		collectables = 0;
	}

	void Update()
	{

		if(transform.position.y < 0)
		{
			transform.position = new Vector3(0f,0.5f,0f);
		}

	}

	void FixedUpdate()
	{

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rb.AddForce(movement * speed);

	}

	void OnTriggerEnter(Collider other) {
        
		if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
			collectables++;
			points.text = collectables.ToString();
        }

    }

}
