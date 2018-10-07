using System;
using System.Collections.Generic;
using System.IO;
using Project1.Entities;

namespace Project1.Verification
{
    public class CSVScheduleReader : IScheduleReader
    {
        private static readonly char[] SEPARATORS = new char[] { ',' };
        private static readonly string DATE_FORMAT = "M/d/yyyy";
        private static readonly string TIME_FORMAT = "h:m tt";

        public Schedule Read(string filepath)
        {
            var file = new StreamReader(filepath);
            var semesterName = ReadSemesterName(file);
            var csvFormat = ReadCSVFormat(file);
            var classes = ReadClasses(file, csvFormat);

            return new Schedule
            {
                SemesterName = semesterName,
                Classes = classes
            };
        }

        private string ReadSemesterName(StreamReader file)
        {
            string line = file.ReadLine();
            return line.Split(SEPARATORS, StringSplitOptions.RemoveEmptyEntries)[0];
        }

        private string[] ReadCSVFormat(StreamReader file) => file.ReadLine().Split(SEPARATORS, StringSplitOptions.RemoveEmptyEntries);

        private IEnumerable<SISClass> ReadClasses(StreamReader file, string[] csvFormat)
        {
            while (!file.EndOfStream)
            {
                string[] classContents = file.ReadLine().Split(SEPARATORS, StringSplitOptions.RemoveEmptyEntries);
                yield return ReadClass(classContents, csvFormat);
            }
        }

        private SISClass ReadClass(string[] classContents, string[] csvFormat)
        {
            var currentClass = new SISClass();

            for (int i = 0; i < classContents.Length; i++)
            {
                string content = classContents[i];
                if (string.IsNullOrWhiteSpace(content)) continue;

                switch (csvFormat[i])
                {
                    case "Subject":
                        {
                            currentClass.Subject = content;
                            break;
                        }
                    case "CatalogNbr":
                        {
                            currentClass.CatalogNumber = int.Parse(content);
                            break;
                        }
                    case "ClassDescr":
                        {
                            currentClass.Description = content;
                            break;
                        }
                    case "Section":
                        {
                            currentClass.Section = content;
                            break;
                        }
                    case "Instructor":
                        {
                            currentClass.Instructor = content;
                            break;
                        }
                    case "Consent":
                        {
                            currentClass.Consent = content;
                            break;
                        }
                    case "EnrlCap":
                        {
                            currentClass.EnrollmentCap = int.Parse(content);
                            break;
                        }
                    case "TopicDescr":
                        {
                            currentClass.TopicDescription = content;
                            break;
                        }
                    case "MeetingStartDt":
                        {
                            currentClass.MeetingStartDate = DateTime.Parse(content);
                            break;
                        }
                    case "MeetingEndDt":
                        {
                            currentClass.MeetingEndDate = DateTime.Parse(content);
                            break;
                        }
                    case "FacilityId":
                        {
                            currentClass.FacilityId = content;
                            break;
                        }
                    case "Mon":
                        {
                            currentClass.MeetingDays.SetMonday(IsMeetingDay(content));
                            break;
                        }
                    case "Tues":
                        {
                            currentClass.MeetingDays.SetTuesday(IsMeetingDay(content));
                            break;
                        }
                    case "Wed":
                        {
                            currentClass.MeetingDays.SetWednesday(IsMeetingDay(content));
                            break;
                        }
                    case "Thurs":
                        {
                            currentClass.MeetingDays.SetThursday(IsMeetingDay(content));
                            break;
                        }
                    case "Fri":
                        {
                            currentClass.MeetingDays.SetFriday(IsMeetingDay(content));
                            break;
                        }
                    case "Sat":
                        {
                            currentClass.MeetingDays.SetSaturday(IsMeetingDay(content));
                            break;
                        }
                    case "Sun":
                        {
                            currentClass.MeetingDays.SetSunday(IsMeetingDay(content));
                            break;
                        }
                    case "UnitsMin":
                        {
                            currentClass.CreditsMin = int.Parse(content);
                            break;
                        }
                    case "UnitsMax":
                        {
                            currentClass.CreditsMax = int.Parse(content);
                            break;
                        }
                    case "ClassAssnComponent":
                        {
                            currentClass.MeetingType = content;
                            break;
                        }
                    default:
                        {
                            throw new InvalidDataException("A given CSV File has an invalid format.");
                        }
                }
            }

            return currentClass;
        }

        private bool IsMeetingDay(string dayContent) => dayContent == "Y";
    }
}
