﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Launcher.Core;
using Launcher.Module.EmergencyCard.ViewModels;

namespace Launcher.Module.EmergencyCard
{
    internal class EmergencyCardAbout : IModuleName
    {
        public EmergencyCardAbout()
        {
           Coloring = Colors.LightGray;
            PositionNumber = 1;
            Name = @"Аварийные карточки";
            Description =
                @"Модуль «Аварийные карточки» предназначен для ...";
            ViewModel = typeof (MainEmergencyCardViewModel);
            //TODO BD
            DbPath = "../../../../Launcher.Module.EmergencyCard/EmergencyCard.sqlite";
        }
        public Color Coloring { get; set; }
        public int PositionNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Type ViewModel { get; set; }
        public string DbPath { get; set; }
        public List<About> Category { get; set; }

        public bool PrimaryCheck()
        {
            throw new NotImplementedException();
        }
    }
}

