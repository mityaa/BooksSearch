namespace DataAccessLayer.Configuration
{
    public class ConfigurationValue
    {
        public ConfigurationValue(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }

        public string Value { get; }
        public override string ToString()
        {
            return string.Format("Name :{0} Value:{1}", Name, Value);
        }
    }
}
