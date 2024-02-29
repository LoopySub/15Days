using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Texture2D fadeOutTexture; // 검은색 텍스처를 사용하여 화면을 덮어요
    public float fadeSpeed = 0.8f;    // 페이드 아웃 속도. 높은 값일수록 빠르다.

    private int drawDepth = -1000;     // 텍스처가 렌더링될 깊이. 다른 UI보다 뒤에 렌더링되어야 함.
    private float alpha = 0f;        // 초기 알파 값은 1로 설정하여 텍스처가 완전히 불투명하게 시작한다.
    private int fadeDirection = -1;    // -1: 페이드 아웃, 1: 페이드 인

    void OnGUI()
    {
        // 알파 값 업데이트
        alpha += fadeDirection * fadeSpeed * Time.deltaTime;

        // 범위를 [0, 1]로 클램핑
        alpha = Mathf.Clamp01(alpha);

        // 텍스처를 그려서 화면을 덮기.
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    // 페이드 아웃 시작
    public float BeginFade(int direction)
    {
        fadeDirection = direction;
        return fadeSpeed;
    }

    // 씬 로드
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 페이드 인 시작
        BeginFade(-1);
    }
}
