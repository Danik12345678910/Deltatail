using UnityEngine;
using Zenject;

public class Test : MonoBehaviour
{
    [SerializeField] private DialogData _first;
    [SerializeField] private MainPersonDialogData _two;

    [Inject]
    private IDialogStartable<DialogData> _controller;
    [Inject]
    private IDialogStartable<MainPersonDialogData> _controller2;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            _controller.StartDialog(_first);
        else if (Input.GetKeyDown(KeyCode.S))
            _controller2.StartDialog(_two);
    }
}
