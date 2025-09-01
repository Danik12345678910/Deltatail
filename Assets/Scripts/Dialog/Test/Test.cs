using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private DialogData _first;
    [SerializeField] private DialogData _two;
    private DialogController _controller;

    private void Start()
    {
        _controller = ServiceLocator.Current.GetService<DialogController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            _controller.StartDialog(_first);
        else if (Input.GetKeyDown(KeyCode.S))
            _controller.StartDialog(_two);
    }
}
