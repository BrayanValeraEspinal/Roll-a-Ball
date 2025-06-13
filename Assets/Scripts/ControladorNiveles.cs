using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorNiveles : MonoBehaviour
{
	public int totalColeccionables = 12;
	private int recogidos = 0;

	public void RecogerColeccionable()
	{
		recogidos++;
		if (recogidos >= totalColeccionables)
		{
			PasarAlSiguienteNivel();
		}
	}

	public void PerderNivel()
	{
		SceneManager.LoadScene("MenuPrincipal");
	}

	void PasarAlSiguienteNivel()
	{
		int siguienteNivel = SceneManager.GetActiveScene().buildIndex + 1;

		if (siguienteNivel < SceneManager.sceneCountInBuildSettings)
		{
			SceneManager.LoadScene(siguienteNivel);
		}
		else
		{
			// Si no hay más niveles, volver al menú
			SceneManager.LoadScene("MenuPrincipal");
		}
	}
}
