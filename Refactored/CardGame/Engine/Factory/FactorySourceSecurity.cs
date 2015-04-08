namespace Engine.Factory
{
    using System.IO;
    using System;
    using System.Reflection;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;

    class FactorySourceSecurity
    {
        private const string sourcePath = @"C:\Users\Pc\Desktop\refactor\CardGame\CardInfo\CardInfo.txt";
        private const string key = "telerigAkademi";

        private string unsecured;
        public SerializableString SecuredContent { get; private set; }

        public FactorySourceSecurity()
        {
            this.SecuredContent = new SerializableString();
            this.unsecured = File.ReadAllText(sourcePath);
            this.Serialize();
        }

        private void Serialize()
        {
            var stream = new FileStream(@"C:\Users\Pc\Desktop\refactor\CardGame\CardInfo\CardInfo.cinf", FileMode.Open);
            var formatter = new BinaryFormatter();

            formatter.Serialize(stream, this.Encrypt(this.unsecured));
            stream.Close();
        }

        public string Normalize()
        {
            var stream = new FileStream(@"C:\Users\Pc\Desktop\refactor\CardGame\CardInfo\CardInfo.cinf", FileMode.Open);
            var formatter = new BinaryFormatter();

            stream.Position = 0;

            string deserialized = (string)formatter.Deserialize(stream);
            stream.Close();
            return this.Encrypt(deserialized);
        }

        private string Encrypt(string str)
        {
            var encrypted = new StringBuilder(str);

            for (int i = 0; i < this.unsecured.Length; i++)
            {
                encrypted[i] ^= FactorySourceSecurity.key[i % FactorySourceSecurity.key.Length];
            }

            return encrypted.ToString();
        }
    }

    [Serializable]
    public class SerializableString
    {
        public string Content { get; set; }

        public SerializableString()
        { }
    }
}
