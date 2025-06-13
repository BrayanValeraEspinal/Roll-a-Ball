using UnityEngine;

public class EstrellaMovimiento3D : MonoBehaviour
{
	public float velocidad = 5f;
	private Rigidbody rb;
	private Vector3 direccion;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		if (rb == null)
		{
			Debug.LogError("No Rigidbody found on " + gameObject.name);
			return;
		}

		// Dirección inicial aleatoria en plano XZ
		direccion = Random.onUnitSphere;
		direccion.y = 0f;
		direccion.Normalize();

		// Asigna velocidad inicial
		rb.velocity = direccion * velocidad;
	}

	void OnCollisionEnter(Collision collision)
	{
		Vector3 normal = collision.contacts[0].normal;
		direccion = Vector3.Reflect(direccion, normal).normalized;
		rb.velocity = direccion * velocidad;
	}
}
