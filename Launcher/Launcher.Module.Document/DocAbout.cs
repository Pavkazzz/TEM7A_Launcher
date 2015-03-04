using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Launcher.Core;
using Launcher.Module.Document.ViewModels;

namespace Launcher.Module.Document
{
    internal class DocAbout : IModuleName
    {
        public DocAbout()
        {
            Name = @"Модуль норматив. документы";
            Description = @"Супер модуль";
            ViewModel = typeof (MainDocViewModel);
            DbPath = "../../../../Launcher.Module.Document/document.sqlite";
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Type ViewModel { get; set; }
        public string DbPath { get; set; }

        public List<About> Category { get; set; }


        public bool PrimaryCheck()
        {

            return DocCheck.DocumentCheck();
        }


    }


    class About1 : IModuleName
    {

        public About1()
        {
            Name = @"Модуль 1";
            Description = @"Описание модуля";
            ViewModel = typeof (MainDocViewModel);
            DbPath = "../../../../Launcher.Module.Document/document.sqlite";
        }


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

    class About2 : IModuleName
    {

        public About2()
        {
            Name = @"Модуль 2";
            Description = @"Описание модуля";
            ViewModel = typeof(MainDocViewModel);
            DbPath = "../../../../Launcher.Module.Document/document.sqlite";
        }


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

    class About3 : IModuleName
    {

        public About3()
        {
            Name = @"Модуль 3";
            Description = @"Описание модуля";
            ViewModel = typeof(MainDocViewModel);
            DbPath = "../../../../Launcher.Module.Document/document.sqlite";
        }


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

    class About4 : IModuleName
    {

        public About4()
        {
            Name = @"Модуль 4";
            Description = @"Описание модуля";
            ViewModel = typeof(MainDocViewModel);
            DbPath = "../../../../Launcher.Module.Document/document.sqlite";
        }


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

    class About5 : IModuleName
    {

        public About5()
        {
            Name = @"Модуль 5";
            Description = @"Описание модуля";
            ViewModel = typeof(MainDocViewModel);
            DbPath = "../../../../Launcher.Module.Document/document.sqlite";
        }


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

