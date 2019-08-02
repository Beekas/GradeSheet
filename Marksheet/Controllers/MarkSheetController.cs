using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marksheet.Models;
using Marksheet.DAL;
using Marksheet.ViewModels;
using System.Data.Entity;
using Marksheet.Filters;

namespace Marksheet.Controllers
{
    [SessionCheck]
    public class MarkSheetController : Controller
    {
        private string[] Subjects = new string[] { "English", "Nepali", "Mathematics", "Science", "Social Studies", "Health", "OBTE","Moral", "Optional1" };
        private readonly MarkSheetEntities db = new MarkSheetEntities();


        public ActionResult Details(int? id)
        {
            if (id == null)
            {

                return RedirectToAction("Index");
            }
            else
            {
                return View(db.Marksheets.Find(id.Value));
            }
        }


        // GET: MarkSheet
        public ActionResult Index()
        {
           // List<ResultVM> Results = new List<ResultVM>();
            IEnumerable<Models.Marksheet> marksheets = db.Marksheets.Include(m => m.Student).Include(m => m.AcademicYear).ToList();
            //foreach (Models.Marksheet item in marksheets)
            //{
            //    ResultVM result = new ResultVM();
            //    result.Student = item.Student;
            //    result.Marksheet = item;
            //    int totalObtained = item.EnglishPM + item.EnglishTM + item.NepaliPM + item.NepaliTM + item.MathTM + item.SocialPM + item.SocialTM +
            //                item.SciencePM + item.ScienceTM + item.HealthPM + item.HealthTM+item.ObtePM+item.ObteTM + item.Optional1PM + item.Optional1TM                             ;
            //    int totalFull = 550;
            //    totalFull = totalFull + db.OptionalSubjects.FirstOrDefault(m => m.SchoolId == item.Student.SchoolId).Subject.TFullMarks;
            //    if (item.HasPractical1)
            //    {
            //        totalFull = totalFull + db.OptionalSubjects.FirstOrDefault(m => m.SchoolId == item.Student.SchoolId).Subject.PFullMarks.Value;
            //    }
            //    totalFull = totalFull + db.OptionalSubjects.OrderByDescending(s=>s.Id).FirstOrDefault(m => m.SchoolId == item.Student.SchoolId).Subject.TFullMarks;
            //    if (item.HasPractical2)
            //    {
            //        totalFull = totalFull + db.OptionalSubjects.OrderByDescending(s => s.Id).FirstOrDefault(m => m.SchoolId == item.Student.SchoolId).Subject.PFullMarks.Value;
            //    }
            //    result.GPA = findGrade(totalObtained,totalFull);
            //}
            return View(marksheets);
        }

        //public ActionResult ViewMarkSheet(int? id)
        //{
        //    if (id == null)
        //    {
        //        TempData["ErrorMessage"] = "Error!";
        //        return RedirectToAction("Index");
        //    }

        //    Models.Marksheet marksheet = db.Marksheets.Find(id);
        //    MarksVM marksvm = new MarksVM();
        //    List<SubjectMarkVM> lstSubject = new List<SubjectMarkVM>();


        //    if (marksheet != null)
        //    {
        //        if (!db.ActiveDays.Any(m => m.SchoolId == marksheet.Student.SchoolId &&
        //                                 m.AcademicYearId == marksheet.AcedamicYearId &&
        //                                 m.TerminalName == marksheet.Term))
        //        {
        //            TempData["ErrorMessage"] = "Error! No active days set.";
        //            return RedirectToAction("Index");
        //        }
        //        marksvm.StudentName = marksheet.Student.StudentName;
        //        marksvm.TerminalExam = marksheet.Term;
        //        marksvm.DOB = marksheet.Student.DOB.ToString("yyyy-mm-dd");
        //        marksvm.RollNo = "";// marksheet.Student.RollNo;
        //        marksvm.SchoolName = marksheet.Student.School.SchoolName;
        //        marksvm.SchoolAddress = marksheet.Student.School.Municipality;
        //        marksvm.FatherName = marksheet.Student.FatherName;
        //        marksvm.MotherName = marksheet.Student.MotherName;
        //        marksvm.StudentAddress = marksheet.Student.Address;
        //        marksvm.PresentDay = marksheet.Attendance.ToString();
        //        marksvm.AcademicYear = marksheet.AcademicYear.Year;

        //        marksvm.AcademicDay = db.ActiveDays.FirstOrDefault(m => m.SchoolId == marksheet.Student.SchoolId &&
        //                                m.AcademicYearId == marksheet.AcedamicYearId &&
        //                                m.TerminalName == marksheet.Term).Activeday.ToString();

        //        foreach (string item in Subjects)
        //        {
        //            SubjectMarkVM objSubj = new SubjectMarkVM();
        //            string caseSwitch = item;

        //            switch (caseSwitch)
        //            {
        //                case "English":
        //                    objSubj.SerialNo = "01";
        //                    objSubj.SubjectName = item;
        //                    objSubj.FullMarks = "100";
        //                    objSubj.PassMarks = "40";
        //                    objSubj.Theory = marksheet.EnglishTM.ToString();
        //                    objSubj.Practical = marksheet.EnglishPM.ToString();
        //                    objSubj.Total = (marksheet.EnglishPM + marksheet.EnglishTM).ToString();
        //                    if (Convert.ToInt32(objSubj.Total) < 32)
        //                    {
        //                        objSubj.Remarks = "F";
        //                    }
        //                    lstSubject.Add(objSubj);

        //                    break;
        //                case "Nepali":
        //                    objSubj.SerialNo = "02";
        //                    objSubj.SubjectName = item;
        //                    objSubj.FullMarks = "100";
        //                    objSubj.PassMarks = "40";
        //                    objSubj.Theory = marksheet.NepaliTM.ToString();
        //                    objSubj.Practical = marksheet.NepaliPM.ToString();
        //                    objSubj.Total = (marksheet.NepaliTM).ToString();
        //                    if (Convert.ToInt32(objSubj.Total) < 32)
        //                    {
        //                        objSubj.Remarks = "F";
        //                    }
        //                    lstSubject.Add(objSubj);

