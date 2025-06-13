using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // <- Cambiamos a usar UI.Text

public class MostrarNivel : MonoBehaviour
{
	public Text textoNivel; // <- Cambiamos el tipo

	void Start()
	{
		int nivel = SceneManager.GetActiveScene().buildIndex;
		textoNivel.text = "Nivel: " + nivel;
	}
}
