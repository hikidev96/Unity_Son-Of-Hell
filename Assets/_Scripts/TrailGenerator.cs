using System.Collections;
using UnityEngine;

public class TrailGenerator : MonoBehaviour
{
    [Header("Should be gameobject that has meshRenderer")] public GameObject Target;
    [Range(0f, 1f)] public float TrailAlpha;
    [ColorUsage(true, true)] public Color TrailColor;
    public float TrailIntervalTime;
    public float TrailDisappearSpeed;

    private IEnumerator generateTrailCoroutine;

    private void OnDisable()
    {
        StopTrail();
    }

    public void StartTrail()
    {
        generateTrailCoroutine = GenerateTrail();
        StartCoroutine(generateTrailCoroutine);
    }

    public void StopTrail()
    {
        if (generateTrailCoroutine == null)
        {
            return;
        }

        StopCoroutine(generateTrailCoroutine);
    }

    private void GenerateTrailObjects()
    {
        if (this.Target == null)
        {
            return;
        }

        GameObject trail = new GameObject("Trail");
        trail.AddComponent<MeshFilter>();
        trail.AddComponent<MeshRenderer>();
        trail.AddComponent<Trail>();

        trail.transform.position = this.Target.transform.position;
        trail.transform.rotation = this.Target.transform.rotation;

        trail.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        trail.GetComponent<MeshRenderer>().material = GetTrailMat();
        trail.GetComponent<Trail>().Init(this.TrailDisappearSpeed, this.Target.GetComponent<SkinnedMeshRenderer>(), this.TrailAlpha);        
    }

    private Material GetTrailMat()
    {
        Material result = new Material(Shader.Find("EasyGameStudio/trail"));
        result.SetTexture("main_texture", this.Target.GetComponent<SkinnedMeshRenderer>().material.mainTexture);
        result.SetColor("color_fresnel_emission", this.TrailColor);

        return result;
    }

    IEnumerator GenerateTrail()
    {
        while (true)
        {
            GenerateTrailObjects();
            yield return new WaitForSeconds(this.TrailIntervalTime);
        }
    }
}
