using UnityEngine;

/// <summary>
/// A FlowNodeSO that logs a message to the console.
/// </summary>
public class FlowNodeSO_DebugLog : FlowNodeSOBase
{
    #region -----Fields-----

    [Header("Settings")]

    [SerializeField] private string _textToLog;

    [SerializeField] private LogType _logType;

    #endregion -----|-----


    #region -----Lifecycle-----

#if UNITY_EDITOR
    // Editor
    private void OnValidate()
    {
        if (string.IsNullOrEmpty(_textToLog))
        { return; }

        this.name = $"Debug_{_logType}_{_textToLog}";

        UnityEditor.EditorUtility.SetDirty(this);
    }
#endif

    #endregion -----|-----


    #region -----Public API-----

    public override void Start()
    {
        if (string.IsNullOrEmpty(_textToLog))
        { return; }

        switch (_logType)
        {
            case LogType.Log:
                Debug.Log(_textToLog);
                break;

            case LogType.Warning:
                Debug.LogWarning(_textToLog);
                break;

            case LogType.Error:
                Debug.LogError(_textToLog);
                break;
            default: break;
        }
    }

    public override void Execute(out bool hasFinished)
    {
        hasFinished = true;
    }

    #endregion -----|-----

    [System.Serializable]
    private enum LogType
    {
        Log,
        Warning,
        Error
    }
}