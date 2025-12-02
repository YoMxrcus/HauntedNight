using UnityEngine;

public class scrCameraFullScreen : MonoBehaviour
{
    public float wantedAspectRatio = 16f / 9f;
    Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        cam = GetComponent<Camera>();
        SetCameraViewport();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetCameraViewport()
    {
        float currentAspectRatio = (float)Screen.width / Screen.height;

        if (currentAspectRatio > wantedAspectRatio)
        {
            float scale = wantedAspectRatio / currentAspectRatio;
            cam.rect = new Rect(0.5f - scale / 2f, 0f, scale, 1f);
        }
        else if (currentAspectRatio < wantedAspectRatio)
        {
            float scale = currentAspectRatio / wantedAspectRatio;
            cam.rect = new Rect(0f, 0.5f - scale / 2f, 1f, scale);
        }
    }
}
