using UnityEngine;

/// <summary>
/// A class that contains a string key for the blackboard.
/// </summary>
[CreateAssetMenu(fileName = "FlowBlackboardKeySO_", menuName = "MySO/FlowControl/BlackboardKey", order = 0)]
public class FlowBlackboardKeySO : ScriptableObject
{
    [SerializeField] private string _key;

    public string Key => _key;
}