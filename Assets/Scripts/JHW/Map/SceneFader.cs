using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Texture2D fadeOutTexture; // ������ �ؽ�ó�� ����Ͽ� ȭ���� �����
    public float fadeSpeed = 0.8f;    // ���̵� �ƿ� �ӵ�. ���� ���ϼ��� ������.

    private int drawDepth = -1000;     // �ؽ�ó�� �������� ����. �ٸ� UI���� �ڿ� �������Ǿ�� ��.
    private float alpha = 0f;        // �ʱ� ���� ���� 1�� �����Ͽ� �ؽ�ó�� ������ �������ϰ� �����Ѵ�.
    private int fadeDirection = -1;    // -1: ���̵� �ƿ�, 1: ���̵� ��

    void OnGUI()
    {
        // ���� �� ������Ʈ
        alpha += fadeDirection * fadeSpeed * Time.deltaTime;

        // ������ [0, 1]�� Ŭ����
        alpha = Mathf.Clamp01(alpha);

        // �ؽ�ó�� �׷��� ȭ���� ����.
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    // ���̵� �ƿ� ����
    public float BeginFade(int direction)
    {
        fadeDirection = direction;
        return fadeSpeed;
    }

    // �� �ε�
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
        // ���̵� �� ����
        BeginFade(-1);
    }
}
