using UnityEngine;
using UnityEngine.UI;

public class UiButtonsControll : MonoBehaviour
{
    [SerializeField] private Button MoveUpButton;
    [SerializeField] private Button MoveDownButton;
    [SerializeField] private Button MoveLeftButton;
    [SerializeField] private Button MoveRightButton;

    [SerializeField] private CanonControll _canon;

    [SerializeField] private float angle;

    private void Awake()
    {
        MoveUpButton.onClick.AddListener(MoveUp);
        MoveDownButton.onClick.AddListener(MoveDown);
        MoveLeftButton.onClick.AddListener(MoveLeft);
        MoveRightButton.onClick.AddListener(MoveRight);
    }

    private void MoveUp()
    {
        _canon.RotateCanon(0, -angle);
    }
    private void MoveDown()
    {
        _canon.RotateCanon(0, angle);
    }
    private void MoveLeft()
    {
        _canon.RotateCanon(-angle, 0);
    }
    private void MoveRight()
    {
        _canon.RotateCanon(angle, 0);
    }
}
