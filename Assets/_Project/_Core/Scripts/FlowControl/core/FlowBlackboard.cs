using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class that handles the blackboard for the flow control.
/// </summary>
[Serializable]
public class FlowBlackboard
{
    #region -----Fields-----

    private readonly Dictionary<string, Type> _keyTypeLookupDict;

    private readonly Dictionary<Type, IDictionary> _typeObjectLookupDict;

    #endregion -----|-----


    #region -----Lifecycle-----

    public FlowBlackboard()
    {
        _keyTypeLookupDict = new();
        _typeObjectLookupDict = new();
    }

    #endregion -----|-----


    #region -----Public API-----

    public void ResetBlackboard()
    {
        _keyTypeLookupDict.Clear();
        _typeObjectLookupDict.Clear();
    }

    public void RegisterOrSetValue<T>(string key, T value = default)
    {
        if (string.IsNullOrEmpty(key))
        {
            Debug.LogError("Key name is null or empty");
            return;
        }

        var type = typeof(T);

        if (!_keyTypeLookupDict.ContainsKey(key))
        {
            _keyTypeLookupDict.Add(key, type);
        }
        else
        {
            if (_keyTypeLookupDict.TryGetValue(key, out Type existingType))
            {
                if (existingType != type)
                {
                    Debug.LogError($"Key {key} is already registered with type {existingType} and cannot be registered with type {type}");
                    return;
                }
            }
        }

        if (!_typeObjectLookupDict.ContainsKey(type))
        {
            var dict = new Dictionary<string, T> { { key, value } };
            _typeObjectLookupDict.Add(type, dict);
            return;
        }

        if (_typeObjectLookupDict[type] is Dictionary<string, T> typeDict)
        {
            typeDict[key] = value;
        }
    }

    public bool TryGetValue<T>(string key, out T value)
    {
        value = default;

        if (!_keyTypeLookupDict.TryGetValue(key, out var type))
        {
            Debug.LogError($"Key {key} is not registered");
            return false;
        }

        if (!_typeObjectLookupDict.TryGetValue(type, out var dict))
        {
            Debug.LogError($"Type {type} is not registered");
            return false;
        }

        if (dict is not Dictionary<string, T> typeDict)
        {
            Debug.LogError($"Key {key} is not registered as type {typeof(T)}");
            return false;
        }

        if (!typeDict.TryGetValue(key, out var tValue))
        {
            Debug.LogError($"Key {key} is not found in the dictionary");
            return false;
        }

        value = tValue;
        return true;
    }

    #endregion -----|-----
}