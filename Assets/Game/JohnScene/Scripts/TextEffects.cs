using TMPro;
using UnityEngine;

public class TextEffects : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    private float initFontSize = 18f;
    [SerializeField] float amplitude = 1f;
    [SerializeField] float frequency = 1f;
    [SerializeField] float rotationAmplitude = 1f;
    [SerializeField] float rotationFrequency = 1f;
    void Start()
    {
        initFontSize = text.fontSize;
    }

    // Update is called once per frame
    void Update()
    {
        text.fontSize = initFontSize + Mathf.Sin(Time.time * frequency * 2 * Mathf.PI) * amplitude;
        float newRotation = Mathf.Sin(Time.time * rotationFrequency * 2 * Mathf.PI) * rotationAmplitude;
        text.rectTransform.localRotation = Quaternion.Euler(0, 0, newRotation);
    }
}
