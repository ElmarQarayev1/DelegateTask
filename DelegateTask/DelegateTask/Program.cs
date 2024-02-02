namespace DelegateTask;

class Program
{
    static void Main(string[] args)
    {
        #region Task


        Exam exam = new Exam()
        {
            Subject = "Riyaziyyat",
            Date = new DateTime(2022, 3, 12, 08, 00, 00)

        };
        Exam exam1 = new Exam()
        {
            Subject = "Az dili",
            Date = new DateTime(2024, 3, 12, 12, 00, 12)

        };
        Exam exam2 = new Exam()
        {
            Subject = "fizika",
            Date = new DateTime(2024, 2, 2, 08, 01, 00)

        };
        Exam exam3 = new Exam()
        {
            Subject = "kimya",
            Date = new DateTime(2021, 3, 12, 09, 00, 00)

        };
        Exam exam4 = new Exam()
        {
            Subject = "tarix",
            Date = new DateTime(2024, 2, 3, 04, 1, 12)

        };
        Exam exam5 = new Exam()
        {
            Subject = "edebiyyat",
            Date = new DateTime(2024, 3, 12, 2, 2, 2)

        };

        List<Exam> exams = new List<Exam>();

        exams.Add(exam);
        exams.Add(exam1);
        exams.Add(exam2);
        exams.Add(exam3);
        exams.Add(exam4);
        exams.Add(exam5);
        foreach (var item in exams)
        {
            Console.WriteLine(item);

        }
        Console.WriteLine("vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv");

        var t1 = exams.FindAll(exam => exam.Subject.StartsWith("A"));
        foreach (var item in t1)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv");

        var t2 = exams.FindAll(exam => exam.Date.Date < DateTime.Now.Date);
        foreach (var item in t2)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv");

        var t3 = exams.FindAll(exam => (exam.Date.Date - DateTime.Now.Date).TotalDays < 30 && (exam.Date.Date - DateTime.Now.Date).TotalDays >= 0);
        foreach (var item in t3)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv");

        var t4 = exams.FindAll(exam => exam.Date.Hour == 8 && exam.Date.Minute == 0);
        foreach (var item in t4)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv");
        exams.RemoveAll(exam => exam.Date.Date < DateTime.Now.Date);

        foreach (var item in exams)
        {
            Console.WriteLine(item);

        }
        Console.WriteLine("vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv");

        var t5 = exams.Exists(exam => exam.Subject == "Riyaziyyat");
        Console.WriteLine(t5);

        Console.WriteLine("vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv");

        var t6 = exams.Find(exam => exam.Subject == "Riyaziyyat");
        Console.WriteLine(t6);
        #endregion

        List<Exam> examT = new List<Exam>();

        string opt;
        do
        {
            Console.WriteLine("1.Exam elave et\n2.Exam Sil\n3.Examlar siyahisina bax\n4.Exam axtar\n0.Programdan cix");
            Console.WriteLine("secim edin:");
             opt = Console.ReadLine();
            switch (opt)
            {
                case "1":
                    AddExam(examT); 
                    break;
                case "2":
                    RemoveExam(examT);
                    break;
                case "3":
                    AllExams(examT);
                    break;
                case "4":
                    SearchExam(examT);
                    break;
                case "0":
                    Console.WriteLine("Programdan cixildi!");
                    break;
                default:
                    Console.WriteLine("Secim yanlisdir!");
                    break;
            }

        } while (opt!="0");
        


        Console.ReadLine();
    }
    static void AddExam(List<Exam> examT)
    {
    examName:
        Console.WriteLine("exam adi daxil edin:");
        string examName = Console.ReadLine();
        if (String.IsNullOrWhiteSpace(examName))
        {
            Console.WriteLine("duzgun daxil edin!");
            goto examName;
        }
        if (examT.Exists(exam => exam.Subject == examName))
        {
            Console.WriteLine("eyni adli exam daxil etmek olmaz!");
            goto examName;
        }
    dateTimee:
        Console.WriteLine("imtahan tarixini qeyd edin:");
        string dateStr = Console.ReadLine();
        DateTime dateTime;
        if (!DateTime.TryParse(dateStr, out dateTime))
        {
            Console.WriteLine("duzgun daxil edin!");
            goto dateTimee;
        }
        Exam exam = new Exam()
        {
            Date = dateTime,
            Subject = examName
        };
        examT.Add(exam);
    }
    static void RemoveExam(List<Exam> examT)
    {
    examNameRemove:
        Console.WriteLine("silmek istediyiniz exami qeyd edin:");
        string examRemo = Console.ReadLine();
        if (String.IsNullOrWhiteSpace(examRemo))
        {
            Console.WriteLine("duzgun daxil edin!");
            goto examNameRemove;
        }
        var examToRemove = examT.Find(exam => exam.Subject == examRemo);
        if (examToRemove != null)
        {
            examT.Remove(examToRemove);
        }
        else
        {
            Console.WriteLine("ele bir exam yoxdur!");
        }
    }
    static void SearchExam(List<Exam> examT)
    {
    examNameSearch:
        Console.WriteLine("axtarmaq istediniz examin adini qeyd edin:");
        string examSearch = Console.ReadLine();
        if (String.IsNullOrWhiteSpace(examSearch))
        {
            Console.WriteLine("duzgun daxil edin!");
            goto examNameSearch;
        }
        foreach (var item in examT)
        {
            if (item.Subject.Contains(examSearch))
            {
                Console.WriteLine(item);

            }
        }
    }
    static void AllExams(List<Exam> examT)
    {
        foreach (var item in examT)
        {
            Console.WriteLine(item);
        }
    }
}

