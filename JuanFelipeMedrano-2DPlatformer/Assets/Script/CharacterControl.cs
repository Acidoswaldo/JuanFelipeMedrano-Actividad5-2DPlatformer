using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour {

	private Rigidbody2D rb;
	public float jumpForce;
	public bool isGrounded = true;
	float speed = 0.1f;
	int coins = 0;
	int hearts= 3;
	int stars = 0;

	public Text contadorCoins;
	public Text contadorHearts;
	public Text contadorStars;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKey (KeyCode.LeftArrow)) {


			this.transform.Translate (-speed, 0.0f, 0.0f);

			transform.localScale = new Vector2(-1.5f, transform.localScale.y);            

		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			this.transform.Translate (speed, 0.0f, 0.0f);
			transform.localScale = new Vector2(1.5f, transform.localScale.y);
	}
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded == true) {
			rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}
	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.collider.gameObject.tag == "Ground") {
			isGrounded = true;
		}
		if (collision.collider.gameObject.tag == "Coin") {
			//Aumentar la cantidad de monedas.
			coins = coins + 1;
			//Actualizar contador
			contadorCoins.text = coins.ToString();
			// destruimos la moneda

			Destroy (collision.collider.gameObject);

}
		if (collision.collider.gameObject.tag == "Hearts") {
			//Aumentar la cantidad de monedas.
			hearts = hearts + 1;
			//Actualizar contador
			contadorHearts.text = hearts.ToString();
			// destruimos la moneda

			Destroy (collision.collider.gameObject);




		}

		if (collision.collider.gameObject.tag == "Stars") {
			//Aumentar la cantidad de monedas.
			stars = stars + 1;
			//Actualizar contador
			contadorStars.text = stars.ToString();
			// destruimos la moneda

			Destroy (collision.collider.gameObject);




		}
		if (collision.collider.gameObject.tag == "Enemy") {
			//Aumentar la cantidad de monedas.
			hearts = hearts - 1;
			//Actualizar contador
			contadorHearts.text = hearts.ToString();
			// destruimos la moneda

			Destroy (collision.collider.gameObject);
			}


	}
	void OnCollisionExit2D (Collision2D collision) {
		if (collision.collider.gameObject.tag == "Ground") {
			isGrounded = false;
		}
	}

	public void clickEnEBoton() {
		print ("boton presionado");
		if (isGrounded == true) {
			rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}


	//Cuando el collider2D que es contenido por el game object colisiona con otro collider



}
