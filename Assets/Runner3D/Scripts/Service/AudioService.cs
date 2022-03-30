using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Runner3D.Scripts.Service
{
	public interface IAudioService
	{
		void Play(string soundName);
		void Stop(string soundName);
		float Volume { get; set; }
	}

	public class AudioService : IAudioService
	{
		private readonly Dictionary<string, Sound> _sounds;
		private float _volume = 1;
		public AudioService(IEnumerable<Sound> sounds)
		{
			_sounds = sounds.ToDictionary(s => s.name);
		}
		public void Play(string soundName)
		{
			if (_sounds.TryGetValue(soundName, out var sound))
			{
				sound.source.Play();
				return;
			}
			Debug.LogWarning($"The sound {soundName} not found");
		}

		public void Stop(string soundName)
		{
			if (_sounds.TryGetValue(soundName, out var sound))
			{
				sound.source.Stop();
				return;
			}
			Debug.LogWarning($"The sound {soundName} not found");
		}

		public float Volume
		{
			get => _volume;
			set
			{
				_volume = value;
				foreach (var kv in _sounds)
				{
					kv.Value.source.volume = _volume;
				}
			} 
		}
	}
	
	[Serializable]
	public class Sound
	{
		public string name;
		public AudioClip clip;
		[Range(0f, 1f)]
		public float pitch;
		public bool loop;
        
		[HideInInspector]
		public AudioSource source;
	}
}