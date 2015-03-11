using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Module.Document.ViewModels;

namespace Launcher.Module.Document
{
    internal class DocAbout : IModuleName
    {
        private List<About> _category = new List<About>();

        public DocAbout()
        {
            Name = @"Модуль нормативные документы";
            Description = @"Модуль «Нормативные документы» предназначен для предоставления в интерактивном виде межгосударственных, национальных и отраслевых стандартов,нормативно технической документации, определяющих требования к техническим системам и его компонентам.";
            ViewModel = typeof (MainDocViewModel);
            DbPath = "../../../../Launcher.Module.Document/document.sqlite";

            Category.Add(new About("qwe"));
            Category.Add(new About("asd"));
            Category.Add(new About("zcx"));
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Type ViewModel { get; set; }
        public string DbPath { get; set; }

        public List<About> Category
        {
            get { return _category; }
            set
            {
                _category = value;
            }
        }


        public bool PrimaryCheck()
        {
            return DocCheck.DocumentCheck();
        }


    }


    class About1 : IModuleName
    {

        public About1()
        {
            Name = @"Руководство по эксплуатации";
            Description = @"Модуль «РУКОВОДСТВО ПО ЭКСПЛУАТАЦИИ» предоставляет в интерактивном виде техническое описание конструкции, узлов и деталей локомотива, технические характеристики и показатели, правила эксплуатации, технического обслуживания, хранения и утилизации локомотива и его компонентов ";
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
            Name = @"Каталог деталей";
            Description = @"Модуль «КАТАЛОГ ДЕТАЛЕЙ» предназначен для предоставления в интерактивном виде справочной и иллюстрационной информации по деталям, сборочным единицам, комплексам и комплектам, входящим в состав локомотива ";
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
            Name = @"Приемка локомотива";
            Description = @"Модуль «ПРИЕМКА ЛОКОМОТИВА» предназначен для проведения приемки и сдачи локомотива, проведения технического обслуживания ТО-1, контроля над последовательностью и выполнением регламентных работ, формирования электронных отчетов по выполнению работ";
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
            Name = @"Аварийные карточки";
            Description = @"Модуль «Аварийные карточки» предоставляет в интерактивном виде графическое изображение возможных неисправностей локомотива и порядок действий локомотивной бригады для устранения причин, вызвавших аварию";
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
            Name = @"Тяговые расчёты";
            Description = @"Модуль «ТЯГОВЫЕ РАСЧЕТЫ» обеспечивает выполнение тяговых расчетов локомотива в соответствии с «Правилами тяговых расчетов для поездной работы» и представление результатов расчетов в графическом и табличном видах";
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

