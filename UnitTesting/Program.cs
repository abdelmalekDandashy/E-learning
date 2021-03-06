using BLC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace UnitTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            
            #region Declaration And Initialization Section.
            string _ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
            BLC.BLCInitializer oBLCInitializer = new BLC.BLCInitializer();
            oBLCInitializer.ConnectionString = _ConnectionString;
            oBLCInitializer.OwnerID = 1;
            oBLCInitializer.UserID = 1;
            oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
            BLC.BLC oBLC = new BLC.BLC(oBLCInitializer);
            string str_Option = string.Empty;
            string str_BH_ID = string.Empty;
            string str_AC_ID = string.Empty;
            string str_Bucket_Name = string.Empty;
            string str_Main_Folder_Path = string.Empty;
            Tools.Tools oTools = new Tools.Tools();
            #endregion
            for (int i = 0; i <= 200; i++)
            {

                Question oQuestion = new Question();
                oTools.SetPropertiesDefaultValue(oQuestion);

                oQuestion.QUESTION_ID = -1;
                oQuestion.CATEGORY_ID = 1;
                oQuestion.DESCRIPTION = "1233asdasd";
                oQuestion.STUDENT_ID = 1;
                oQuestion.IS_ANSWERED = true;
                oQuestion.IS_PUBLIC = true;
                oQuestion.IS_SELF_CLOSED = false;
                oQuestion.OWNER_ID = 1;
                oQuestion.ENTRY_USER_ID = 1;
                oQuestion.TEACHER_ID = 2;
                oBLC.Edit_Question(oQuestion);
            var jsonString = JsonConvert.SerializeObject(oQuestion.QUESTION_ID);
                Console.WriteLine(jsonString);
            }

            //Answer oAnswer = new Answer();
            //oTools.SetPropertiesDefaultValue(oAnswer);
            //oAnswer.ANSWER_ID = -1;
            //oAnswer.QUESTION_ID = 12;
            //oAnswer.TEACHER_ID = 7;
            //oAnswer.DESCRIPTION = "answer from blc after event";
            //oAnswer.ENTRY_USER_ID = 1;
            //oBLC.Edit_Answer(oAnswer);



            //User oUser = new User();
            //oTools.SetPropertiesDefaultValue(oUser);
            //oUser.USER_ID = -1;
            //oUser.OWNER_ID = 1;
            //oUser.IS_ACTIVE = true;
            //oUser.USERNAME = "kajsdASD12314";      //1
            //oUser.PASSWORD = "alkjsdklKAJDKL232@";  //2
            //oUser.EMAIL = "test post event add user"; //3
            // oUser.MOBILE = "70707070";   //4
            //oUser.DOB = "1990-05-31";  //5
            //oUser.USER_TYPE_CODE_ID = 3;  // boolean
            //oUser.IS_ACTIVE = true;  
            //oBLC.Edit_User(oUser);
            //var jsonString = JsonConvert.SerializeObject(oUser);
            //Console.WriteLine(jsonString);
            //Console.WriteLine("user added");


            //List<dynamic> oTeachers = null;
            ////DALC.IDALC _AppContext = null;

            //var Email = "sami@gmail.com";
            //oTeachers = _AppContext.UP_Get_Teacher_By_Email(Email);
            //Console.WriteLine(oTeachers);
            //Console.WriteLine(oTeachers);

            //Console.WriteLine(jsonString);
            //Params_Get_Question_By_QUESTION_ID oParams_Get_Question_By_QUESTION_ID = new Params_Get_Question_By_QUESTION_ID();
            //oParams_Get_Question_By_QUESTION_ID.QUESTION_ID = 39;
            //Question oQuestion = oBLC.Get_Question_By_QUESTION_ID(oParams_Get_Question_By_QUESTION_ID);

            //Console.WriteLine(oQuestion.DESCRIPTION);


            //List<long?> numberList = new List<long?> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //Params_Get_Teacher_By_USER_ID_List oParams_Get_Teacher_By_USER_ID_List = new Params_Get_Teacher_By_USER_ID_List();
            //oParams_Get_Teacher_By_USER_ID_List.USER_ID_LIST = numberList;
            //Console.WriteLine(oParams_Get_Teacher_By_USER_ID_List);
            //List<Teacher> oListTeacher = new List<Teacher> { };
            //oListTeacher = oBLC.Get_Teacher_By_USER_ID_List(oParams_Get_Teacher_By_USER_ID_List);
            //Console.WriteLine(oListTeacher);

            List<AnswerDetails> oList = new List<AnswerDetails> { };
            Params_Get_Answer_Details oParams_Get_Answer_Details = new Params_Get_Answer_Details();
            oParams_Get_Answer_Details.QUESTION_ID = 29;

            //var oResult = oBLC.Get_Answer_Details(oParams_Get_Answer_Details);
            //Console.WriteLine(oResult);
            //Console.WriteLine(jsonString);


            //List<TopTeachers> oListTopTeachers = new List<TopTeachers> { };
            //Params_Get_Top_N_Teachers oParams_Get_Top_N_Teachers = new Params_Get_Top_N_Teachers();
            //oParams_Get_Top_N_Teachers.NUMBER_OF_TEACHERS = 3;
            //oListTopTeachers = oBLC.GetTopNTeachers(oParams_Get_Top_N_Teachers);
            //Console.WriteLine(oListTopTeachers);
            //Console.WriteLine(oListTopTeachers);




            //oQuestion.DESCRIPTION = "new desc5";
            //oBLC.Edit_Question(oQuestion);

            //Console.WriteLine("done");

            //Params_Get_Student_By_STUDENT_ID oParams_Get_Student_By_STUDENT_ID = new Params_Get_Student_By_STUDENT_ID();
            //oParams_Get_Student_By_STUDENT_ID.STUDENT_ID = 2;
            //Student oStudent = oBLC.Get_Student_By_STUDENT_ID(oParams_Get_Student_By_STUDENT_ID);
            //oStudent.DOB = oTools.GetDateString(DateTime.Today);
            //oStudent.EMAIL = "dandasheh6@gmail.com";
            //oBLC.Edit_Student(oStudent);
            //Console.WriteLine("done");



            //Authinticate

            //Params_Authenticate oParams_Authenticate = new Params_Authenticate();
            //oParams_Authenticate.EMAIL = "email8@gmail.com";
            //oParams_Authenticate.PASSWORD = "1";

            //var result = oBLC.Authenticate(oParams_Authenticate);
            ////Console.WriteLine(result);
            //Console.WriteLine(result);
            //Console.WriteLine(result);



        }
    }
}
