using UnityEngine;

/// <summary>
/// A base class for all flow nodes.
/// </summary>
public abstract class FlowNodeSOBase : ScriptableObject
{
    #region -----Fields-----

    [System.NonSerialized] protected FlowControlManager _flowControlManager;

    #endregion -----|-----


    #region -----Public API-----

    public FlowControlManager FlowControlManager => _flowControlManager;

    public virtual void SetManager(FlowControlManager value) => _flowControlManager = value;

    public abstract void Start();

    public abstract void Execute(out bool hasFinished);

    #endregion -----|-----
}