using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SandS.Model
{
    public class DataWorker
    {
        private static MySqlConnection conn =
            new MySqlConnection("server=localhost;user=root;database=timetable;password=root;");

        public static Teacher GetTeacher(int id)
        {
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand($"SELECT * FROM teacher WHERE idteacher = '{id}';", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    return new Teacher
                    {
                        IdTeacher = (int) dbReader[0],
                        Name = dbReader[1].ToString()
                    };
                return null;
            }
        }

        public static Teacher GetTeacher(string name)
        {
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand($"SELECT * FROM teacher WHERE name = '{name}';", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    return new Teacher
                    {
                        IdTeacher = (int) dbReader[0],
                        Name = dbReader[1].ToString()
                    };
                return null;
            }
        }

        public static Discipline GetDiscipline(int id)
        {
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand($"SELECT * FROM discipline WHERE iddiscipline = '{id}';", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    return new Discipline
                    {
                        IdDiscipline = (int) dbReader[0],
                        Name = dbReader[1].ToString()
                    };
                return null;
            }
        }

        public static Discipline GetDiscipline(string name)
        {
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand($"SELECT * FROM discipline WHERE discipline_name = '{name}';", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    return new Discipline
                    {
                        IdDiscipline = (int) dbReader[0],
                        Name = dbReader[1].ToString()
                    };
                return null;
            }
        }

        public static Group GetGroup(int id)
        {
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand($"SELECT * FROM `group` WHERE idgroup = '{id}';", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    return new Group
                    {
                        IdGroup = (int) dbReader[0],
                        Name = dbReader[1].ToString(),
                        IdDepartment = (int) dbReader[2]
                    };
                return null;
            }
        }

        public static Group GetGroup(string name)
        {
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand($"SELECT * FROM `group` WHERE group_name = '{name}';", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    return new Group
                    {
                        IdGroup = (int) dbReader[0],
                        Name = dbReader[1].ToString(),
                        IdDepartment = (int) dbReader[2]
                    };
                return null;
            }
        }

        public static WeekDay GetWeekDay(int id)
        {
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand($"SELECT * FROM `weekday` WHERE idweekday = '{id}';", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    return new WeekDay
                    {
                        IdWeekDay = (int) dbReader[0],
                        Name = dbReader[1].ToString()
                    };
                return null;
            }
        }

        public static WeekDay GetWeekDay(string name)
        {
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand($"SELECT * FROM `weekday` WHERE weekday_name = '{name}';", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    return new WeekDay
                    {
                        IdWeekDay = (int) dbReader[0],
                        Name = dbReader[1].ToString()
                    };
                return null;
            }
        }

        public static Lesson GetLesson(int id)
        {
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand($"SELECT * FROM lesson WHERE idlesson = '{id}';", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    return new Lesson
                    {
                        IdLesson = (int) dbReader[0],
                        LessonNumber = dbReader[1].ToString()
                    };
                return null;
            }
        }

        public static Lesson GetLesson(string number)
        {
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand($"SELECT * FROM lesson WHERE lesson_number = '{number}';", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    return new Lesson
                    {
                        IdLesson = (int) dbReader[0],
                        LessonNumber = dbReader[1].ToString()
                    };
                return null;
            }
        }

        public static Office GetOffice(int id)
        {
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand($"SELECT * FROM office WHERE idoffice = '{id}';", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    return new Office
                    {
                        IdOffice = (int) dbReader[0],
                        OfficeNumber = dbReader[1].ToString()
                    };
                return null;
            }
        }

        public static Office GetOffice(string number)
        {
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand($"SELECT * FROM office WHERE office_number = '{number}';", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    return new Office
                    {
                        IdOffice = (int) dbReader[0],
                        OfficeNumber = dbReader[1].ToString()
                    };
                return null;
            }
        }

        public static Department GetDepartment(int id)
        {
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand($"SELECT * FROM department WHERE iddepartment = '{id}';", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    return new Department
                    {
                        IdDepartment = (int) dbReader[0],
                        Name = dbReader[1].ToString()
                    };
                return null;
            }
        }

        public static Department GetDepartment(string name)
        {
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand($"SELECT * FROM department WHERE department_name = '{name}';", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    return new Department
                    {
                        IdDepartment = (int) dbReader[0],
                        Name = dbReader[1].ToString()
                    };
                return null;
            }
        }

        public static List<Group> GetGroups()
        {
            var groups = new List<Group>();
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM `group`;", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    groups.Add(new Group
                    {
                        IdGroup = (int) dbReader[0],
                        Name = dbReader[1].ToString(),
                        IdDepartment = (int) dbReader[2]
                    });
                return groups;
            }
        }

        public static List<Teacher> GetTeachers()
        {
            var teachers = new List<Teacher>();
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM teacher", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    teachers.Add(new Teacher
                    {
                        IdTeacher = (int) dbReader[0],
                        Name = dbReader[1].ToString()
                    });
                return teachers;
            }
        }

        public static List<Department> GetDepartments()
        {
            var department = new List<Department>();
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM department", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    department.Add(new Department
                    {
                        IdDepartment = (int) dbReader[0],
                        Name = dbReader[1].ToString()
                    });
                return department;
            }
        }

        public static List<Discipline> GetDisciplines()
        {
            var disciplines = new List<Discipline>();
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM discipline", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    disciplines.Add(new Discipline
                    {
                        IdDiscipline = (int) dbReader[0],
                        Name = dbReader[1].ToString()
                    });
                return disciplines;
            }
        }


        public static List<Office> GetOffices()
        {
            var offices = new List<Office>();
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM `office`", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    offices.Add(new Office
                    {
                        IdOffice = (int) dbReader[0],
                        OfficeNumber = dbReader[1].ToString()
                    });
                return offices;
            }
        }

        public static List<Lesson> GetLessons()
        {
            var lessons = new List<Lesson>();
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM `lesson`", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    lessons.Add(new Lesson
                    {
                        IdLesson = (int) dbReader[0],
                        LessonNumber = dbReader[1].ToString()
                    });
                return lessons;
            }
        }

        public static List<WeekDay> GetWeekDays()
        {
            var weekDays = new List<WeekDay>();
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM `weekday`", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    weekDays.Add(new WeekDay
                    {
                        IdWeekDay = (int) dbReader[0],
                        Name = (string) dbReader[1]
                    });
                return weekDays;
            }
        }

        public static List<TTable> GetTTables()
        {
            var ttables = new List<TTable>();
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM `ttable`", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    ttables.Add(new TTable
                    {
                        IdTimeTable = (int) dbReader[0],
                        IdWeekDay = (int) dbReader[1],
                        IdLesson = (int) dbReader[2],
                        IdOffice = dbReader[3] != DBNull.Value ? (int) dbReader[3] : 0,
                        IdDisciplineGroupTeacher = (int) dbReader[4]
                    });
                return ttables;
            }
        }

        public static List<SubTTable> GetSubTtables()
        {
            var subttables = new List<SubTTable>();
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM `sub_ttable`", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    subttables.Add(new SubTTable
                    {
                        IdSubTTable = (int) dbReader[0],
                        IdWeekDay = (int) dbReader[1],
                        IdLesson = (int) dbReader[2],
                        IdOffice = dbReader[3] != DBNull.Value ? (int) dbReader[3] : 0,
                        IdDisciplineGroupTeacher = (int) dbReader[4],
                        Date = (DateTime) dbReader[5]
                    });
                return subttables;
            }
        }

        public static List<DisciplineGroupTeacher> GetDisciplineGroupTeachers()
        {
            var disciplineGroupTeachers = new List<DisciplineGroupTeacher>();
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM `discipline-group-teacher`", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    disciplineGroupTeachers.Add(new DisciplineGroupTeacher
                    {
                        IdDisciplineGroupTeacher = (int) dbReader[0],
                        IdTeacher = dbReader[1] != DBNull.Value ? (int) dbReader[1] : 0,
                        IdDiscipline = (int) dbReader[2],
                        IdGroup = (int) dbReader[3]
                    });
                return disciplineGroupTeachers;
            }
        }

        public static DisciplineGroupTeacher GetDisciplineGroupTeacher(int id)
        {
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand(
                    $"SELECT * FROM `discipline-group-teacher` WHERE `iddiscipline-group-teacher` = '{id}';", conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    return new DisciplineGroupTeacher
                    {
                        IdDisciplineGroupTeacher = (int) dbReader[0],
                        IdTeacher = dbReader[1] != DBNull.Value ? (int) dbReader[1] : 0,
                        IdDiscipline = (int) dbReader[2],
                        IdGroup = (int) dbReader[3]
                    };
                return null;
            }
        }

        public static DisciplineGroupTeacher GetDisciplineGroupTeacher(DisciplineGroupTeacher disciplineGroupTeacher)
        {
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand(
                    $"SELECT * FROM `discipline-group-teacher` WHERE `idgroup` = '{disciplineGroupTeacher.Group.IdGroup}' AND `iddiscipline` = '{disciplineGroupTeacher.Discipline.IdDiscipline}';",
                    conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return null;
                while (dbReader.Read())
                    return new DisciplineGroupTeacher
                    {
                        IdDisciplineGroupTeacher = (int) dbReader[0],
                        IdTeacher = dbReader[1] != DBNull.Value ? (int) dbReader[1] : 0,
                        IdDiscipline = (int) dbReader[2],
                        IdGroup = (int) dbReader[3]
                    };
                return null;
            }
        }
    }
}