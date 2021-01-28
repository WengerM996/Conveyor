using System.Collections.Generic;
using UnityEngine;

public class ConveyorBuild : MonoBehaviour
{
    [SerializeField] private Tape _tape;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _count;
    [SerializeField] private float _conveyorSpeed;
    [SerializeField] private Vector3 _direction;
    [SerializeField] private TapeEndTrigger _tapeEndTrigger;
    [SerializeField] private float _stepBetweenTapes;
    private List<Tape> _tapes;
    
    private void OnEnable()
    {
        _tapeEndTrigger.tapeHasReachedTheEndOfTheConveyor += OnTapeHasReachedTheEndOfTheConveyor;
    }

    private void OnDisable()
    {
        _tapeEndTrigger.tapeHasReachedTheEndOfTheConveyor -= OnTapeHasReachedTheEndOfTheConveyor;
    }

    private void Awake()
    {
        _tapes = new List<Tape>();
    }

    private void Start()
    {
        Build();
    }

    private void Build()
    {
        Vector3 position = _spawnPoint.position;
        for (int i = 0; i < _count; i++)
        {
            var tape = Instantiate(_tape, position, Quaternion.identity, transform);
            tape.GetComponent<Rigidbody>().AddForce(_direction * _conveyorSpeed, ForceMode.VelocityChange);
            _tapes.Add(tape);
            position.z += _stepBetweenTapes;
        }
    }

    private void OnTapeHasReachedTheEndOfTheConveyor(Tape tape)
    {
        ReSpawnTape(tape);
    }
    
    private void ReSpawnTape(Tape tape)
    {
        var position = _tapes[_tapes.Count - 1].transform.position;
        position.z += _stepBetweenTapes;
        tape.transform.position = position;
        _tapes.Remove(tape);
        _tapes.Add(tape);
    }
}
