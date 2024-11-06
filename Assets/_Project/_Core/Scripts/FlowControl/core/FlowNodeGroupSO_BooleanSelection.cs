using UnityEngine;



[CreateAssetMenu(fileName = "FlowNodeGroupSO_BooleanSelection_", menuName = "MySO/FlowControl/Groups/BooleanSelection", order = 1)]
public class FlowNodeGroupSO_BooleanSelection : FlowNodeSOBase
{
    #region -----Fields-----

    [SerializeField] private FlowBlackboardKeySO _keySO;

    [SerializeField] private FlowNodeSOBase _nodeForTrue;
    [SerializeField] private FlowNodeSOBase _nodeForFalse;
    [SerializeField] private FlowNodeSOBase _nodeForNull;

    [System.NonSerialized] private bool? _result;

    #endregion -----|-----

    #region -----Public API-----

    public override void SetManager(FlowControlManager value)
    {
        base.SetManager(value);

        _nodeForTrue.SetManager(value);
        _nodeForFalse.SetManager(value);

        if (_nodeForNull != null)
        { _nodeForNull.SetManager(value); }
    }

    public override void Start()
    {
        var key = _keySO.Key;
        if (!FlowControlManager.Blackboard.TryGetValue(key, out bool result))
        {
            _result = null;

            if (_nodeForNull != null)
            { _nodeForNull.Start(); }

            return;
        }

        if (result)
        {
            _result = true;
            _nodeForTrue.Start();
        }
        else
        {
            _result = false;
            _nodeForFalse.Start();
        }
    }

    public override void Execute(out bool hasFinished)
    {
        if (_result == null)
        {
            if (_nodeForNull != null)
            {
                _nodeForNull.Execute(out hasFinished);
                return;
            }

            hasFinished = true;

            return;
        }

        if (_result.Value)
        {
            _nodeForTrue.Execute(out hasFinished);
            return;
        }

        _nodeForFalse.Execute(out hasFinished);
    }

    #endregion -----|-----
}