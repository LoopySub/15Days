using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Prg_SkipButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Vector3 Next;

    private void Start()
    {
        OverallManager.Instance.PublicVariable.NextCoordinate = Next;
    }
    public void skip()
    {
        OverallManager.Instance.UiManager.HideDialog();
        OverallManager.Instance.PublicVariable.GameState = Public_Enum.GameState.Playing;
        OverallManager.Instance.PublicVariable.Am_I_outside = false;
        OverallManager.Instance.PublicVariable.CurrentHour = 8;
        OverallManager.Instance.PublicVariable.Day = 1;
        OverallManager.Instance.UiManager.DayChangeTextOn(true);
        OverallManager.Instance.SceneTransition.TransitToNextScene("Game_Livingroom Scene");
    }
}
