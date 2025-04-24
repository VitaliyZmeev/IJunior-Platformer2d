using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class ActorRigidbody : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _collider;

    public Rigidbody2D Rigidbody => _rigidbody;

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

    public void SetExcludeLayerMask(string nameLayerMask)
    {
        _rigidbody.excludeLayers = 1 << LayerMask.NameToLayer(nameLayerMask);
    }

    public void ResetExcludeLayerMask()
    {
        _rigidbody.excludeLayers = default;
    }
}