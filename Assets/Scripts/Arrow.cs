using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Arrow : MonoBehaviour
{
    private Rigidbody rigidB;
    public float force;
    public float selfDestroy;
    public int damage;

    void Start()
    {
        rigidB = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("acertou um alvo");
        if (other.gameObject.tag == "Enemy")
        {
            rigidB.useGravity = false;
            rigidB.velocity = Vector3.zero;
            transform.parent = other.gameObject.transform;
            other.GetComponentInParent<EnemyStats>().Hit(damage);
            Debug.Log("Inimigo Atingido");
        }
        if (other.gameObject.tag == "Terrain")
        {
            rigidB.useGravity = false;
            rigidB.velocity = Vector3.zero;
            transform.parent = other.gameObject.transform;
            Debug.Log("Terreno atingido");
        }
        if (other.gameObject.tag == "Obstacle")
        {
            rigidB.useGravity = false;
            rigidB.velocity = Vector3.zero;
            transform.parent = other.gameObject.transform;
            Debug.Log("Obstáculo atingido");
        }
    }
    public void OnShot()
    {
        transform.parent = null;
        rigidB.AddForce(transform.forward * force);
        Destroy(this, selfDestroy);
    }
}
