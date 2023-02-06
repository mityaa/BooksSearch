namespace Configuration
{
    public class ConfigurationValue
    {
        public ConfigurationValue(string name, string value)
        {
            Name = name;
            Value = value;
        }

        private string Name { get; }

        public string Value { get; }
        public override string ToString()
        {
            return $"Name :{Name} Value:{Value}";
        }
    }
}
