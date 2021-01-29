using UnityEngine;
using UnityEngine.Events;

public class TapeEndTrigger : MonoBehaviour
{
    public event UnityAction<Tape> endOfConveyor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Tape tape))
        {
            endOfConveyor?.Invoke(tape);
        }
    }
}
