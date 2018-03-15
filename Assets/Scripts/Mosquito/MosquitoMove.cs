using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoMove: MonoBehaviour {
	public Sprite deadSprite;
	public float timeToChangeDirection = 1;
	public float speed = 1;
	public float verticalSpeed = 2;

	public float sinSpeed = 2;
	private float timer = 0;
	public float maxPositionOffset = 1;
	private float maxHorizontal, maxVertical;
	Vector2 direction = Vector2.zero;
	SpriteRenderer rend;
	bool dead = false;
    public void init(GameManager gm)
    {
		maxVertical = Camera.main.orthographicSize;    
		maxVertical -= maxPositionOffset;

		maxHorizontal = maxVertical * Screen.width / Screen.height;


		float posX = Random.Range (-maxHorizontal, maxHorizontal);
		float posY = Random.Range (-maxVertical, maxVertical);
		transform.position = new Vector3 (posX, posY, 0);
		//Debug.Log (maxHorizontal + " " + maxVertical);

		timer = Time.time + timeToChangeDirection;
    }

    // Use this for initialization
    void Start () {
		rend = GetComponent<SpriteRenderer> ();
    }
	
	// Update is called once per frame
	void Update () {
		if (dead) {
			return;
		}

		if (timer < Time.time) {
		
			timer = Time.time + timeToChangeDirection;

			direction = Random.insideUnitCircle;
			direction = direction.normalized;
		}
		float sinY = Mathf.Sin (Time.time*sinSpeed) * verticalSpeed;

		Vector3 newPosition = transform.position + (Vector3)((direction * speed + Vector2.up * sinY) * Time.deltaTime);

		if (newPosition.x > maxHorizontal || newPosition.x < -maxHorizontal) {
			direction.x *= -1;
		}

		if (newPosition.y > maxVertical || newPosition.y < -maxVertical) {
			direction.y *= -1;
		}

		if (direction.x > 0) {
			rend.flipX = false;
		} else {
			rend.flipX = true;
		}


		transform.Translate ((direction * speed + Vector2.up * sinY)* Time.deltaTime);

    }
	public void Kill(){
		dead = true;
		rend.sprite = deadSprite;
	}

}
