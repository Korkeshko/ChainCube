using Scripts.Utils;
using UnityEngine;

// служебный, все компоненты будут знать про существование главного кубика
public class CubeDependencyInjector : MonoBehaviour
{
    [SerializeField] private GameObject _cube;

    private IDependency<GameObject>[] _dependencies;

    public GameObject Cube
    {
        get => _cube;
        set
        {
            if (_cube == value)
                return;

            _cube = value;
            Inject();
        }
    }

    private void Start()
    {
        _dependencies = GetComponents<IDependency<GameObject>>();

        if (_cube != null)
            Inject();
    }

    private void Inject()
    {
        foreach (var dependency in _dependencies)
        {
            dependency.Inject(Cube);
        }
    }
}

