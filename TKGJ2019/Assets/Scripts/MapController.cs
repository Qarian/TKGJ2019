using UnityEngine;
using System.Collections.Generic;

public class MapController : MonoBehaviour
{
	public float startScale;
	public float smallerScale;
	public float increaseSize;

	List<Zone> list = new List<Zone>();

    SpriteMask mask;

	void Start()
	{
		mask = GetComponent<SpriteMask>();
		for (int i = 0; i < transform.childCount; i++)
		{
			list.Add(transform.GetChild(i).GetComponent<Zone>());
			list[i].SetScale(startScale);
		}
		Zone.smallerScale = smallerScale;
		Zone.increaseSize = increaseSize;
	}
}
