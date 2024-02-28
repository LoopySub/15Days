using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestManager : BaseMonoBehaviour
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

    // ============================================[↓테스트용 메서드 구역↓]=================================================


    // 시간 조절을 위한 변수
    float originalTimeScale;

    // Start is called before the first frame update
    void Start()
    {
        originalTimeScale = Time.timeScale; // 초기 시간 스케일 저장
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // 1을 입력하면 시간 빠르게
            Time.timeScale += 2f;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // 2를 입력하면 시간 느리게
            Time.timeScale -= 2f;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // 3을 입력하면 시간 초기화
            Time.timeScale = originalTimeScale;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            // 4를 입력하면 시간 정지 / 재개
            Time.timeScale = Time.timeScale == 0 ? originalTimeScale : 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            // 5를 입력하면 변수들을 디버그 로그로 표시
            LogDebugInformation();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            // 6을 입력하면 다음 씬
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            // 7을 입력하면 이전 씬
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            // 8을 입력하면 씬 초기화
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "Jone", "텍스트가 차례대로 나와요 우왕 신기 치피치피차파차파두비부디다바다바 라라라랄라 라라라라라 랄라");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            OverallManager.Instance.UiManager.HideDialog();
        }
        // 9와 0은 미정
    }

    void LogDebugInformation()
    {
        // 여기에 디버그 로그로 표시할 변수들을 추가
        Debug.Log("Debug Information");
    }

    // ============================================[↑테스트용 메서드 구역↑]=================================================
}