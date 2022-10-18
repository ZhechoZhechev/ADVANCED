using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            Students = new List<Student>();
        }

        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }
        public int Capacity { get; set; }

        public int Count => Students.Count;
        public string RegisterStudent(Student student) 
        {
            if (Capacity > Count)
            {
                Students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }
        public string DismissStudent(string firstName, string lastName) 
        {
            var studentToDissmiss = Students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (studentToDissmiss == null)
            {
                return "Student not found";
            }
            else
            {
                Students.Remove(studentToDissmiss);
                return $"Dismissed student {firstName} {lastName}";
            }
        }
        public string GetSubjectInfo(string subject) 
        {
            var studsWithSbjct = Students.FindAll(x => x.Subject == subject);
            if (studsWithSbjct.Count == 0)
            {
                return "No students enrolled for the subject";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                
                foreach (var student in studsWithSbjct)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }
                return sb.ToString().TrimEnd();
            }
        }
        public int GetStudentsCount() 
        {
            return Count;
        }
        public Student GetStudent(string firstName, string lastName) 
        {
            var student = Students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            return student;
        }
    }
}
