namespace Final_Task.Profile
{
    public class PlayerProfile
    {
        public string Name { get; set; }

        public int Bank { get; set; }

        public PlayerProfile(string name)
        {
            Name = name;
            Bank = 100;
        }

        public override string ToString()
        {
            return $"{Name}|{Bank}";
        }

        public static PlayerProfile FromString(string data)
        {
            var split = data.Split('|');

            return new PlayerProfile(split[0])
            {
                Bank = int.Parse(split[1])
            };
        }
    }
}