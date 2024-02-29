using System.Text;

namespace GarageLogic.Manager
{
    public class Owner
    {
        public string Name { private get; set; }
        public string Phone {  private get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Vehicle's owner: {Name}");
            stringBuilder.AppendLine($"Vehicle's owner phone number: {Phone}");

            return stringBuilder.ToString();
        }
    }
}