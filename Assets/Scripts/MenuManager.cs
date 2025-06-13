using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	public void BotonJugar()
	{
		SceneManager.LoadScene("Nivel0");
	}

	public void Opciones()
	{
		SceneManager.LoadScene("Opciones");
	}

	public void VolverAlMenu()
	{
		SceneManager.LoadScene("MenuPrincipal");
	}
}