        //                    break;
        //                case "Mathematics":
        //                    objSubj.SerialNo = "03";
        //                    objSubj.SubjectName = item;
        //                    objSubj.FullMarks = "100";
        //                    objSubj.PassMarks = "40";
        //                    objSubj.Theory = marksheet.MathTM.ToString();
        //                    objSubj.Total = (marksheet.MathTM).ToString();
        //                    if (Convert.ToInt32(objSubj.Total) < 32)
        //                    {
        //                        objSubj.Remarks = "F";
        //                    }
        //                    lstSubject.Add(objSubj);

        //                    break;
        //                case "Science":
        //                    objSubj.SerialNo = "04";
        //                    objSubj.SubjectName = item;
        //                    objSubj.FullMarks = "100";
        //                    objSubj.PassMarks = "40";
        //                    objSubj.Theory = marksheet.ScienceTM.ToString();
        //                    objSubj.Practical = marksheet.SciencePM.ToString();
        //                    objSubj.Total = (marksheet.SciencePM + marksheet.ScienceTM).ToString();
        //                    if (Convert.ToInt32(objSubj.Total) < 32)
        //                    {
        //                        objSubj.Remarks = "F";
        //                    }
        //                    lstSubject.Add(objSubj);

        //                    break;
        //                case "Social Studies":
        //                    objSubj.SerialNo = "05";
        //                    objSubj.SubjectName = item;
        //                    objSubj.FullMarks = "100";
        //                    objSubj.PassMarks = "40";
        //                    objSubj.Theory = marksheet.SocialTM.ToString();
        //                    objSubj.Practical = marksheet.SocialPM.ToString();
        //                    objSubj.Total = (marksheet.SocialTM).ToString();
        //                    if (Convert.ToInt32(objSubj.Total) < 32)
        //                    {
        //                        objSubj.Remarks = "F";
        //                    }
        //                    lstSubject.Add(objSubj);

        //                    break;
        //                case "Health":
        //                    objSubj.SerialNo = "06";
        //                    objSubj.SubjectName = "Health, Pop & Env Edu";
        //                    objSubj.FullMarks = "100";
        //                    objSubj.PassMarks = "40";
        //                    objSubj.Theory = marksheet.HealthTM.ToString();
        //                    objSubj.Practical = marksheet.HealthPM.ToString();
        //                    objSubj.Total = (marksheet.HealthPM + marksheet.HealthTM).ToString();
        //                    if (Convert.ToInt32(objSubj.Total) < 32)
        //                    {
        //                        objSubj.Remarks = "F";
        //                    }
        //                    lstSubject.Add(objSubj);

        //                    break;
        //                case "Optional1":
        //                    bool haspractical = db.OptionalSubjects.Include(m => m.Subject).FirstOrDefault(m => m.SchoolId == marksheet.SchoolId).Subject.HasPractical;
        //                    objSubj.SerialNo = "07";
        //                    objSubj.SubjectName = db.OptionalSubjects.Include(m => m.Subject).FirstOrDefault(m => m.SchoolId == marksheet.SchoolId).Subject.SubName;
        //                    objSubj.FullMarks = "100";
        //                    objSubj.PassMarks = "40";
        //                    objSubj.Theory = marksheet.Optional1TM.ToString();
        //                    objSubj.Practical = "";
        //                    if (haspractical)
        //                    {
        //                        objSubj.Practical = marksheet.Optional1PM.ToString();
        //                    }
        //                    if (haspractical)
        //                    {
        //                        objSubj.Total = (marksheet.Optional1PM + marksheet.Optional1TM).ToString();

        //                    }
        //                    else
        //                    {
        //                        objSubj.Total = (marksheet.Optional1TM).ToString();

        //                    }
        //                    if (Convert.ToInt32(objSubj.Total) < 32)
        //                    {
        //                        objSubj.Remarks = "F";
        //                    }
        //                    lstSubject.Add(objSubj);

        //                    break;
        //                case "Optional2":
        //                    bool haspractical2 = db.OptionalSubjects.Include(m => m.Subject).OrderByDescending(s => s.Id).FirstOrDefault(m => m.SchoolId == marksheet.SchoolId).Subject.HasPractical;
        //                    objSubj.SerialNo = "08";
        //                    objSubj.SubjectName = db.OptionalSubjects.Include(m => m.Subject).OrderByDescending(s => s.Id).FirstOrDefault(m => m.SchoolId == marksheet.SchoolId).Subject.SubName;
        //                    objSubj.FullMarks = "100";
        //                    objSubj.PassMarks = "40";
        //                    objSubj.Theory = marksheet.Optional2TM.ToString();
        //                    objSubj.Practical = "";
        //                    if (haspractical2)
        //                    {
        //                        objSubj.Practical = marksheet.Optional2PM.ToString();
        //                    }
        //                    if (haspractical2)
        //                    {
        //                        objSubj.Total = (marksheet.Optional2PM + marksheet.Optional2TM).ToString();

        //                    }
        //                    else
        //                    {
        //                        objSubj.Total = (marksheet.Optional2TM).ToString();

        //                    }
        //                    if (Convert.ToInt32(objSubj.Total) < 32)
        //                    {
        //                        objSubj.Remarks = "F";
        //                    }
        //                    lstSubject.Add(objSubj);

        //                    break;
        //                default:

        //                    break;
        //            }
        //        }
        //        marksvm.Subjects = lstSubject;
        //        if (lstSubject.Any(m => m.Remarks == "F"))
        //        {
        //            marksvm.Division = "Fail";
        //        }
        //        if (marksvm.Division == "Fail")
        //        {
        //            marksvm.GrandTotal = "";
        //            marksvm.Percentage = "";
        //        }
        //        else
        //        {
        //            marksvm.GrandTotal = lstSubject.Sum(m => int.Parse(m.Total)).ToString();
        //            marksvm.Percentage = (Convert.ToDecimal(marksvm.GrandTotal) / lstSubject.Sum(m => int.Parse(m.FullMarks))).ToString("0.00");
        //            if (Convert.ToInt32(marksvm.GrandTotal) >= 640)
        //            {
        //                marksvm.Division = "First Division with Distinction";
        //            }
        //            else if (Convert.ToDecimal(marksvm.GrandTotal) < 640 && Convert.ToDecimal(marksvm.GrandTotal) >= 480)
        //            {
        //                marksvm.Division = "First Division";
        //            }
        //            else if (Convert.ToDecimal(marksvm.GrandTotal) < 480 && Convert.ToDecimal(marksvm.GrandTotal) >= 360)
        //            {
        //                marksvm.Division = "Second Division";
        //            }
        //            else if (Convert.ToDecimal(marksvm.GrandTotal) < 360 && Convert.ToDecimal(marksvm.GrandTotal) >= 256)
        //            {
        //                marksvm.Division = "Third Division";
        //            }
        //        }
        //        return View(marksvm);

