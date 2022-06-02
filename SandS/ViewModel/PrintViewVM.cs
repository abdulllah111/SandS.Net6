using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClosedXML.Excel;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using SandS.Model;
using SandS.Services;
using System.Reflection;
using Microsoft.Office.Interop.Word;
using Task = System.Threading.Tasks.Task;

namespace SandS.ViewModel
{
    internal class PrintViewVM : ViewModelBase
    {
        public ObservableCollection<string> PrintTypes { get; set; }
        public string SelectedPrintType { get; set; }
        public DateTime SelectedDate { get; set; }
        public bool DateIsEnabled { get; set; }
        public bool DepartmentsIsEnabled { get; set; }
        public bool GroupsIsEnabled { get; set; }
        public bool PrintBtnIsEnabled { get; set; }
        public bool Loading { get; set; }
        public TaskCompletion<ObservableCollection<Department>> Departments { get; set; }
        public TaskCompletion<ObservableCollection<Group>> Groups { get; set; }

        public Department SelectedDepartment { get; set; }
        public Group SelectedGroup { get; set; }

        public ObservableCollection<TTable> FridayList { get; set; }
        public ObservableCollection<TTable> MondayList { get; set; }
        public ObservableCollection<TTable> SaturdayList { get; set; }
        public ObservableCollection<TTable> ThursdayList { get; set; }
        public ObservableCollection<TTable> TuesdayList { get; set; }
        public ObservableCollection<TTable> WednesdayList { get; set; }
        public ObservableCollection<SubTTable[]> SubTtable { get; set; }
        public PrintViewVM()
        {

        }

