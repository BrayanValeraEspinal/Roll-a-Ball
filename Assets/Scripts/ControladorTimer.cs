using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorTimer : MonoBehaviour
{
	public float tiempoRestante = 120f;
	public Text textoTimer;
	public GameObject mensajePerdiste;

	private bool juegoTerminado = false;

	void Start()
	{
		mensajePerdiste.SetActive(false);
	}

	void Update()
	{
		if (!juegoTerminado)
		{
			tiempoRestante -= Time.deltaTime;
			int tiempoEnEntero = Mathf.CeilToInt(tiempoRestante);
			textoTimer.text = "Tiempo: " + tiempoEnEntero.ToString();

			if (tiempoRestante <= 0)
			{
				juegoTerminado = true;
				textoTimer.text = "Tiempo: 0";
				mensajePerdiste.SetActive(true);
				Invoke("VolverAlMenu", 5f);
			}
		}
	}

	void VolverAlMenu()
	{
		SceneManager.LoadScene("MenuPrincipal");
	}
}
