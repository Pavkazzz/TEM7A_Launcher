﻿namespace Launcher.Module.EmergencyCard
{
    public class EmergencyCardFileClass
    {
        public EmergencyCardFileClass(string _nameCard, string _conditionalNumber, string _shippingName,
            string _classificationNumber, string _pathToFile)
        {
            Name_Card = _nameCard;
            Conditionalnumber = _conditionalNumber;
            ShippingName = _shippingName;
            ClassificationNumber = _classificationNumber;
            PathToFile = _pathToFile;
        }

        public string Name_Card { get; set; }
        public string Conditionalnumber { get; set; }
        public string ShippingName { get; set; }
        public string ClassificationNumber { get; set; }
        public string PathToFile { get; private set; }
    }
}