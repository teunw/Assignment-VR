using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Valve.VR;
using VRTK;

[RequireComponent(typeof(AudioSource))]
public class Spraycan : VRTK_InteractableObject
{
    public GameObject TrailParentAfterDrawing;
    public GameObject TrailParentWhileDrawing;
    public TrailRenderer TrailRenderer;
    public Material OptionalTrailRendererMaterial;

    private AudioSource AudioSource;
    private List<TrailRenderer> TrailRenderers = new List<TrailRenderer>();
    private TrailRenderer CurrentTrailRenderer;

    public void Start()
    {
        this.AudioSource = GetComponent<AudioSource>();
    }

    private Material getTrailRendererMaterial()
    {
        if (this.OptionalTrailRendererMaterial != null)
        {
            return this.OptionalTrailRendererMaterial;
        }
        return this.TrailRenderer.material;
    }

    public override void OnInteractableObjectUsed(InteractableObjectEventArgs e)
	{
		base.OnInteractableObjectUsed(e);
		StartSpray();
	}

	public override void OnInteractableObjectUnused(InteractableObjectEventArgs e)
	{
		base.OnInteractableObjectUnused(e);
		StopSpray();
    }
	
	

    public void ClearSprays()
    {
        TrailRenderers.ForEach(tr => Destroy(tr));
        TrailRenderers.Clear();
    }

	public void StopSpray()
	{
        this.AudioSource.Stop();
        CurrentTrailRenderer.transform.parent = TrailParentAfterDrawing.transform;
        TrailRenderers.Add(CurrentTrailRenderer);
        CurrentTrailRenderer = null;
	}

	public void StartSpray()
	{
        var newGm = Instantiate(TrailRenderer);
        newGm.transform.parent = TrailParentWhileDrawing.transform;
        newGm.transform.localPosition = new Vector3(0f, 0f, 0f);
        newGm.material = this.getTrailRendererMaterial();

        CurrentTrailRenderer = newGm;
        this.AudioSource.Play();
	}
}