        //    }
        //    TempData["ErrorMessage"] = "Error!";
        //    return RedirectToAction("Index");
        //}

        public ActionResult ViewGradeSheet(int? id)
        {
            if (id == null)
            {
                TempData["ErrorMessage"] = "Error!";
                return RedirectToAction("Index");
            }

            Models.Marksheet marksheet = db.Marksheets.Find(id);
            GradeVM marksvm = new GradeVM();
            List<SubjectVM> lstSubject = new List<SubjectVM>();


            if (marksheet != null)
            {
                if (!db.ActiveDays.Any(m => m.SchoolId == marksheet.Student.SchoolId &&
                                         m.AcademicYearId == marksheet.AcedamicYearId &&
                                         m.TerminalName == marksheet.Term))
                {
                    TempData["ErrorMessage"] = "Error! No active days set.";
                    return RedirectToAction("Index");
                }

                marksvm.StudentName = marksheet.Student.StudentName;
                marksvm.TerminalExam = marksheet.Term;
                marksvm.DOB = marksheet.Student.DOB.ToString("yyyy-MM-dd");
                marksvm.RollNo = "";
                marksvm.SchoolName = marksheet.Student.School.SchoolName;
                marksvm.SchoolAddress = marksheet.Student.School.Municipality;
                marksvm.Logo = "/images/" + marksheet.SchoolId.ToString() + ".jpg";

                marksvm.FatherName = marksheet.Student.FatherName;
                marksvm.MotherName = marksheet.Student.MotherName;
                marksvm.StudentAddress = marksheet.Student.Address;
                marksvm.PresentDay = marksheet.Attendance.ToString();
                marksvm.AcademicYear = marksheet.AcademicYear.Year;
                marksvm.AcademicDay = db.ActiveDays.FirstOrDefault(m => m.SchoolId == marksheet.Student.SchoolId &&
                                        m.AcademicYearId == marksheet.AcedamicYearId &&
                                        m.TerminalName == marksheet.Term).Activeday.ToString();

                foreach (string item in Subjects)
                {
                    SubjectVM objSubj = new SubjectVM();
                    objSubj.CreditHour = "4";
                    string caseSwitch = item;

                    switch (caseSwitch)
                    {
                        case "English":
                            objSubj.SerialNo = "01";
                            objSubj.SubjectName = item;
                            objSubj.Theory = findGrade(marksheet.EnglishTM, 75);
                            objSubj.Practical = findGrade(marksheet.EnglishPM, 25);
                            objSubj.Remarks = "";
                            objSubj.FinalGrade = findGrade((marksheet.EnglishPM + marksheet.EnglishTM), 100);
                            objSubj.GradePoint = findGradePoint((marksheet.EnglishPM + marksheet.EnglishTM),100);
                            lstSubject.Add(objSubj);

                            break;
                        case "Nepali":
                            objSubj.SerialNo = "02";
                            objSubj.SubjectName = item;
                            objSubj.Theory = findGrade(marksheet.NepaliTM, 75);
                            objSubj.Practical = findGrade(marksheet.NepaliPM, 25);
                            objSubj.Remarks = "";
                            objSubj.FinalGrade = findGrade((marksheet.NepaliTM + marksheet.NepaliPM), 100);
                            objSubj.GradePoint = findGradePoint((marksheet.NepaliTM + marksheet.NepaliPM),100);
                            lstSubject.Add(objSubj);

                            break;
                        case "Mathematics":
                            objSubj.SerialNo = "03";
                            objSubj.SubjectName = item;
                            objSubj.Theory = findGrade(marksheet.MathTM, 100);
                            objSubj.Practical = "";
                            objSubj.Remarks = "";
                            objSubj.FinalGrade = findGrade((marksheet.MathTM), 100);
                            objSubj.GradePoint = findGradePoint((marksheet.MathTM),100);
                            lstSubject.Add(objSubj);

                            break;
                        case "Science":
                            objSubj.SerialNo = "04";
                            objSubj.SubjectName = item;
                            objSubj.Theory = findGrade(marksheet.ScienceTM, 75);
                            objSubj.Practical = findGrade(marksheet.SciencePM, 25);
                            objSubj.Remarks = "";
                            objSubj.FinalGrade = findGrade((marksheet.SciencePM + marksheet.ScienceTM), 100);
                            objSubj.GradePoint = findGradePoint((marksheet.ScienceTM + marksheet.SciencePM),100);
                            lstSubject.Add(objSubj);

                            break;
                        case "Social Studies":
                            objSubj.SerialNo = "05";
                            objSubj.SubjectName = item;
                            objSubj.Theory = findGrade(marksheet.SocialTM, 75);
                            objSubj.Practical = findGrade(marksheet.SocialPM, 25);
                            objSubj.Remarks = "";
                            objSubj.FinalGrade = findGrade((marksheet.SocialTM + marksheet.SocialPM), 100);
                            objSubj.GradePoint = findGradePoint((marksheet.SocialTM + marksheet.SocialPM),100);
                            lstSubject.Add(objSubj);

                            break;
                        case "Health":
                            objSubj.SerialNo = "06";
                            objSubj.SubjectName = "Health, Pop & Env Edu";
                            objSubj.Theory = findGrade(marksheet.HealthTM, 30);
                            objSubj.Practical = findGrade(marksheet.HealthPM, 20);
                            objSubj.Remarks = "";
                            objSubj.FinalGrade = findGrade((marksheet.HealthPM + marksheet.HealthTM), 50);
                            objSubj.GradePoint = findGradePoint((marksheet.HealthPM + marksheet.HealthTM),50);
                            lstSubject.Add(objSubj);

                            break;
                        case "OBTE":
                            objSubj.SerialNo = "07";
                            objSubj.SubjectName = item;
                            objSubj.Theory = findGrade(marksheet.ObteTM, 50);
                            objSubj.Practical = findGrade(marksheet.ObtePM, 50);
                            objSubj.Remarks = "";
                            objSubj.FinalGrade = findGrade((marksheet.ObteTM + marksheet.ObtePM), 100);
                            objSubj.GradePoint = findGradePoint((marksheet.ObteTM + marksheet.ObteTM), 100);
                            lstSubject.Add(objSubj);
                            break;
                        case "Moral":
                            objSubj.SerialNo = "08";
                            objSubj.SubjectName = item;
                            objSubj.Theory = findGrade(marksheet.MoralTM, 25);
                            objSubj.Practical = findGrade(marksheet.MoralPM, 25);
                            objSubj.Remarks = "";
                            objSubj.FinalGrade = findGrade((marksheet.MoralTM + marksheet.MoralPM), 50);
                            objSubj.GradePoint = findGradePoint((marksheet.MoralPM + marksheet.MoralTM), 50);
                            lstSubject.Add(objSubj);

                            break;
                        case "Optional1":
                            bool haspractical = db.OptionalSubjects.Include(m => m.Subject).FirstOrDefault(m => m.SchoolId == marksheet.SchoolId).Subject.HasPractical;
                            objSubj.SerialNo = "09";
                            objSubj.SubjectName = db.OptionalSubjects.Include(m => m.Subject).FirstOrDefault(m => m.SchoolId == marksheet.SchoolId).Subject.SubName;
                            objSubj.CreditHour = "4";
                            objSubj.Remarks = "";
                            if (haspractical)
                            {
                                int practicalMark = db.OptionalSubjects.Include(m => m.Subject).FirstOrDefault(m => m.SchoolId == marksheet.SchoolId).Subject.PFullMarks.Value;
                                int theoryMark = db.OptionalSubjects.Include(m => m.Subject).FirstOrDefault(m => m.SchoolId == marksheet.SchoolId).Subject.TFullMarks;
                                objSubj.Practical = findGrade(marksheet.Optional1PM, practicalMark);
                                objSubj.Theory = findGrade(marksheet.Optional1TM, (theoryMark));
                                objSubj.FinalGrade = findGrade(marksheet.Optional1PM + marksheet.Optional1TM, (theoryMark+practicalMark));
                                objSubj.GradePoint = findGradePoint((marksheet.Optional1PM + marksheet.Optional1TM),(practicalMark+theoryMark));

                            }
                            else
                            {
                                int theoryMark = db.OptionalSubjects.Include(m => m.Subject).FirstOrDefault(m => m.SchoolId == marksheet.SchoolId).Subject.TFullMarks;
                                objSubj.Practical = "";
                                objSubj.Theory = findGrade(marksheet.Optional1TM, (theoryMark));
                                objSubj.FinalGrade = findGrade(marksheet.Optional1TM, theoryMark);
                                objSubj.GradePoint = findGradePoint(marksheet.Optional1TM,theoryMark);
                            }
                            lstSubject.Add(objSubj);

                            break;
                        default:

                            break;
                    }
                }

                marksvm.GPA = lstSubject.Sum(m => Decimal.Parse(m.GradePoint) / 9).ToString("0.00");
                marksvm.AggregateGPA = findAggregate(Convert.ToDecimal(marksvm.GPA));
                marksvm.Subjects = lstSubject;
                return View(marksvm);

            }
            TempData["ErrorMessage"] = "Error!";
            return RedirectToAction("Index");
        }
        public string findAggregate(decimal gpa)
        {
            double percentage = Convert.ToDouble(gpa);
            if (percentage >= 3.6)
            {
                return "Outstanding";
            }
            else if (percentage < 3.6 && percentage >= 3.2)
            {
                return "Excellent";
            }
            else if (percentage < 3.2 && percentage >= 2.8)
            {
                return "Very Good";
            }

            else if (percentage < 2.8 && percentage >= 2.4)
            {
                return "Good";
            }

            else if (percentage < 2.4 && percentage >= 2.0)
            {
                return "Satisfactory";
            }

            else if (percentage < 2.0 && percentage >= 1.6)
            {
                return "Acceptable";
            }

            else if (percentage < 1.6 && percentage >= 1.2)
            {
                return "Partially Acceptable";
            }

            else if (percentage < 1.2 && percentage >= 0.8)
            {
                return "Insufficient";
            }

            else if (percentage < 0.8 && percentage >= 0)
            {
                return "Very InSufficient";
            }
            return null;
        }
        public string findGrade(int marks, int fullmarks)
        {
            decimal percentage = Convert.ToDecimal(marks) / fullmarks * 100;

            if (percentage >= 90)
            {
                return "A+";
            }
            else if (percentage < 90 && percentage >= 80)
            {
                return "A";
            }
            else if (percentage < 80 && percentage >= 70)
            {
                return "B+";
            }

            else if (percentage < 70 && percentage >= 60)
            {
                return "B";
            }

            else if (percentage < 60 && percentage >= 50)
            {
                return "C+";
            }

            else if (percentage < 50 && percentage >= 40)
            {
                return "C";
            }

            else if (percentage < 40 && percentage >= 30)
            {
                return "D+";
            }

            else if (percentage < 30 && percentage >= 20)
            {
                return "D";
            }

            else if (percentage < 20 && percentage > 0)
            {
                return "E";
            }
            else if (percentage == 0)
            {
                return "N";
            }
            return null;

        }

