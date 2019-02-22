using UnityEngine;

public class Zone : MonoBehaviour
{
	public static float smallerScale;
	public static float increaseSize;
	// Easy to access object scale
    float scale;

	// Change SmallerScale
	public void ChangeScale()
	{
		scale *= smallerScale;
		transform.localScale = new Vector3(scale, scale);
	}

	public void IncreaseScale()
	{
		scale += increaseSize;
		transform.localScale = new Vector3(scale, scale);
	}

	// Set scale (to use on Start)
	public void SetScale(float targetScale)
	{
		scale = targetScale;
		transform.localScale = new Vector3(scale, scale);
	}
}
