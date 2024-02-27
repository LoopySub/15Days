using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : BaseMonoBehaviour
{
    // ============================================[￠开曼炼 备开￠]=================================================

    private IOverallManager _overallManager;

    public IOverallManager _OverallManager
    {
        get { return _overallManager; }
    }

    public void Init(IOverallManager overallManager)
    {
        _overallManager = overallManager;
    }

    // ============================================[¤开曼炼 备开¤]=================================================

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