        public string findGradePoint(int marks,int fullmarks)
        {
            decimal percentage =Convert.ToDecimal(marks)/fullmarks*100;

            if (percentage >= 90)
            {
                return "4.0";
            }
            else if (percentage < 90 && percentage >= 80)
            {
                return "3.6";
            }
            else if (percentage < 80 && percentage >= 70)
            {
                return "3.2";
            }

            else if (percentage < 70 && percentage >= 60)
            {
                return "2.8";
            }

            else if (percentage < 60 && percentage >= 50)
            {
                return "2.4";
            }

            else if (percentage < 50 && percentage >= 40)
            {
                return "2";
            }

            else if (percentage < 40 && percentage >= 30)
            {
                return "1.6";
            }

            else if (percentage < 30 && percentage >= 20)
            {
                return "1.2";
            }

            else if (percentage < 20 && percentage > 0)
            {
                return "0.8";
            }
            else if (percentage == 0)
            {
                return "0.0";
            }
            return "0.0";

        }



        public ActionResult SelectSchool()
        {
            if (db.Schools.Any())
            {
                ViewBag.SchoolId = new SelectList(db.Schools.ToList(), "Id", "SchoolName");
                return View();
            }
            else
            {
                TempData["ErrorMessage"] = "No record found for school.";
                return RedirectToAction("Index", "School");
            }

        }
        public ActionResult Add(string SchoolId)
        {
            if (string.IsNullOrEmpty(SchoolId))
            {
                TempData["ErrorMessage"] = "Error! Select School and Submit.";
                return RedirectToAction("SelectSchool");
            }
            int schoolId = Convert.ToInt32(SchoolId);

            List<SelectListItem> terminals = new List<SelectListItem> {
                new SelectListItem{Text="First",Value="First" },new SelectListItem{Text="Second",Value="Second" },new SelectListItem{Text="Final",Value="Final"}
            };

            SelectList activeYears = new SelectList(db.AcademicYears, "Id", "Year");

            IEnumerable<Student> students = db.Students.Where(m => m.SchoolId == schoolId);

            if (!students.Any())
            {
                TempData["ErrorMessage"] = "No record found for students.";
                return RedirectToAction("SelectSchool");
            }
            AcademicYear year = db.AcademicYears.FirstOrDefault(m => m.ActiveYear);
            if (!db.AcademicYears.Any())
            {
                TempData["ErrorMessage"] = "No Active academic year found.";
                return RedirectToAction("SelectSchool");
            }

            IEnumerable<Subject> subjects = db.OptionalSubjects.Where(m => m.SchoolId == schoolId).Select(m => m.Subject);
            string optional1 = "Optional1";
            bool IsPractical1 = false;
            if (subjects.Any())
            {

                optional1 = subjects.First().SubName;
                IsPractical1 = subjects.First().HasPractical;
            }
            else
            {
                TempData["ErrorMessage"] = "No record found for optional subject. Select at least two optional subject for selected school.";
                return RedirectToAction("SelectSchool");
            }


            List<MarksheetVM> marks = new List<MarksheetVM>();

            foreach (var item in students)
            {
                MarksheetVM objMarkSheet = new MarksheetVM();
                objMarkSheet.StudentId = item.Id;
                objMarkSheet.StudentName = item.StudentName;
                objMarkSheet.SchoolId = schoolId;
                objMarkSheet.Opt1HasPractical = IsPractical1;
                marks.Add(objMarkSheet);
            }
            marks[0].Terminal = new SelectList(terminals, "Value", "Text");
            marks[0].School = db.Schools.Find(schoolId).SchoolName;
            marks[0].Optional1Name = optional1;
            marks[0].AcademicYears = activeYears;
            return View(marks);
        }


