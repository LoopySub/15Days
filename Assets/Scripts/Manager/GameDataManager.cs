using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Public_Enum;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class GameDataManager : BaseMonoBehaviour    // 게임 데이터를 직접적으로 관리하는 메서드와 동작들이 있는 스크립트
{
    // ============================================[↓역참조 구역↓]=================================================

    private IOverallManager _overallManager;

    public IOverallManager _OverallManager
    {
        get { return _overallManager; }
    }

    public void Init(IOverallManager overallManager)
    {
        _overallManager = overallManager;
    }

    // ============================================[↑역참조 구역↑]=================================================
    // =======================================[↓게임 데이터 메소드 구역↓]==========================================
    
    
    //취침 시 배부름에 따라 스태미나 회복
    public void RecoverStaminaAfterSleep()
    {
        if (OverallManager.Instance.PublicVariable.Fullness >= 100)
            OverallManager.Instance.PublicVariable.Stamina = 120.0f;
        else if (OverallManager.Instance.PublicVariable.Fullness >= 75)
            OverallManager.Instance.PublicVariable.Stamina = 100.0f;
        else
            OverallManager.Instance.PublicVariable.Stamina = (OverallManager.Instance.PublicVariable.Fullness >= 70) ? 90.0f :
                        (OverallManager.Instance.PublicVariable.Fullness >= 65) ? 80.0f :
                        (OverallManager.Instance.PublicVariable.Fullness >= 60) ? 70.0f :
                        (OverallManager.Instance.PublicVariable.Fullness >= 55) ? 60.0f :
                        (OverallManager.Instance.PublicVariable.Fullness >= 50) ? 50.0f :
                        (OverallManager.Instance.PublicVariable.Fullness >= 45) ? 40.0f :
                        (OverallManager.Instance.PublicVariable.Fullness >= 40) ? 30.0f :
                        (OverallManager.Instance.PublicVariable.Fullness >= 35) ? 20.0f :
                        (OverallManager.Instance.PublicVariable.Fullness >= 30) ? 10.0f : 0.0f;

        if (OverallManager.Instance.PublicVariable.IsRest == true)
        {
            OverallManager.Instance.PublicVariable.Stamina += 20;
        }
    }

    // 공격 받을 시 하트 감소 // 플레이어 체력을 사용하므로 하트는 더미 데이터
    public void DecreaseHeartsOnAttack()
    {
        OverallManager.Instance.PublicVariable.Hearts -= -1;
    }

    //취침시 하트 재충전 // 플레이어 체력을 사용하므로 하트는 더미 데이터
    public void ResetHearts()
    {
        OverallManager.Instance.PublicVariable.Hearts = OverallManager.Instance.PublicVariable.MaxHearts;
    }

    //취침시 오염도 증가
    public void Contamination_Increases()
    {
        if (OverallManager.Instance.PublicVariable.IsRebeccaCured != true)
        {
            OverallManager.Instance.PublicVariable.Contamination += Random.Range(25, 36);
        }
    }




    //선택지 5. 운동하기. 5시간 소비. 스태미나 40 소비. 최대 하트 1 증가. // 더미 데이터
    public void Exercise()
    {
        if (Time_And_Stamina_Check(5, 40))
        {
            {
                OverallManager.Instance.PublicVariable.MaxHearts += 1;
                OverallManager.Instance.PublicVariable.Hearts += 1;
                Time_And_Stamina_Increase(5, 40);
            }
        }
    }


    private void Attacked_From_Rebecca() //간호하는 중 레베카에게 공격 당할 시 // 더미 데이타
    {
        OverallManager.Instance.PublicVariable.Stamina -= 10;
        if (OverallManager.Instance.PublicVariable.Stamina < 0)
        {
        }
    }

    //엔딩 씬 이동 메서드
    public void Ending(Ending_type end)
    {
        if(OverallManager.Instance.PublicVariable.GameState != GameState.Cutscene)
        {
         OverallManager.Instance.UiManager.HideDialog();
         OverallManager.Instance.PlayerManager.ResetRch();
        OverallManager.Instance.UiManager.HideStateUI();
            OverallManager.Instance.UiManager.ShowRebeccaUI(false);
         OverallManager.Instance.PublicVariable.Ending_Type = end;
        OverallManager.Instance.PublicVariable.GameState = GameState.Cutscene;
        OverallManager.Instance.PublicVariable.NextCoordinate = new Vector3 (0,0, 0);
        OverallManager.Instance.SceneTransition.TransitToNextScene("Ending Scene");
        }
        /*
        if(end == Ending_type.GameOver)
        {

        }
        else if(end == Ending_type.Infection)
        {

        }
        else if(end == Ending_type.Starvation)
        {

        }
        else if(end == Ending_type.Normal)
        {

        }
        else if(end == Ending_type.True)
        {

        }
        else if(end == Ending_type.OverNight)
        {

        }
        */
    }


    //시간 및 스테미나 체크
    private bool Time_And_Stamina_Check(int time, float stamina)
    {
        if ((OverallManager.Instance.PublicVariable.CurrentHour + time) > 24)
        {
            Debug.Log("이 작업을 하기에는 시간이 부족할 것 같다.");
            return false;
        }
        if ((OverallManager.Instance.PublicVariable.Stamina - stamina < 0))
        {
            Debug.Log("스태미나가 부족하다.");
            return false;
        }
        return true;
    }

    //시간 및 스태미나 증가
    private void Time_And_Stamina_Increase(int time, float stamina)
    {
        OverallManager.Instance.PublicVariable.CurrentHour += time;
        OverallManager.Instance.PublicVariable.Stamina -= stamina;
    }



    //


    // =======================================[↑게임 데이터 메소드 구역↑]==========================================
}
