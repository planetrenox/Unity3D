using UnityEngine;

[DisallowMultipleComponent]
internal sealed class VOID : MonoBehaviour
{
    private static VOID _Instance;
    private VOID Instance => _Instance ? _Instance : new GameObject("VOID").AddComponent<VOID>();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ResetStatic()
    {
        _Instance = null;
    }
    private void Awake()
    {
        if (_Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // private void OnEnable(){}
    // private void Start(){}
    // private void Update(){}
    // private void OnApplicationQuit(){}
    // private void OnDisable(){}

    private void OnDestroy()
    {
        if (_Instance != this) return;
        _Instance = null;
    }
    // https://docs.unity3d.com/Manual/ExecutionOrder.html
    // https://docs.unity3d.com/ScriptReference/RuntimeInitializeLoadType.html
}