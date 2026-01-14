using UnityEngine;
using Zenject;

public class Testick : MonoBehaviour
{
    [Inject]
    private void Construct(EventBus data)
    {
        Debug.Log("ÄÀ ÂÑÅ ÈÍÄÆÅÊÒÈÖÀ");
    }

}
