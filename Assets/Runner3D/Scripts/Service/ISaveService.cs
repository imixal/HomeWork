namespace Runner3D.Scripts.Service
{
	public interface ISaveService
	{
		void Write(object obj, string name);

		T Load<T>(string name);
		void Save();
	}
}