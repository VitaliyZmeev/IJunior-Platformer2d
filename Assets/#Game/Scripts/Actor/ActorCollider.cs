using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class ActorCollider : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _collider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }

    public void Enable()
    {
        _rigidbody.isKinematic = false;
        _collider.enabled = true;
    }

    public void Disable()
    {
        _rigidbody.isKinematic = true;
        _collider.enabled = false;
    }
}