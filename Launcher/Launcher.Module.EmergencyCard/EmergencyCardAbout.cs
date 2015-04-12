using System;
using System.Collections.Generic;
using System.Windows.Media;
using Launcher.Core;
using Launcher.Module.EmergencyCard.ViewModels;

namespace Launcher.Module.EmergencyCard
{
    public class EmergencyCardAbout : IModuleName
    {
        public EmergencyCardAbout()
        {
            Coloring = Colors.LightGray;
            PositionNumber = 1;
            Name = @"Аварийные карточки";
            Description =
                @"Модуль «Аварийные карточки» предоставляет в интерактивном виде графическое изображение возможных неисправностей локомотива и порядок действий локомотивной бригады для устранения причин,вызвавших аварию.";
            ViewModel = typeof (MainEmergencyCardViewModel);
            DbPath = "../../../../Launcher.Module.EmergencyCard/EmergencyCard.sqlite";
        }

        public Color Coloring { get; set; }
        public int PositionNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Type ViewModel { get; set; }
        public string DbPath { get; set; }

        public bool PrimaryCheck()
        {
            throw new NotImplementedException();
        }
    }
}