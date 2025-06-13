using UnityEngine;

public class RotarEstrella : MonoBehaviour
{
	public float velocidad = 100f;

	void Update()
	{
		transform.Rotate(0f, 0f, velocidad * Time.deltaTime); // eje Z (2D)
	}
}
