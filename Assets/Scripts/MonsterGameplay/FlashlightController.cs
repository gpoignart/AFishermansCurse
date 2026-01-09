using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlashlightController : MonoBehaviour
{
    public static FlashlightController Instance { get; private set; }

    [SerializeField] private Transform cam; // Main Camera
    [SerializeField] private RectTransform beam; // UI flashlight beam (Image)
    [SerializeField] private Image timerRing;
    [SerializeField] private Color startColorTimerRing;
    [SerializeField] private Color endColorTimerRing;

    // Parameters
    private float hitRadius = 130f; // Distance threshold for hit
    private float maxPan = 6f; // How far camera pans left/right

    // Internal attributes
    private RectTransform beamParent;
    private float camDefaultX;
    private Vector2 beamPosition;
    private Vector2 beamLimits;

    // Read-only public attribute
    public RectTransform BeamParent => beamParent;
    public Vector2 BeamPosition => beamPosition;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        camDefaultX = cam.localPosition.x;
    }

    public void StartFlashlight()
    {
        // Setup flashlight visuals
        Cursor.visible = false;

        beam.sizeDelta = GameManager.Instance.PlayerEquipmentRegistry.flashlightSO.beamSize;
        timerRing.rectTransform.sizeDelta = GameManager.Instance.PlayerEquipmentRegistry.flashlightSO.beamTimerSize;

        beamParent = beam.parent as RectTransform;

        beamLimits = beamParent.rect.size * 0.5f;

        beamPosition = Vector2.zero;
        beam.localPosition = beamPosition;

        ShowFlashlightBeam();

        // Reset camera to center
        cam.localPosition = new Vector3(
            camDefaultX,
            cam.localPosition.y,
            cam.localPosition.z
        );

        ResetTimerRing();
    }

    public void UpdateFlashlight(float loseTimer, float loseTime, bool isChecking)
    {
        UpdateBeamPosition();
        UpdateCameraPan();
        if (isChecking) { CheckHitMonster(); }
        UpdateTimerRing(loseTimer, loseTime);
    }

    // Timer ring
    private void ResetTimerRing()
    {
        timerRing.fillAmount = 1f;
        timerRing.color = startColorTimerRing;
    }

    private void UpdateTimerRing(float loseTimer, float loseTime)
    {
        float fill = Mathf.Clamp01(1f - (loseTimer / loseTime));
        timerRing.fillAmount = fill;
        timerRing.color = Color.Lerp(endColorTimerRing, startColorTimerRing, fill);
    }

    // Show and hide flashlight beam
    public void ShowFlashlightBeam()
    {
        beam.gameObject.SetActive(true);
    }

    public void HideFlashlightBeam()
    {
        beam.gameObject.SetActive(false);
    }

    // Beam follows mouse inside the UI canvas
    private void UpdateBeamPosition()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(x, y);

        beamPosition += input
            * GameManager.Instance.PlayerEquipmentRegistry.flashlightSO.beamSpeed
            * Time.deltaTime;

        beamPosition.x = Mathf.Clamp(beamPosition.x, -beamLimits.x, beamLimits.x);
        beamPosition.y = Mathf.Clamp(beamPosition.y, -beamLimits.y, beamLimits.y);

        beam.localPosition = Vector2.Lerp(
            beam.localPosition,
            beamPosition,
            Time.deltaTime * GameManager.Instance.PlayerEquipmentRegistry.flashlightSO.beamSpeed
        );
    }

    // Camera pans horizontally based on the flashlight beam movements
    private void UpdateCameraPan()
    {
        float normalizedX = Mathf.InverseLerp(
            -beamLimits.x,
            beamLimits.x,
            beam.localPosition.x
        );

        float centered = (normalizedX - 0.5f) * 2f;

        float targetX = camDefaultX + centered * maxPan;

        cam.localPosition = Vector3.Lerp(
            cam.localPosition,
            new Vector3(targetX, cam.localPosition.y, cam.localPosition.z),
            Time.deltaTime * GameManager.Instance.PlayerEquipmentRegistry.flashlightSO.beamSpeed
        );
    }

    // Check if flashlight beam hits the monster
    private void CheckHitMonster()
    {
        if (MonsterGameManager.Instance.CurrentMonsterObj == null) { return; }

        // Convert monster world position → UI space
        Vector2 screenPos = Camera.main.WorldToScreenPoint(
            MonsterGameManager.Instance.CurrentMonsterObj.transform.position
        );

        Vector2 monsterUIpos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            beamParent,
            screenPos,
            Camera.main,
            out monsterUIpos
        );

        float distance = Vector2.Distance(beam.localPosition, monsterUIpos);

        if (distance < hitRadius)
        {
            MonsterGameManager.Instance.CurrentMonsterObj
                .GetComponent<Monster>()
                .HitByFlashlight();
        }
    }
}
