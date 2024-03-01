using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static Public_Enum;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance;

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
        if (OverallManager.Instance.PublicVariable.Am_I_outside == true)
        {
            transform.localScale = new Vector3(0.7f, 0.7f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
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
            CheckForResearchableObject();
        }
    }

    // 플레이어가 바라보는 방향으로부터 0.5 거리 떨어진 곳에 researchable 오브젝트가 있는지 체크하는 메서드
    void CheckForResearchableObject()
    {
        float distance = 0.5f; // 원하는 거리

        // 플레이어의 현재 위치와 바라보는 방향을 가져옴
        Vector2 playerPosition = transform.position;
        Vector2 playerDirection = transform.right;

        // 플레이어가 바라보는 방향으로 0.5만큼 떨어진 지점 계산
        Vector2 raycastOrigin = playerPosition + playerDirection * distance;

        // 레이캐스트를 이용하여 해당 위치에 Collider가 있는지 확인
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, playerDirection);

        // Collider가 있고, researchable 컴포넌트를 갖고 있는지 확인
        if (hit.collider != null)
        {
            Researchable researchableObject = hit.collider.GetComponent<Researchable>();

            if (researchableObject != null)
            {
                // researchable 오브젝트를 찾았을 때 실행할 동작 추가
                researchableObject.Action();
            }
        }
    }

}
