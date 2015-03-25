using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Media;
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
            Coloring = Colors.LightGray;
            PositionNumber = 0;
            Name = @"Модуль нормативные документы";
            Description = @"Модуль «Нормативные документы» предназначен для предоставления в интерактивном виде межгосударственных, национальных и отраслевых стандартов, нормативно технической документации, определяющих требования к сложным техническим системам";
            ViewModel = typeof (MainDocViewModel);
            DbPath = "../../../../Launcher.Module.Document/document.sqlite";

            Category.Add(new About("qwe"));
            Category.Add(new About("asd"));
            Category.Add(new About("zcx"));
        }
        public Color Coloring { get; set; }
        public int PositionNumber { get; set; }
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
            Coloring = (Color)Colors.White;
            PositionNumber = 3;
            Name = @"Руководство по эксплуатации";
            Description = @"Модуль «РУКОВОДСТВО ПО ЭКСПЛУАТАЦИИ» предназначен для предоставления в интерактивном виде технического описания конструкций, узлов и деталей сложных технических систем, а также технические характеристики, правила эксплуатации, технического обслуживания, хранения и утилизации сложных технических систем и их компонентов ";
            ViewModel = typeof (DevelopedModuleViewModel);
            DbPath = "../../../../Launcher.Module.Document/document.sqlite";
        }
        public Color Coloring { get ; set; }
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

    class About2 : IModuleName
    {

        public About2()
        {
            Coloring = (Color)Colors.White;
            PositionNumber = 4;
            Name = @"Каталог деталей";
            Description = @"Модуль «КАТАЛОГ ДЕТАЛЕЙ» предназначен для предоставления в интерактивном виде справочной и иллюстрационной информации по деталям, сборочным единицам, комплексам и комплектам, входящим в состав сложных технических систем ";
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

    class About3 : IModuleName
    {

        public About3()
        {
            Coloring = (Color)Colors.White;
            PositionNumber = 5;
            Name = @"Расчёт характеристик электрического тормоза";
            Description = @"Модуль «РАСЧЕТ ХАРАКТЕРИСТИК ЭЛЕКТРИЧЕСКОГО ТОРМОЗА» предназначен для расчета электромеханических характеристик локомотива с электродвигателями постоянного тока с последовательным возбуждением при электрическом торможении";
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

   

    class About4 : IModuleName
    {

        public About4()
        {
            Coloring = (Color)Colors.White;
            PositionNumber = 6;
            Name = @"Тяговые расчёты";
            Description = @"Модуль «ТЯГОВЫЕ РАСЧЕТЫ» предназначен для выполнения тяговых расчетов в соответствии с «Правилами тяговых расчетов для поездной работы» и представление результатов расчетов в графическом и табличном видах";
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
    class About5 : IModuleName
    {

        public About5()
        {
            Coloring = (Color)Colors.White;
            PositionNumber = 7;
            Name = @"Заказ комплектующих";
            Description = @"Модуль «ЗАКАЗ  КОМПЛЕКТУЮЩИХ» предназначен для выбора и формирования заказа на запасные части сложных технических систем, а также формирования интерактивных электронных отчетов по выполненным заказам";
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
    class About6 : IModuleName
    {

        public About6()
        {
            Coloring = (Color)Colors.White;
            PositionNumber = 8;
            Name = @"Мониторинг показателей";
            Description = @"Модуль «МОНИТОРИНГ ПОКАЗАТЕЛЕЙ» предназначен для ввода и обработки статистической информации, расчета технико-экономических и эксплуатационных показателей сложных технических систем ";
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
    class About8 : IModuleName
    {

        public About8()
        {
            Coloring = (Color)Colors.White;
            PositionNumber = 9;
            Name = @"Расчет стоимости жизненного цикла ";
            Description = @"Модуль «РАСЧЕТ СТОИМОСТИ ЖИЗНЕННОГО ЦИКЛА» предназначен для расчёта затрат единовременного (инвестиции) и текущего характера (эксплуатационные расходы) за срок службы (срок полезного использования) сложных технических систем";
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
    class About9 : IModuleName
    {

        public About9()
        {
            Coloring = (Color)Colors.White;
            PositionNumber = 10;
            Name = @"Устранение неисправностей";
            Description = @"Модуль «УСТРАНЕНИЕ НЕИСПРАВНОСТЕЙ» обеспечивает в интерактивном виде графическое изображение возможных неисправностей локомотива и порядок действий локомотивной бригады для устранения причин, вызвавших аварию";
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
    class About10 : IModuleName
    {

        public About10()
        {
            Coloring = (Color)Colors.White;
            PositionNumber = 11;
            Name = @"Система диагностики";
            Description = @"Модуль «СИСТЕМА ДИАГНОСТИКИ» содержит описание диагностических сообщений системы управления и порядок действия персонала при выдаче соответствующих диагностических сообщений";
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
    class About11 : IModuleName
    {

        public About11()
        {
            Coloring = Colors.White;
            PositionNumber = 12;
            Name = @"Сервис и техническое обслуживание";
            Description = @"Модуль «СЕРВИС И ТЕХНИЧЕСКОЕ ОБСЛУЖИВАНИЕ» предоставляет в интерактивном виде перечень и порядок проведения работ при выполнении плановых и неплановых видах ремонта сложных технических систем и пошаговый контроль выполнения работ";
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
    class About12 : IModuleName
    {

        public About12()
        {
            Coloring = Colors.White;
            PositionNumber = 13;
            Name = @"Расчет тормозного нажатия";
            Description = @"Модуль «РАСЧЕТ ТОРМОЗНОГО НАЖАТИЯ» предназначен для проведения тормозных расчётов в поездной работе";
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
    class About13 : IModuleName
    {

        public About13()
        {
            Coloring = Colors.White;
            PositionNumber = 14;
            Name = @"Порядок опробования пневматических тормозов";
            Description = @"Модуль «ПОРЯДОК ОПРОБОВАНИЯ ПНЕВМАТИЧЕСКИХ ТОРМОЗОВ» содержит описание последовательности опробования тормозов (полного и сокращенного), пошаговый  контроль последовательности выполнения опробования тормозов";
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
    class About14 : IModuleName
    {

        public About14()
        {
            Coloring = Colors.White;
            PositionNumber = 15;
            Name = @"Электронный маршрут машиниста";
            Description = @"Модуль «ЭЛЕКТРОННЫЙ МАРШРУТ МАШИНИСТА» обеспечивает в интерактивном виде ввод исходной информации, учет рабочего времени машиниста за день, неделю, месяц, год, все время работы, расчет показателей энергоэффективности, количество затраченной электроэнергии за поездку, количество рекуперируемой энергии (для электровоза) и вывод результатов расчетов в табличном и графическом видах";
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
    class About15 : IModuleName
    {

        public About15()
        {
            Coloring = Colors.White;
            PositionNumber = 16;
            Name = @"Правила заполнения поездных документов ";
            Description = @"Модуль «ПРАВИЛА ЗАПОЛНЕНИЯ ПОЕЗДНЫХ ДОКУМЕНТОВ» обеспечивает в интерактивном виде описание и правила заполнения поездных документов  (маршрута машиниста, справок, журналов формы ТУ-152)";
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
    class About16 : IModuleName
    {

        public About16()
        {
            Coloring = Colors.White;
            PositionNumber = 17;
            Name = @"План станций";
            Description = @"Модуль «ПЛАН СТАНЦИЙ» предназначен для информирования локомотивных бригад о путевом развитии станции, расположении стрелочных переводов, светофоров, скоростям движения по главным и боковым путям станций";
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
    class About17 : IModuleName
    {

        public About17()
        {
            Coloring = Colors.White;
            PositionNumber = 18;
            Name = @"Продольный профиль участка";
            Description = @"Модуль «ПРОДОЛЬНЫЙ ПРОФИЛЬ УЧАСТКА» обеспечивает локомотивную бригаду информацией о руководящих подъемах и спусках, радиусах кривых, ограничениях скоростей на участках движения поездов. Содержит режимные карты управления локомотивом .";
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
    class About18 : IModuleName
    {

        public About18()
        {
            Coloring = (Color)Colors.White;
            PositionNumber = 19;
            Name = @"Расписание движения поездов";
            Description = @"Модуль «РАСПИСАНИЕ ДВИЖЕНИЯ ПОЕЗДОВ» содержит полную информацию о графике движения поезда и помогает машинисту определять режимы движения поезда ";
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
    class About19 : IModuleName
    {

        public About19()
        {
            Coloring = Colors.White;
            PositionNumber = 20;
            Name = @"Аварийная остановка";
            Description = @"Модуль «АВАРИЙНАЯ ОСТАНОВКА» указывает порядок действий локомотивной бригады при аварийной остановке поезда (локомотива)";
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

