using System;
using System.Collections.Generic;
using System.Windows.Media;
using Launcher.Core;
using Launcher.Module.Document.ViewModels;

namespace Launcher.Module.Document
{
    class About10 : IModuleName
    {

        public About10()
        {
            Coloring = (Color)Colors.White;
            PositionNumber = 11;
            Name = @"������� �����������";
            Description = @"������ �������� ����������Ȼ �������� �������� ��������������� ��������� ������� ���������� � ������� �������� ��������� ��� ������ ��������������� ��������������� ���������";
            ViewModel = typeof(DevelopedModuleViewModel);
            DbPath = "../../../../Launcher.Module.Document/document.sqlite";
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