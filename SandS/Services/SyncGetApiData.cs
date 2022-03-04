﻿using SandS.Model;
using SandS.Resource;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandS.Services
{
    internal static class SyncGetApiData
    {
        public static Group GetGroupByName(string name) => 
            new SyncApiData<Group>($"{GloabalValues.ApiBaseUrl}group/name", new Group { Name = name}).Post();
        public static Discipline GetDisciplineByName(string name) => 
            new SyncApiData<Discipline>($"{GloabalValues.ApiBaseUrl}discipline/name", new Discipline { Name = name}).Post();
        public static Teacher GetTeacherByName(string name) => 
            new SyncApiData<Teacher>($"{GloabalValues.ApiBaseUrl}teacher/name", new Teacher { Name = name }).Post();
        public static WeekDay GetWeekDayByName(string name) => 
            new SyncApiData<WeekDay>($"{GloabalValues.ApiBaseUrl}weekday/name", new WeekDay { Name = name }).Post();
        public static Lesson GetLessonByName(string name) => 
            new SyncApiData<Lesson>($"{GloabalValues.ApiBaseUrl}lesson/name", new Lesson { LessonNumber = name }).Post();
        public static Office GetOfficeByName(string name) => 
            new SyncApiData<Office>($"{GloabalValues.ApiBaseUrl}office/name", new Office { OfficeNumber = name }).Post();
        public static Department GetDepartmentByName(string name) =>
            new SyncApiData<Department>($"{GloabalValues.ApiBaseUrl}department", new Department { Name = name }).Post();
        public static ObservableCollection<TTable> GetTTable() =>
            new SyncApiData<ObservableCollection<TTable>>($"{GloabalValues.ApiBaseUrl}ttable/fullinfo").Get();
        public static ObservableCollection<SubTTable> GetSubTTable() =>
            new SyncApiData<ObservableCollection<SubTTable>>($"{GloabalValues.ApiBaseUrl}subttable/fullinfo").Get();
        public static ObservableCollection<Office> GetOffice() =>
            new SyncApiData<ObservableCollection<Office>>($"{GloabalValues.ApiBaseUrl}office").Get();
        public static ObservableCollection<DisciplineGroupTeacher> GetDgtForGroup(int id) =>
            new SyncApiData<ObservableCollection<DisciplineGroupTeacher>>($"{GloabalValues.ApiBaseUrl}dgt/getforgroup/{id}").Get();
    }
}