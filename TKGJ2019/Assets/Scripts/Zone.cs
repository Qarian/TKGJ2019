using UnityEngine;

public class Zone : MonoBehaviour
{
	public float maxScale;
	public float lerpSpeed = 1f;

	public static float smallerScale = 0.9f;
	public static float increaseSize = 1f;
	static float smallestSize = 5f;
	// Easy to access object scale
    float targetScale;
	float scale;

	bool isMaxScale = false;

	Transform childTransform;
    Transform childTransform2;

    private void Start()
	{
		childTransform = transform.GetChild(0);
        childTransform2 = transform.GetChild(1);
    }

	private void Update()
	{
		scale += (targetScale - scale) * lerpSpeed * Time.deltaTime;
		childTransform.localScale = new Vector3(scale, scale);
        childTransform2.localScale = new Vector3(scale, scale);
    }

	public void ReduceScale()
	{
		if(isMaxScale)
			return;

		targetScale *= smallerScale;
		if(targetScale < smallestSize)
		{
			targetScale = smallestSize;
		}
	}

	public void IncreaseScale()
	{
		if(isMaxScale)
			return;

		targetScale += increaseSize;
		if(targetScale >= maxScale)
		{
			targetScale = maxScale;
			isMaxScale = true;
		}
	}

	// Set scale (to use on Start)
	public void SetScale(float targetScale)
	{
		this.targetScale = targetScale;
		scale = targetScale;

		smallestSize = targetScale;
	}

    

}
