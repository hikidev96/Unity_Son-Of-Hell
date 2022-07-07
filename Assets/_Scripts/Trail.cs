using UnityEngine;

public class Trail : MonoBehaviour
{
    private float disappearSpeed;
    private float alpha;
    private Material material;    

    void Update()
    {
        if (this.material != null)
        {
            this.alpha = Mathf.Lerp(this.alpha, 0, this.disappearSpeed * Time.deltaTime);

            this.material.SetFloat("alpha", this.alpha);

            if (this.alpha < 0.01f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void Init(float disappearSpeed, SkinnedMeshRenderer skinnedMeshRenderer, float alpha)
    {
        this.disappearSpeed = disappearSpeed;
        this.alpha = alpha;
        this.material = this.GetComponent<MeshRenderer>().material;

        SetBakedMesh(skinnedMeshRenderer);        
    }

    private void SetBakedMesh(SkinnedMeshRenderer skinnedMeshRenderer)
    {
        var bakedMeshResult = new Mesh();
        skinnedMeshRenderer.BakeMesh(bakedMeshResult);
        this.GetComponent<MeshFilter>().mesh = bakedMeshResult;
    }
}