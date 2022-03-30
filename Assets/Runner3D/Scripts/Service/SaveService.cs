using UnityEngine;

namespace Runner3D.Scripts.Service
{
	public class SaveService : ISaveService
	{
		private ISaveService _saveServisImplementation;

		public void Write(object obj, string name)
		{
			var json = JsonUtility.ToJson(obj);
			PlayerPrefs.SetString(name,json);
		}

		public T Load<T>(string name)
		{
			if (PlayerPrefs.HasKey(name))
			{
				var json = PlayerPrefs.GetString(name);

				if (json == null)
					return default;
				return JsonUtility.FromJson<T>(json);
			}

			return default;
		}

		public void Save()
		{
			PlayerPrefs.Save();
		}
	}
}