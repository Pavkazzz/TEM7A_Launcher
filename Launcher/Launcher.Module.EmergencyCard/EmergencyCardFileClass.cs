namespace Launcher.Module.EmergencyCard
{
    public class EmergencyCardFileClass
    {
        public EmergencyCardFileClass(string nameCard, string conditionalNumber, string shippingName,
            string classificationNumber, string pathToFile)
        {
            NameCard = nameCard;
            Conditionalnumber = conditionalNumber;
            ShippingName = shippingName;
            ClassificationNumber = classificationNumber;
            PathToFile = pathToFile;
        }

        public string NameCard { get; set; }
        public string Conditionalnumber { get; set; }
        public string ShippingName { get; set; }
        public string ClassificationNumber { get; set; }
        public string PathToFile { get; private set; }
    }
}