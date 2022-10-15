using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween : MonoBehaviour
{
    [SerializeField]private float  time, currentTime;
    [SerializeField]private Transform target;
    [SerializeField] private Color color1, color2;
    [SerializeField] private AnimationCurve curve;
    [Range(0, 1f), SerializeField] private float relativeDistance;
    private Vector3 inicialPosition;
    private Vector3 targetPosicion;
    

    public enum Graft
    {
        Linear,
        EaseInOutElastic,
        EaseInSine,
        easeOutBounce,
        curve
    }

    [SerializeField] private Graft NowState; 

    private SpriteRenderer SpintRender;
    // Start is called before the first frame update
    void Start()
    {
        SpintRender = GetComponent<SpriteRenderer>();
        inicialPosition = transform.position;
        targetPosicion = target.position;
     
    }

    // Update is called once per frame
    void Update()
    {
        switch (NowState)
        {
            case Graft.Linear:
                    transform.position = Vector3.LerpUnclamped(inicialPosition, targetPosicion, relativeDistance);
                    SpintRender.color = Color.LerpUnclamped(color1,color2, relativeDistance);
                break;
            case Graft.EaseInOutElastic:
                transform.position = Vector3.LerpUnclamped(inicialPosition, targetPosicion, EaseInOutElastic(relativeDistance));
                SpintRender.color = Color.LerpUnclamped(color1, color2, EaseInOutElastic(relativeDistance));
                break;
            case Graft.EaseInSine:
                transform.position = Vector3.LerpUnclamped(inicialPosition, targetPosicion, EaseInSine(relativeDistance));
                SpintRender.color = Color.LerpUnclamped(color1, color2, EaseInSine(relativeDistance));
                break;
            case Graft.easeOutBounce:
                transform.position = Vector3.LerpUnclamped(inicialPosition, targetPosicion, easeOutBounce(relativeDistance));
                SpintRender.color = Color.LerpUnclamped(color1, color2, easeOutBounce(relativeDistance));
                break;
            case Graft.curve:
                transform.position = Vector3.LerpUnclamped(inicialPosition, targetPosicion, curve.Evaluate(relativeDistance));
                SpintRender.color = Color.LerpUnclamped(color1, color2, curve.Evaluate(relativeDistance));
                break;



        }
      if (currentTime <= time)
        {
            relativeDistance = currentTime/time;
            
            currentTime += Time.deltaTime;
         }  
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            StartTime();
        }
    }
    private void StartTime()
    {
        relativeDistance = 0;
        currentTime = 0;
        inicialPosition = transform.position;
        targetPosicion = target.position;

    }
    private float EaseInOutElastic(float x)
    {
        float c5 = (2f * Mathf.PI) / 4.5f;

        return x == 0f
          ? 0f
          : x == 1f
          ? 1f
          : x < 0.5
          ? -(Mathf.Pow(2f, 20f * x - 10f) * Mathf.Sin((20f * x - 11.125f) * c5)) / 2f
          : (Mathf.Pow(2f, -20f * x + 10f) * Mathf.Sin((20f * x - 11.125f) * c5)) / 2f + 1f;
    }
    private float EaseInSine(float x)
    {
        
        return 1 - Mathf.Cos((x* Mathf.PI) / 2);
    }

    private float easeOutBounce(float x)
    {
        const float n1 = 7.5625f;
        const float d1 = 2.75f;

        if (x < 1 / d1)
        {
            return n1 * x * x;
        }
        else if (x < 2 / d1)
        {
            return n1 * (x -= 1.5f / d1) * x + 0.75f;
        }
        else if (x < 2.5 / d1)
        {
            return n1 * (x -= 2.25f / d1) * x + 0.9375f;
        }
        else
        {
            return n1 * (x -= 2.625f / d1) * x + 0.984375f;
        }
    }

}
