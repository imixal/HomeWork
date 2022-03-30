using System.Collections.Generic;
using UnityEngine;

namespace Runner3D.Scripts.Service
{
	public interface ISceneService
	{
		AsyncOperation LoadScene(string name);
		AsyncOperation UnLoadScene(string name);
		bool IsLoading { get; }
		IEnumerable<GameObject> GetActiveRoots();
	}
}