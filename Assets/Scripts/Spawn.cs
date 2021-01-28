using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnTemplates;
    [SerializeField] private Transform _point;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Action();
        }
    }

    private void Action()
    {
        var obj = Instantiate(_spawnTemplates[Random.Range(0, _spawnTemplates.Count)], _point.position, Quaternion.identity, transform);
        obj.transform.localScale = new Vector3(GetRandomScale(), GetRandomScale(), GetRandomScale());
        Destroy(obj, 5f);
    }

    private float GetRandomScale()
    {
        return Random.Range(0.1f, 0.5f);
    }
}
