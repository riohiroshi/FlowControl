using UnityEngine;

/// <summary>
/// A class that manages the flow.
/// </summary>
public class FlowControlManager : MonoBehaviour
{
    #region -----Fields-----

    [Header("Dependencies")]

    [SerializeField] private FlowNodeSOBase _mainFlow;

    [Header("Settings")]

    [SerializeField] private bool _isLoop = true;

    private bool _isFlowing = false;

    private FlowBlackboard _blackboard;

    #endregion -----|-----


    #region -----Lifecycle-----

    private void Start()
    {
        StartFlow();
    }

    private void Update()
    {
        Tick();
    }

    #endregion -----|-----


    #region -----Public API-----

    public FlowBlackboard Blackboard => _blackboard;

    public void StartFlow()
    {
        if (_mainFlow == null)
        { return; }

        _isFlowing = true;

        ResetBlackboard();

        InjectThisToAllFlowNodes();

        _mainFlow.Start();
    }

    public void Tick()
    {
        if (!_isFlowing)
        { return; }

        if (_mainFlow == null)
        { return; }

        _mainFlow.Execute(out bool isFinish);

        if (!isFinish)
        { return; }

        if (_isLoop)
        { StartFlow(); }
        else
        { _isFlowing = false; }
    }

    public void BreakFlow()
    {
        _isFlowing = false;
    }

    #endregion -----|-----

    private void ResetBlackboard()
    {
        if (_blackboard == null)
        {
            _blackboard = new();
            return;
        }

        _blackboard.ResetBlackboard();
    }

    private void InjectThisToAllFlowNodes()
    {
        _mainFlow.SetManager(this);
    }
}