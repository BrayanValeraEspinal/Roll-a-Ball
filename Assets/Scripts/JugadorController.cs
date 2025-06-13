using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JugadorController : MonoBehaviour
{
	private Rigidbody rb;
	private int contador;
	public float velocidad;
	public Text textoContador, textoGanar;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		contador = 0;
		setTextoContador();
		textoGanar.text = "";
	}

	void FixedUpdate()
	{
		float movimientoH = Input.GetAxis("Horizontal");
		float movimientoV = Input.GetAxis("Vertical");
		Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);
		rb.AddForce(movimiento * velocidad);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Coleccionable"))
		{
			other.gameObject.SetActive(false);
			contador++;
			setTextoContador();

			// Notificar al controlador de niveles
			ControladorNiveles nivelCtrl = FindObjectOfType<ControladorNiveles>();
			if (nivelCtrl != null)
			{
				nivelCtrl.RecogerColeccionable();
			}
		}
		else if (other.gameObject.CompareTag("Obstaculo"))
		{
			// Notificar si pierde
			ControladorNiveles nivelCtrl = FindObjectOfType<ControladorNiveles>();
			if (nivelCtrl != null)
			{
				nivelCtrl.PerderNivel();
			}
		}
	}

	void setTextoContador()
	{
		textoContador.text = "Contador: " + contador.ToString();

		if (contador >= 12)
		{
			textoGanar.text = "¡Ganaste!";
			Invoke("CargarSiguienteNivel", 3f); // Cambia de VolverAlMenu a esta función
		}
	}

	void CargarSiguienteNivel()
	{
		int nivelActual = SceneManager.GetActiveScene().buildIndex;
		int totalNiveles = SceneManager.sceneCountInBuildSettings;

		if (nivelActual + 1 < totalNiveles)
		{
			// Cargar el siguiente nivel
			SceneManager.LoadScene(nivelActual + 1);
		}
		else
		{
			// Si no hay más niveles, volver al menú
			SceneManager.LoadScene("MenuPrincipal");
		}
	}

}