        [HttpPost]
        public ActionResult Add(List<MarksheetVM> marks, FormCollection col)
        {
            List<SelectListItem> terminals = new List<SelectListItem> {
                                                    new SelectListItem{Text="First",Value="First" },
                                                     new SelectListItem{Text="Second",Value="Second" },
                                                    new SelectListItem{Text="Final",Value="Final"}
                                                    };
            SelectList ActiveYears = new SelectList(db.AcademicYears, "Id", "Year",marks[0].AcedamicYearId);
            marks[0].AcademicYears = ActiveYears;

            marks[0].Terminal = new SelectList(terminals, "Value", "Text");
            if (ModelState.IsValid)
            {
              //  string activeYear = col["ActiveYearId"];
                string term = col["Term"].ToString();
                if (string.IsNullOrEmpty(col["ActiveYearId"].ToString()) || string.IsNullOrEmpty(col["Term"].ToString()))
                {
                    ViewBag.ErrorMessage = "Select Year and terminal.";
                    return View(marks);
                }
                int yearId = Convert.ToInt32(col["ActiveYearId"]);
                //string term = col["Term"].ToString();

                School school = db.Schools.Find(marks[0].SchoolId.Value);
                AcademicYear year = db.AcademicYears.Find(yearId);
              
                if (string.IsNullOrEmpty(term))
                {

                    ViewBag.ErrorMessage = "Please Select Term.";
                    return View(marks);
                }
                bool HasPractical1 = marks[0].Opt1HasPractical;

                if (!db.Marksheets.Any(m => m.Term == term && m.AcedamicYearId == year.Id && m.SchoolId == school.Id))
                {
                    foreach (var item in marks.AsEnumerable())
                    {
                        Models.Marksheet objmark = new Models.Marksheet();
                        objmark.StudentId = item.StudentId;
                        objmark.Student = db.Students.Find(item.StudentId);
                        objmark.SchoolId = school.Id;
                        objmark.AcademicYear = year;
                        objmark.AcedamicYearId = year.Id;
                        objmark.Term = term;
                        objmark.Attendance = item.Attendance;
                        objmark.EnglishPM = item.EnglishPM;
                        objmark.EnglishTM = item.EnglishTM;
                        objmark.NepaliTM = item.NepaliTM;
                        objmark.NepaliPM = item.NepaliPM;
                        objmark.MathTM = item.MathTM;
                        objmark.SocialTM = item.SocialTM;
                        objmark.SocialPM = item.SocialPM;
                        objmark.HealthPM = item.HealthPM;
                        objmark.HealthTM = item.HealthTM;
                        objmark.SciencePM = item.SciencePM;
                        objmark.ScienceTM = item.ScienceTM;
                        objmark.ObtePM = item.ObtePM;
                        objmark.ObteTM = item.ObteTM;
                        objmark.MoralPM = item.MoralPM;
                        objmark.MoralTM = item.MoralTM;
                        objmark.Optional1TM = item.Optional1TM;
                        objmark.HasPractical1 = item.Opt1HasPractical;
                        if (item.Opt1HasPractical)
                        {
                            objmark.Optional1PM = item.Optional1PM;
                        }
                        db.Marksheets.Add(objmark);
                        db.SaveChanges();
                    }
                }
                else
                {

                    ViewBag.ErrorMessage = "Marks already inserted for selected school and selected terminal exam.";
                    return View(marks);
                }
                TempData["Message"] = "Successfully Inserted!";
                return RedirectToAction("Index");
            }
            ViewBag.ErrorMessage = "Error! Something Went Wrong.";
            return View(marks);
        }







