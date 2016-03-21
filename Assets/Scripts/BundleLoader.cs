using UnityEngine;
using System.Collections;

public class BundleLoader
{
	public static Object Load(string bundlePath)
	{
		return Resources.Load(bundlePath);
	}

	public static void Unload(string bundlePath)
	{

	}
}
