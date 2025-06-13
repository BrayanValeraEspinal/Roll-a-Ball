using UnityEngine;

public class ObstaculoMovimiento : MonoBehaviour
{
	public float distanciaLateral = 5f;
	public float velocidad = 2f;

	private Vector3 puntoA;
	private Vector3 puntoB;
	private bool haciaA = false;

	void Start()
	{
		// Define los puntos A y B relativos a la posición inicial
		puntoA = transform.position + new Vector3(-distanciaLateral, 0f, 0f);
		puntoB = transform.position + new Vector3(distanciaLateral, 0f, 0f);
	}

	void Update()
	{
		if (haciaA)
		{
			transform.position = Vector3.MoveTowards(transform.position, puntoA, velocidad * Time.deltaTime);
			if (Vector3.Distance(transform.position, puntoA) < 0.1f)
				haciaA = false;
		}
		else
		{
			transform.position = Vector3.MoveTowards(transform.position, puntoB, velocidad * Time.deltaTime);
			if (Vector3.Distance(transform.position, puntoB) < 0.1f)
				haciaA = true;
		}
	}
}