        public ActionResult SelectSchoolEdit()
        {
            if (db.Schools.Any())
            {
                ViewBag.SchoolId = new SelectList(db.Schools.ToList(), "Id", "SchoolName");
                List<SelectListItem> terminals = new List<SelectListItem> {
                                                    new SelectListItem{Text="First",Value="First" },new SelectListItem{Text="Second",Value="Second" },new SelectListItem{Text="Final",Value="Final"}
                                                };
                ViewBag.Terminal = new SelectList(terminals, "value", "text");
                ViewBag.ActiveYearId = new SelectList(db.AcademicYears, "Id", "Year");
                return View();
            }
            else
            {
                TempData["ErrorMessage"] = "No record found for school.";
                return RedirectToAction("Index", "School");
            }

        }
        public ActionResult SelectSchoolPrint()
        {
            if (db.Schools.Any())
            {
                ViewBag.SchoolId = new SelectList(db.Schools.ToList(), "Id", "SchoolName");
                List<SelectListItem> terminals = new List<SelectListItem> {
                                                    new SelectListItem{Text="First",Value="First" },new SelectListItem{Text="Second",Value="Second" },new SelectListItem{Text="Final",Value="Final"}
                                                };
                ViewBag.Terminal = new SelectList(terminals, "value", "text");
                ViewBag.ActiveYearId = new SelectList(db.AcademicYears, "Id", "Year");
                return View();
            }
            else
            {
                TempData["ErrorMessage"] = "No record found for school.";
                return RedirectToAction("Index", "School");
            }

        }
        public ActionResult Edit(string SchoolId, string Terminal, int? ActiveYearId)
        {
            if (string.IsNullOrEmpty(SchoolId) && String.IsNullOrEmpty(Terminal) && ActiveYearId == null)
            {
                TempData["ErrorMessage"] = "Error! Select School, Term and Year and submit.";
                return RedirectToAction("SelectSchoolEdit");
            }
            
            int schoolId = Convert.ToInt32(SchoolId);
            int yearId = ActiveYearId.Value;

            List<SelectListItem> terminals = new List<SelectListItem> {
                new SelectListItem{Text="First",Value="First" },new SelectListItem{Text="Second",Value="Second" },new SelectListItem{Text="Final",Value="Final"}
            };

            IEnumerable<Models.Marksheet> marksheets = db.Marksheets.Include(m => m.Student).Where(m => m.SchoolId == schoolId && m.Term == Terminal && m.AcedamicYearId == yearId);

            if (!marksheets.Any())
            {
                TempData["ErrorMessage"] = "No record found for school, terminal and Year.";
                return RedirectToAction("SelectSchoolEdit");
            }

            AcademicYear year = db.AcademicYears.Find(yearId);

            IEnumerable<Subject> subjects = db.OptionalSubjects.Where(m => m.SchoolId == schoolId).Select(m => m.Subject);
            string optional1 = "Optional1";
            bool IsPractical1 = false;
            if (subjects.ToList().Count >=1)
            {

                optional1 = subjects.First().SubName;
                IsPractical1 = subjects.First().HasPractical;
            }
            else
            {
                TempData["ErrorMessage"] = "No record found for optional subject. Select at least two optional subject for selected school.";
                return RedirectToAction("SelectSchool");
            }


            List<MarksheetVM> marks = new List<MarksheetVM>();

            foreach (var item in marksheets)
            {
                MarksheetVM objMarkSheet = new MarksheetVM();
                objMarkSheet.Id = item.Id;
                objMarkSheet.StudentId = item.StudentId;
                objMarkSheet.StudentName = item.Student.StudentName;
                objMarkSheet.SchoolId = schoolId;
                objMarkSheet.AcedamicYearId = yearId;
                objMarkSheet.Term = item.Term;
                objMarkSheet.Attendance = item.Attendance;
                objMarkSheet.EnglishPM = item.EnglishPM;
                objMarkSheet.EnglishTM = item.EnglishTM;
                objMarkSheet.NepaliPM = item.NepaliPM;
                objMarkSheet.NepaliTM = item.NepaliTM;
                objMarkSheet.MathTM = item.MathTM;
                objMarkSheet.SocialPM = item.SocialPM;
                objMarkSheet.SocialTM = item.SocialTM;
                objMarkSheet.HealthPM = item.HealthPM;
                objMarkSheet.HealthTM = item.HealthTM;
                objMarkSheet.SciencePM = item.SciencePM;
                objMarkSheet.ScienceTM = item.ScienceTM;
                objMarkSheet.ObtePM = item.ObtePM;
                objMarkSheet.ObteTM = item.ObteTM;
                objMarkSheet.MoralTM = item.MoralTM;
                objMarkSheet.MoralPM = item.MoralPM;
                objMarkSheet.Optional1TM = item.Optional1TM;
                objMarkSheet.Optional1PM = item.Optional1PM;
                objMarkSheet.Opt1HasPractical = IsPractical1;
                marks.Add(objMarkSheet);
            }
            marks[0].Terminal = new SelectList(terminals, "Value", "Text", marks[0].Term);
            marks[0].AcademicYears = new SelectList(db.AcademicYears, "Id", "Year", marks[0].AcedamicYearId);
            marks[0].AcademicYear = db.AcademicYears.Find(yearId).Year;
            marks[0].Schools = new SelectList(db.Schools.ToList(), "Id", "SchoolName", schoolId);
            marks[0].School = db.Schools.Find(schoolId).SchoolName;
            marks[0].Optional1Name = optional1;
            return View(marks);
        }


