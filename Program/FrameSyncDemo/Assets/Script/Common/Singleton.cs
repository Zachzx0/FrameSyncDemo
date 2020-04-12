namespace FSD.Common
{
	public abstract class Singleton<T> where T : new()
	{

		static T _instance = default(T);
		public static T GetInstance()
		{
			if (_instance == null)
			{
				_instance = new T();
			}
			return _instance;
		}

		public abstract void Initialize();
		public abstract void UnInitialize();
	}

}