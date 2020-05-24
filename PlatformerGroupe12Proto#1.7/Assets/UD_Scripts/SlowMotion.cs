using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public float slowDownFactor = 0.05f;
    public float slowDownLenght = 5f;

    private void Update()
    {
        Time.timeScale += (1f / slowDownLenght) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void StartSlowMotion()
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
