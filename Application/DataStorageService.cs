namespace Application
{
    public class DataStorageService
    {
        public static Dictionary<string, string> _keyValuePair;

        private DataStorageService()
        {
            if (_keyValuePair != null)
            {
                throw new Exception("Use GetInstance() method!");
            }

            _keyValuePair = new Dictionary<string, string>();
        }

        public static Dictionary<string, string> GetInstance()
        {
            if (_keyValuePair == null)
            {
                _keyValuePair = new Dictionary<string, string>();
            }

            return _keyValuePair;
        }
    }
}
