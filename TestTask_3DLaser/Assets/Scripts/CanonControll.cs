using UnityEngine;

public class CanonControll : MonoBehaviour
{
    [SerializeField] private Transform _horizontalTurn;
    [SerializeField] private Transform _verticalTurn;
    [SerializeField] private float _rotationSpeed = 100f;

    private void Update()
    {
        RotateCanon(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    public void RotateCanon(float hor, float vert)
    {
        _horizontalTurn.Rotate(new Vector3(0f, hor, 0f) * _rotationSpeed * Time.deltaTime);
        _verticalTurn.Rotate(new Vector3(vert, 0f, 0f) * _rotationSpeed * Time.deltaTime);
    }
}