        public DelegateCommand LoadedCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Loading = false;
                    PrintTypes = new ObservableCollection<string> { "Расписание", "Замены" };
                    Departments = AsyncGetApiData.GetDepartments();
                    DateIsEnabled = false;
                    DepartmentsIsEnabled = false;
                    GroupsIsEnabled = false;
                    PrintBtnIsEnabled = false;
                });
            }
        }
        public DelegateCommand PrintTypeSelectedChangedCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (SelectedPrintType == "Расписание")
                    {
                        DepartmentsIsEnabled = true;
                        DateIsEnabled = false;
                        return;
                    }
                    DepartmentsIsEnabled = true;
                    DateIsEnabled = true;
                });
            }
        }

        
        public DelegateCommand DepartmentsSelectedChangedCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (SelectedDepartment != null)
                    {
                        Groups = AsyncGetApiData.GroupsByDepartment(SelectedDepartment.IdDepartment);
                        GroupsIsEnabled = true;
                    }
                    else
                    {
                        GroupsIsEnabled = false;
                    }
                });
            }
        }
        public DelegateCommand GroupsSelectedChangedCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (SelectedPrintType == "Расписание" || SelectedGroup != null)
                    {
                        PrintBtnIsEnabled = true;
                    }
                    else if(SelectedPrintType == "Замены" || SelectedGroup != null)
                    {
                        SubTtable = SyncGetApiData.GetSubTTableByGroupAndDate(SelectedGroup!.IdGroup, SelectedDate.DateStr());
                        if (SubTtable != null)
                        {
                            PrintBtnIsEnabled= true;
                        }
                    }
                });
            }
        }

        private void ContecntForTable(Table table, ObservableCollection<TTable> ttables)
        {
            table.Borders.Enable = 1;
            foreach (Row row in table.Rows)
            {
                foreach (Cell cell in row.Cells)
                    //Заголовок таблицы
                    if (cell.RowIndex == 1)
                    {
                        if (cell.ColumnIndex == 1)
                        {
                            cell.Range.Text = "Пара";
                            cell.Range.Font.Bold = 1;
                            //Задаем шрифт и размер текста
                            cell.Range.Font.Name = "verdana";
                            cell.Range.Font.Size = 10;
                            cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                            //Выравнивание текста в заголовках столбцов по центру
                            cell.VerticalAlignment =
                                WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment =
                                WdParagraphAlignment.wdAlignParagraphCenter;
                        }
                        else if (cell.ColumnIndex == 2)
                        {
                            cell.Range.Text = "Предмет";
                            cell.Range.Font.Bold = 1;
                            //Задаем шрифт и размер текста
                            cell.Range.Font.Name = "verdana";
                            cell.Range.Font.Size = 10;
                            cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                            //Выравнивание текста в заголовках столбцов по центру
                            cell.VerticalAlignment =
                                WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment =
                                WdParagraphAlignment.wdAlignParagraphCenter;
                        }
                        else if (cell.ColumnIndex == 3)
                        {
                            cell.Range.Text = "Преподаватель";
                            cell.Range.Font.Bold = 1;
                            //Задаем шрифт и размер текста
                            cell.Range.Font.Name = "verdana";
                            cell.Range.Font.Size = 10;
                            cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                            //Выравнивание текста в заголовках столбцов по центру
                            cell.VerticalAlignment =
                                WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment =
                                WdParagraphAlignment.wdAlignParagraphCenter;
                        }
                        else if (cell.ColumnIndex == 4)
                        {
                            cell.Range.Text = "Кабинет";
                            cell.Range.Font.Bold = 1;
                            //Задаем шрифт и размер текста
                            cell.Range.Font.Name = "verdana";
                            cell.Range.Font.Size = 10;
                            cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                            //Выравнивание текста в заголовках столбцов по центру
                            cell.VerticalAlignment =
                                WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment =
                                WdParagraphAlignment.wdAlignParagraphCenter;
                        }
                    }

                var i = 2;
                foreach (var item in ttables)
                {
                    table.Cell(i, 1).Range.Text = item.Lesson.LessonNumber;
                    table.Cell(i, 2).Range.Text = item.GetDisciplineGroupTeacher!.Discipline.Name;
                    table.Cell(i, 3).Range.Text = item.GetDisciplineGroupTeacher!.Teacher != null
                        ? item.GetDisciplineGroupTeacher.Teacher.Name
                        : "";
                    table.Cell(i, 4).Range.Text = item.Office != null ? item.Office.OfficeNumber : "";
                    i++;
                }
            }
        }

        public DelegateCommand PrintButtonCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    DepartmentsIsEnabled = false;
                    GroupsIsEnabled = false;
                    PrintBtnIsEnabled = false;
                    Loading = true;
                    if (SelectedPrintType == "Расписание")
                    {
                        await System.Threading.Tasks.Task.Run(PrintTtable).ContinueWith(_ => { Loading = false; PrintBtnIsEnabled = true; GroupsIsEnabled = true; DepartmentsIsEnabled = true; }, TaskScheduler.FromCurrentSynchronizationContext());

                    }
                });
            }
        }

        private Task<object?>? PrintTtable()
        {
            MondayList = SyncGetApiData.GetTtableByGroupAndWeekDay(SelectedGroup.IdGroup, 1);
            TuesdayList = SyncGetApiData.GetTtableByGroupAndWeekDay(SelectedGroup.IdGroup, 2);
            WednesdayList = SyncGetApiData.GetTtableByGroupAndWeekDay(SelectedGroup.IdGroup, 3);
            ThursdayList = SyncGetApiData.GetTtableByGroupAndWeekDay(SelectedGroup.IdGroup, 4);
            FridayList = SyncGetApiData.GetTtableByGroupAndWeekDay(SelectedGroup.IdGroup, 5);
            SaturdayList = SyncGetApiData.GetTtableByGroupAndWeekDay(SelectedGroup.IdGroup, 6);

            var winword = new Application();

            winword.Visible = false;

            //Заголовок документа
            winword.Documents.Application.Caption = "Расписание";

            object missing = Missing.Value;

            //Создание нового документа
            var document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

            //Добавление верхнего колонтитула
            foreach (Section section in document.Sections)
            {
                var headerRange = section.Headers[
                    WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                headerRange.Fields.Add(
                    headerRange, WdFieldType.wdFieldPage);
                headerRange.ParagraphFormat.Alignment =
                    WdParagraphAlignment.wdAlignParagraphCenter;
                headerRange.Font.ColorIndex =
                    WdColorIndex.wdBlue;
                headerRange.Font.Size = 10;
                headerRange.Text = "Расписание для группы" + Environment.NewLine +
                                   SelectedGroup.Name;
            }

            //Добавление нижнего колонтитула
            foreach (Section wordSection in document.Sections)
            {
                var footerRange = wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                //Установка цвета текста
                footerRange.Font.ColorIndex = WdColorIndex.wdDarkRed;
                //Размер
                footerRange.Font.Size = 10;
                //Установка расположения по центру
                footerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                //Установка текста для вывода в нижнем колонтитуле
                footerRange.Text = "Расписание для группы" + Environment.NewLine +
                                   SelectedGroup.Name;
            }

            //Понедельник
            var para1 = document.Content.Paragraphs.Add(ref missing);
            object styleHeading1 = "Заголовок 1";
            para1.Range.set_Style(styleHeading1);
            para1.Range.Text = "Понедельник";
            para1.Range.InsertParagraphAfter();

            //Создание таблицы
            var MondayTable = document.Tables.Add(para1.Range, MondayList.Count + 1, 4, ref missing, ref missing);

            //Вторник
            para1 = document.Content.Paragraphs.Add(ref missing);
            styleHeading1 = "Заголовок 1";
            para1.Range.set_Style(styleHeading1);
            para1.Range.Text = "Вторник";
            para1.Range.InsertParagraphAfter();

            var TuesdayTable = document.Tables.Add(para1.Range, TuesdayList.Count + 1, 4, ref missing, ref missing);

            //Среда
            para1 = document.Content.Paragraphs.Add(ref missing);
            styleHeading1 = "Заголовок 1";
            para1.Range.set_Style(styleHeading1);
            para1.Range.Text = "Среда";
            para1.Range.InsertParagraphAfter();


            var WednesdayTable =
                document.Tables.Add(para1.Range, WednesdayList.Count + 1, 4, ref missing, ref missing);

            //Четверг
            para1 = document.Content.Paragraphs.Add(ref missing);
            styleHeading1 = "Заголовок 1";
            para1.Range.set_Style(styleHeading1);
            para1.Range.Text = "Четверг";
            para1.Range.InsertParagraphAfter();

            var ThursdayTable =
                document.Tables.Add(para1.Range, ThursdayList.Count + 1, 4, ref missing, ref missing);

            //Пятница
            para1 = document.Content.Paragraphs.Add(ref missing);
            styleHeading1 = "Заголовок 1";
            para1.Range.set_Style(styleHeading1);
            para1.Range.Text = "Пятница";
            para1.Range.InsertParagraphAfter();

            var FridayTable = document.Tables.Add(para1.Range, FridayList.Count + 1, 4, ref missing, ref missing);

            //Суббота
            para1 = document.Content.Paragraphs.Add(ref missing);
            styleHeading1 = "Заголовок 1";
            para1.Range.set_Style(styleHeading1);
            para1.Range.Text = "Суббота";
            para1.Range.InsertParagraphAfter();

            var SaturdayTable =
                document.Tables.Add(para1.Range, SaturdayList.Count + 1, 4, ref missing, ref missing);

            ContecntForTable(MondayTable, MondayList);
            ContecntForTable(TuesdayTable, TuesdayList);
            ContecntForTable(WednesdayTable, WednesdayList);
            ContecntForTable(ThursdayTable, ThursdayList);
            ContecntForTable(FridayTable, FridayList);
            ContecntForTable(SaturdayTable, SaturdayList);

            winword.Visible = true;
            return null;
        }

        private void SetFont(Cell cell)
        {
            cell.Range.Font.Bold = 1;
            //Задаем шрифт и размер текста
            cell.Range.Font.Name = "verdana";
            cell.Range.Font.Size = 10;
            cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
            //Выравнивание текста в заголовках столбцов по центру
            cell.VerticalAlignment =
                WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
        }

        //private void PrintSubTTableClick(object sender, RoutedEventArgs e)
        //{
        //    SubTTables = AsyncGetApiData.GetSubTTableByGroupAndDate(SelectedGroup.IdGroup, SelectedDate.DateStr());



        //        while (dbReader.Read())
        //            SubTTables.Add(new SubTTable
        //            {
        //                IdSubTTable = (int)dbReader[0],
        //                IdWeekDay = (int)dbReader[1],
        //                IdLesson = (int)dbReader[2],
        //                IdOffice = dbReader[3] != DBNull.Value ? (int)dbReader[3] : 0,
        //                IdDisciplineGroupTeacher = (int)dbReader[4],
        //                Date = (DateTime)dbReader[5]
        //            });
        //        var winword = new Application();

        //        winword.Visible = false;

        //        //Заголовок документа
        //        winword.Documents.Application.Caption = "Замены";

        //        object missing = Missing.Value;

        //        //Создание нового документа
        //        var document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

        //        //Добавление верхнего колонтитула
        //        foreach (Section section in document.Sections)
        //        {
        //            var headerRange = section.Headers[
        //                WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
        //            headerRange.Fields.Add(
        //                headerRange, WdFieldType.wdFieldPage);
        //            headerRange.ParagraphFormat.Alignment =
        //                WdParagraphAlignment.wdAlignParagraphCenter;
        //            headerRange.Font.ColorIndex =
        //                WdColorIndex.wdBlue;
        //            headerRange.Font.Size = 10;
        //            headerRange.Text = "Замены на " + Environment.NewLine +
        //                               DateBoxForPrint.SelectedDate.Value.DateStr() +
        //                               $" ({SubTTables.Last().WeekDay.Name})";
        //        }

        //        //Добавление нижнего колонтитула
        //        foreach (Section wordSection in document.Sections)
        //        {
        //            var footerRange = wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
        //            //Установка цвета текста
        //            footerRange.Font.ColorIndex = WdColorIndex.wdDarkRed;
        //            //Размер
        //            footerRange.Font.Size = 10;
        //            //Установка расположения по центру
        //            footerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
        //            //Установка текста для вывода в нижнем колонтитуле
        //            footerRange.Text = "Замены на " + Environment.NewLine +
        //                               DateBoxForPrint.SelectedDate.Value.DateStr() +
        //                               $" ({SubTTables.Last().WeekDay.Name})";
        //        }

        //        var para1 = document.Content.Paragraphs.Add(ref missing);
        //        object styleHeading1 = "Заголовок 1";
        //        para1.Range.set_Style(styleHeading1);
        //        para1.Range.Text = "Замены";
        //        para1.Range.InsertParagraphAfter();

        //        //Создание таблицы
        //        var SubTimeTable = document.Tables.Add(para1.Range, SubTTables.Count + 1, 5, ref missing, ref missing);

        //        SubTimeTable.Cell(1, 1).Range.Text = "Группа";
        //        SubTimeTable.Cell(1, 2).Range.Text = "Пара";
        //        SubTimeTable.Cell(1, 3).Range.Text = "Предмет";
        //        SubTimeTable.Cell(1, 4).Range.Text = "Преподаватель";
        //        SubTimeTable.Cell(1, 5).Range.Text = "Кабинет";
        //        SetFont(SubTimeTable.Cell(1, 1));
        //        SetFont(SubTimeTable.Cell(1, 2));
        //        SetFont(SubTimeTable.Cell(1, 3));
        //        SetFont(SubTimeTable.Cell(1, 4));
        //        SetFont(SubTimeTable.Cell(1, 5));
        //        SubTimeTable.Borders.Enable = 1;
        //        foreach (Row row in SubTimeTable.Rows)
        //            foreach (Cell cell in row.Cells)
        //            {
        //                var i = 2;
        //                foreach (var item in SubTTables)
        //                {
        //                    SubTimeTable.Cell(i, 1).Range.Text = item.GetDisciplineGroupTeacher().Result.Group.Name;
        //                    SubTimeTable.Cell(i, 2).Range.Text = item.Lesson.LessonNumber;
        //                    SubTimeTable.Cell(i, 4).Range.Text = item.GetDisciplineGroupTeacher().Result.Discipline.Name;
        //                    SubTimeTable.Cell(i, 3).Range.Text = item.GetDisciplineGroupTeacher().Result.Teacher.Name;
        //                    SubTimeTable.Cell(i, 5).Range.Text = item.Office.OfficeNumber;
        //                    i++;
        //                }
        //            }

        //        winword.Visible = true;
            
        //}

        //private void GroupComboboxForPrint_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (DepartmenBoxForPrint.SelectedValue != null && GroupComboboxForPrint.SelectedValue != null)
        //        PrintButton.IsEnabled = true;
        //    else
        //        PrintButton.IsEnabled = false;
        //}

        //private void DateBoxForPrint_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (DateBoxForPrint.SelectedDate != null)
        //        PrintButton.IsEnabled = true;
        //    else
        //        PrintButton.IsEnabled = false;
        //}
    }
}
