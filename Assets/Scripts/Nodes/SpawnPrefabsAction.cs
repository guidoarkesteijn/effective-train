using UnityEngine;

[CreateNodeMenu("Action/SpawnPrefabs")]
public class SpawnPrefabsAction : BaseAction
{
    [SerializeField] private GameObject[] prefabs;

    private GameObject[] spawnedPrefabs;

    public override void Start()
    {
        Debug.LogError("SPAWN: " + prefabs.Length);
    }

    public override void Stop()
    {
        Debug.LogError("Destroy spawnedPrefabs");
    }
}