        [HttpPost]
        public ActionResult Edit(List<MarksheetVM> marks, FormCollection col)
        {
            List<SelectListItem> terminals = new List<SelectListItem> {
                new SelectListItem{Text="First",Value="First" },new SelectListItem{Text="Second",Value="Second" },new SelectListItem{Text="Final",Value="Final"}
            };
            marks[0].Terminal = new SelectList(terminals, "value", "text", marks[0].Term);
            marks[0].AcademicYears = new SelectList(db.AcademicYears, "Id", "Year", marks[0].AcedamicYearId);
            marks[0].Schools = new SelectList(db.Schools, "Id", "SchoolName", marks[0].SchoolId);
            if (ModelState.IsValid)
            {
                School school = db.Schools.Find(Convert.ToInt32(col["SchoolId"]));
                if (db.Students.Find(marks[0].StudentId).SchoolId != school.Id)
                {
                    ViewBag.ErrorMessage = "School selected not matched with students School";
                    return View(marks);
                }
                AcademicYear year = db.AcademicYears.Find(Convert.ToInt32(col["AcedamicYearId"]));
                string term = col["Term"].ToString();
                if (string.IsNullOrEmpty(term))
                {

                    ViewBag.ErrorMessage = "Please Select Term.";
                    return View(marks);
                }
                bool HasPractical1 = marks[0].Opt1HasPractical;

                foreach (var item in marks.AsEnumerable())
                {
                    Models.Marksheet objmark = db.Marksheets.Find(item.Id);
                    objmark.StudentId = item.StudentId;
                    objmark.Student = db.Students.Find(item.StudentId);
                    objmark.SchoolId = school.Id;
                    objmark.AcademicYear = year;
                    objmark.AcedamicYearId = year.Id;
                    objmark.Term = term;
                    objmark.Attendance = item.Attendance;
                    objmark.EnglishPM = item.EnglishPM;
                    objmark.EnglishTM = item.EnglishTM;
                    objmark.NepaliTM = item.NepaliTM;
                    objmark.NepaliPM = item.NepaliPM;
                    objmark.MathTM = item.MathTM;
                    objmark.SocialTM = item.SocialTM;
                    objmark.SocialPM = item.SocialPM;
                    objmark.HealthPM = item.HealthPM;
                    objmark.HealthTM = item.HealthTM;
                    objmark.SciencePM = item.SciencePM;
                    objmark.ScienceTM = item.ScienceTM;
                    objmark.ObteTM = item.ObteTM;
                    objmark.ObtePM = item.ObtePM;
                    objmark.MoralPM = item.MoralPM;
                    objmark.MoralTM = item.MoralTM;
                    objmark.Optional1TM = item.Optional1TM;
                    objmark.HasPractical1 = item.Opt1HasPractical;
                    if (item.Opt1HasPractical)
                    {
                        objmark.Optional1PM = item.Optional1PM;
                    }
                    
                    db.SaveChanges();
                }
                //}
                //else
                //{

                //    ViewBag.ErrorMessage = "Marks already inserted for selected school and selected terminal exam.";
                //    return View(marks);
                //}
                TempData["Message"] = "Successfully Updated!";
                return RedirectToAction("Index");
            }
            
          
            ViewBag.ErrorMessage = "Error! Something Went Wrong.";
            return View(marks);
        }

        public ActionResult ViewGradeSheetSchool(string SchoolId, string Terminal, int? ActiveYearId)
        {
            if (!string.IsNullOrEmpty(SchoolId) && !string.IsNullOrEmpty(Terminal) && ActiveYearId != null)
            {
                List<GradeVM> grades = GetGradeVM(Convert.ToInt32(SchoolId), ActiveYearId.Value, Terminal);
                if (grades.Count == 0)
                {
                    return RedirectToAction("SelectSchoolPrint");   
                }
                return View(grades);
           }
            return RedirectToAction("SelectSchoolPrint");
        }



