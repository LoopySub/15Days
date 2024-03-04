using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static Public_Enum;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance;

    public Researchable SelectResearchable;

    private void Awake()
    {
        // 이미 인스턴스가 있는지 확인하고, 있다면 자신을 파괴
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        // 이 오브젝트를 파괴되지 않도록 설정
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬이 로드된 후에 호출되는 콜백
        transform.position = OverallManager.Instance.PublicVariable.NextCoordinate;
        OverallManager.Instance.UiManager.textRenewal();
        Invoke("DayChangeTextOff", 0.5f);
        Invoke("IsRestOff", 0.5f);
        


        if(OverallManager.Instance.PublicVariable.IsRest == true)
        {
            OverallManager.Instance.UiManager.HideDialog();
            OverallManager.Instance.PublicVariable.IsRest = false;
        }

        if (OverallManager.Instance.PublicVariable.Am_I_outside == true)
        {
            transform.localScale = new Vector3(0.7f, 0.7f, 1.0f);
            OverallManager.Instance.PublicVariable.CurrentHour += 1;

        }
        else
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        if(OverallManager.Instance.PublicVariable.Ending_Type ==Ending_type.None && OverallManager.Instance.PublicVariable.CurrentHour == 8 && OverallManager.Instance.PublicVariable.Am_I_outside ==false && OverallManager.Instance.PublicVariable.IsDM ==false)
        {
            Invoke("Morning_Monologue", 0.6f);
        }
    }

    void Morning_Monologue()
    {
        if (SelectResearchable == null)
        {
            OverallManager.Instance.PublicVariable.IsDM = true;
            SelectResearchable = OverallManager.Instance.UiManager.morning_monologue;
            SelectResearchable.Click_Text_Reset();
            SelectResearchable.Action();
        }
    }


    public void playerSetActive(GameState gameState)
    {
            if (gameState == GameState.Cutscene)
            {
                // Cutscene 상태인 경우
                gameObject.SetActive(false);
            }
            else
            {
                // 그 외의 경우
                gameObject.SetActive(true);
            }
    }



    // 플레이어가 'Z' 키를 눌렀을 때 호출되는 메서드
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (SelectResearchable != null)
            {
                if (OverallManager.Instance.PublicVariable.IsDialog == true)
                {
                    SelectResearchable.Action();
                }
            }
            else
            {
                CheckForResearchableObject();
            }
        }
    }

    void DayChangeTextOff()
    {
        OverallManager.Instance.UiManager.DayChangeTextOn(false);
        Time.timeScale = 1.0f;
    }

    void IsRestOff()
    {
        OverallManager.Instance.PublicVariable.IsRest = false;
        Time.timeScale = 1.0f;
    }

    public void ResetRch()
    {
        SelectResearchable = null;
    }

    void CheckForResearchableObject()
    {
        float maxDistance = 0.5f; // 원하는 거리

        // 플레이어의 현재 위치 가져옴
        Vector2 playerPosition = transform.position;

        // 마우스 위치를 월드 좌표로 변환
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 플레이어에서 마우스로 향하는 방향 계산
        Vector2 playerToMouseDirection = (mousePosition - playerPosition).normalized;

        // 플레이어에서 마우스 방향으로 최대 거리까지의 좌표 계산
        Vector2 targetPosition = playerPosition + playerToMouseDirection * maxDistance;

        // 해당 위치에 Collider가 있는지 확인
        Collider2D[] colliders = Physics2D.OverlapCircleAll(targetPosition, 0.1f); // 원형 영역 검사

        // Researchable 컴포넌트를 갖고 있는지 확인
        foreach (var collider in colliders)
        {
            SelectResearchable = collider.GetComponent<Researchable>();
            if (SelectResearchable != null)
            {
                // Researchable 오브젝트를 찾았을 때 실행할 동작 추가
                SelectResearchable.Action();
                break; // 만약 여러 오브젝트 중 하나만 실행하려면 break 추가
            }
        }
    }
}
