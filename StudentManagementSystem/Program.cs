using StudentManagementSystem.Controllers;

void showStudentMenu(StudentController studentController)
{
    int choice = 0;
    while(choice != 8)
    {
        Console.Clear();
        Console.Write("Please select an option:\n" +
        "1. Add Student data\n" +
        "2. Display all students data\n" +
        "3. Display student by enrolment data\n" +
        "4. Update Student data\n" +
        "5. Delete student record\n" +
        "6. Register new course\n" +
        "7. Enter grades\n" +
        "8. Go back\n" +
        "Your choice: ");
        choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                studentController.addNewStudent();
                break;
            case 2:
                studentController.getAllStudents();
                break;
            case 3:
                studentController.getStudentByEnrolment();
                break;
            case 4:
                studentController.updateStudent();
                break;
            case 5:
                studentController.deleteStudent();
                break;
            case 6:
                studentController.registerNewCourse();
                break;
            case 7:
                studentController.enterGrade();
                break;
            case 8:
                break;
            default:
                Console.WriteLine("Please enter the correct choice!");
                Thread.Sleep(1600);
                break;
        }
    }
}

void showSubjectMenu(SubjectController subjectController)
{
    int choice = 0;
    while (choice != 4)
    {
        Console.Clear();
        Console.Write("Please select an option:\n" +
        "1. Add New Subject\n" +
        "2. Display all subjects\n" +
        "3. Remove Subject\n" +
        "4. Go back\n" +
        "Your choice: ");
        choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                subjectController.addNewSubject();
                break;
            case 2:
                subjectController.getAllSubjects();
                break;
            case 3:
                subjectController.removeSubject();
                break;
            case 4:
                break;
            default:
                Console.WriteLine("Please enter the correct choice!");
                Thread.Sleep(1600);
                break;
        }
    }
}

void showTeacherMenu(TeacherController teacherController)
{
    int choice = 0;
    while (choice != 7)
    {
        Console.Clear();
        Console.Write("Please select an option:\n" +
        "1. Add New Teacher\n" +
        "2. Display all teachers\n" +
        "3. Update Teacher\n" +
        "4. Remove Teacher\n" +
        "5. Register student to teacher\n" +
        "6. Register course to teacher\n" +
        "7. Go back\n" +
        "Your choice: ");
        choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                teacherController.addNewTeacher();
                break;
            case 2:
                teacherController.getAllTeachers();
                break;
            case 3:
                teacherController.updateTeacher();
                break;
            case 4:
                teacherController.deleteTeacher();
                break;
            case 5:
                teacherController.registerStudentForATeacher();
                break;
            case 6:
                teacherController.registerSubjectForATeacher();
                break;
            case 7:
                break;
            default:
                Console.WriteLine("Please enter the correct choice!");
                Thread.Sleep(1600);
                break;
        }
    }
}

while (true)
{
    Console.Clear();
    Console.Write("Please select your role type or another option:\n" +
    "1. Student\n" +
    "2. Teacher\n" +
    "3. Subject Manager\n" + 
    "4. Exit program\n" + 
    "Your choice: ");
    int choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            StudentController studentController = new StudentController();
            showStudentMenu(studentController);
            break;
        case 2:
            TeacherController teacherController = new TeacherController();
            showTeacherMenu(teacherController);
            break;
        case 3:
            SubjectController subjectController = new SubjectController();
            showSubjectMenu(subjectController);
            break;
        case 4:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Please select a correct option!");
            break;
    }
}