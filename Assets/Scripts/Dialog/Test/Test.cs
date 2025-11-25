using UnityEngine;
using Zenject;

public class Test : MonoBehaviour
{
    [SerializeField] private DialogData _first;
    [SerializeField] private MainPersonDialogData _two;

    [Inject]
    private DialogController _controller;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            _controller.StartDialog(_first);
        else if (Input.GetKeyDown(KeyCode.S))
            _controller.StartDialog(_two);
    }
}
