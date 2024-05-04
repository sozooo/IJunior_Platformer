using UnityEngine;

public class Medkit : MonoBehaviour
{
    [SerializeField] private float _restoreAmount;

    public float RestoreAmount => _restoreAmount;
}