        public List<GradeVM> GetGradeVM(int SchoolId, int ActiveYearId, string Terminal)
        {
            if (db.Marksheets.Any(m => m.SchoolId == SchoolId && m.AcedamicYearId == ActiveYearId && m.Term == Terminal))
            {
                IEnumerable<Models.Marksheet> marksheets = db.Marksheets.Include(m=>m.Student).Include(m=>m.Student.School).Include(m=>m.AcademicYear).Where(m => m.SchoolId == SchoolId && m.AcedamicYearId == ActiveYearId && m.Term == Terminal);
                List<GradeVM> lstGrade = new List<GradeVM>();

                foreach (var item in marksheets)
                {
                    Models.Marksheet marksheet = db.Marksheets.Find(item.Id);
                    GradeVM marksvm = new GradeVM();
                    List<SubjectVM> lstSubject = new List<SubjectVM>();
                    string activeDays = db.ActiveDays.FirstOrDefault(m => m.SchoolId == item.Student.SchoolId &&
                                                m.AcademicYearId == marksheet.AcedamicYearId &&
                                                m.TerminalName == marksheet.Term).Activeday.ToString();

                    if (marksheet != null)
                    {
                        marksvm.StudentName = item.Student.StudentName;
                        marksvm.TerminalExam = marksheet.Term;
                        marksvm.DOB = item.Student.DOB.ToString("yyyy-MM-dd");
                        marksvm.RollNo = "";
                        marksvm.SchoolName = item.Student.School.SchoolName;
                        marksvm.SchoolAddress = item.Student.School.Municipality;

                        marksvm.FatherName = item.Student.FatherName;
                        marksvm.MotherName = item.Student.MotherName;
                        marksvm.StudentAddress = item.Student.Address;
                        marksvm.PresentDay = marksheet.Attendance.ToString();
                        marksvm.AcademicYear = marksheet.AcademicYear.Year;
                        marksvm.AcademicDay = activeDays;
                        marksvm.Logo = "/images/" + item.SchoolId.ToString() + ".jpg";

                        foreach (string subitem in Subjects)
                        {
                            SubjectVM objSubj = new SubjectVM();
                            objSubj.CreditHour = "4";
                            string caseSwitch = subitem;

                            switch (caseSwitch)
                            {
                                case "English":
                                    objSubj.SerialNo = "01";
                                    objSubj.SubjectName = subitem;
                                    objSubj.Theory = findGrade(marksheet.EnglishTM, 75);
                                    objSubj.Practical = findGrade(marksheet.EnglishPM, 25);
                                    objSubj.Remarks = "";
                                    objSubj.FinalGrade = findGrade((marksheet.EnglishPM + marksheet.EnglishTM), 100);
                                    objSubj.GradePoint = findGradePoint((marksheet.EnglishPM + marksheet.EnglishTM),100);
                                    lstSubject.Add(objSubj);

                                    break;
                                case "Nepali":
                                    objSubj.SerialNo = "02";
                                    objSubj.SubjectName = subitem;
                                    objSubj.Theory = findGrade(marksheet.NepaliTM, 75);
                                    objSubj.Practical = findGrade(marksheet.NepaliPM, 25);
                                    objSubj.Remarks = "";
                                    objSubj.FinalGrade = findGrade((marksheet.NepaliTM + marksheet.NepaliPM), 100);
                                    objSubj.GradePoint = findGradePoint((marksheet.NepaliTM + marksheet.NepaliPM),100);
                                    lstSubject.Add(objSubj);

                                    break;
                                case "Mathematics":
                                    objSubj.SerialNo = "03";
                                    objSubj.SubjectName = subitem;
                                    objSubj.Theory = findGrade(marksheet.MathTM, 100);
                                    objSubj.Practical = "";
                                    objSubj.Remarks = "";
                                    objSubj.FinalGrade = findGrade((marksheet.MathTM), 100);
                                    objSubj.GradePoint = findGradePoint(marksheet.MathTM,100);
                                    lstSubject.Add(objSubj);

                                    break;
                                case "Science":
                                    objSubj.SerialNo = "04";
                                    objSubj.SubjectName = subitem;
                                    objSubj.Theory = findGrade(marksheet.ScienceTM, 75);
                                    objSubj.Practical = findGrade(marksheet.SciencePM, 25);
                                    objSubj.Remarks = "";
                                    objSubj.FinalGrade = findGrade((marksheet.SciencePM + marksheet.ScienceTM), 100);
                                    objSubj.GradePoint = findGradePoint((marksheet.ScienceTM + marksheet.SciencePM),100);
                                    lstSubject.Add(objSubj);

                                    break;
                                case "Social Studies":
                                    objSubj.SerialNo = "05";
                                    objSubj.SubjectName = subitem;
                                    objSubj.Theory = findGrade(marksheet.SocialTM, 75);
                                    objSubj.Practical = findGrade(marksheet.SocialPM, 25);
                                    objSubj.Remarks = "";
                                    objSubj.FinalGrade = findGrade((marksheet.SocialTM + marksheet.SocialPM), 100);
                                    objSubj.GradePoint = findGradePoint((marksheet.SocialTM + marksheet.SocialPM),100);
                                    lstSubject.Add(objSubj);

                                    break;
                                case "Health":
                                    objSubj.SerialNo = "06";
                                    objSubj.SubjectName = "Health, Pop & Env Edu";
                                    objSubj.Theory = findGrade(marksheet.HealthTM, 30);
                                    objSubj.Practical = findGrade(marksheet.HealthPM, 20);
                                    objSubj.Remarks = "";
                                    objSubj.FinalGrade = findGrade((marksheet.HealthPM + marksheet.HealthTM), 50);
                                    objSubj.GradePoint = findGradePoint((marksheet.HealthPM + marksheet.HealthTM),50);
                                    lstSubject.Add(objSubj);

                                    break;
                                case "OBTE":
                                    objSubj.SerialNo = "07";
                                    objSubj.SubjectName = subitem;
                                    objSubj.Theory = findGrade(marksheet.ObteTM, 50);
                                    objSubj.Practical = findGrade(marksheet.ObtePM, 50);
                                    objSubj.Remarks = "";
                                    objSubj.FinalGrade = findGrade((marksheet.ObteTM + marksheet.ObtePM), 100);
                                    objSubj.GradePoint = findGradePoint((marksheet.ObteTM + marksheet.ObteTM), 100);
                                    lstSubject.Add(objSubj);
                                    break;
                                case "Moral":
                                    objSubj.SerialNo = "08";
                                    objSubj.SubjectName = subitem;
                                    objSubj.Theory = findGrade(marksheet.MoralTM, 25);
                                    objSubj.Practical = findGrade(marksheet.MoralPM, 25);
                                    objSubj.Remarks = "";
                                    objSubj.FinalGrade = findGrade((marksheet.MoralTM + marksheet.MoralPM), 50);
                                    objSubj.GradePoint = findGradePoint((marksheet.MoralPM + marksheet.MoralTM), 50);
                                    lstSubject.Add(objSubj);

                                    break;
                                case "Optional1":
                                    bool haspractical = item.HasPractical1;// db.OptionalSubjects.Include(m => m.Subject).FirstOrDefault(m => m.SchoolId == marksheet.SchoolId).Subject.HasPractical;
                                    objSubj.SerialNo = "09";
                                    objSubj.SubjectName = db.OptionalSubjects.Include(m => m.Subject).FirstOrDefault(m => m.SchoolId ==marksheet.SchoolId ).Subject.SubName;
                                    objSubj.CreditHour = "4";
                                    objSubj.Remarks = "";
                                    if (haspractical)
                                    {
                                        int practicalMark =  db.OptionalSubjects.Include(m => m.Subject).FirstOrDefault(m => m.SchoolId == marksheet.SchoolId).Subject.PFullMarks.Value;
                                        int theoryMark = db.OptionalSubjects.Include(m => m.Subject).FirstOrDefault(m => m.SchoolId == marksheet.SchoolId).Subject.TFullMarks;
                                        objSubj.Practical = findGrade(marksheet.Optional1PM, practicalMark);
                                        objSubj.Theory = findGrade(marksheet.Optional1TM, (theoryMark));
                                        objSubj.FinalGrade = findGrade(marksheet.Optional1PM + marksheet.Optional1TM, (practicalMark+theoryMark));
                                        objSubj.GradePoint = findGradePoint((marksheet.Optional1PM + marksheet.Optional1TM), (practicalMark + theoryMark));

                                    }
                                    else
                                    {
                                        int theoryMark = db.OptionalSubjects.Include(m => m.Subject).FirstOrDefault(m => m.SchoolId == marksheet.SchoolId).Subject.TFullMarks;
                                        objSubj.Practical = "";
                                        objSubj.Theory = findGrade(marksheet.Optional1TM, (theoryMark));
                                        objSubj.FinalGrade = findGrade(marksheet.Optional1TM, theoryMark);
                                        objSubj.GradePoint = findGradePoint(marksheet.Optional1TM,theoryMark);
                                    }
                                    lstSubject.Add(objSubj);

                                    break;
                               
                                default:

                                    break;
                            }
                        }

                        marksvm.GPA = lstSubject.Sum(m => Decimal.Parse(m.GradePoint) / 9).ToString("0.00");
                        marksvm.AggregateGPA = findAggregate(Convert.ToDecimal(marksvm.GPA));
                        marksvm.Subjects = lstSubject;




                    }
                    lstGrade.Add(marksvm);

                }
                return lstGrade;

            }
            return null;

        }
    }
}