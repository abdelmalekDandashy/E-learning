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

            //Question oQuestion = new Question();
            //oTools.SetPropertiesDefaultValue(oQuestion);

            //oQuestion.QUESTION_ID = -1;
            //oQuestion.CATEGORY_ID = 1;
            //oQuestion.DESCRIPTION = "1233";
            //oQuestion.STUDENT_ID = 1;
            //oQuestion.IS_ANSWERED = true;
            //oQuestion.IS_PUBLIC = true;
            //oQuestion.IS_SELF_CLOSED = false;
            //oQuestion.OWNER_ID = 1;
            //oQuestion.ENTRY_USER_ID = 1;
            //oQuestion.TEACHER_ID = 2;
            //oBLC.Edit_Question(oQuestion);
            //var jsonString = JsonConvert.SerializeObject(oQuestion);

            User oUser = new User();
            oTools.SetPropertiesDefaultValue(oUser);
            oUser.USER_ID = -1;
            oUser.OWNER_ID = 1;
            oUser.IS_ACTIVE = true;
            oUser.USERNAME = "rafik";
            oUser.PASSWORD = "asadhkajshdk";
            oUser.USER_TYPE_CODE_ID = 2;
            //oBLC.Edit_User(oUser);
            var jsonString = JsonConvert.SerializeObject(oUser);
            Console.WriteLine(jsonString);
            Console.WriteLine("user added");
            

            //Console.WriteLine(jsonString);

            //Params_Get_Question_By_QUESTION_ID oParams_Get_Question_By_QUESTION_ID = new Params_Get_Question_By_QUESTION_ID();
            //oParams_Get_Question_By_QUESTION_ID.QUESTION_ID = 39;
            //Question oQuestion = oBLC.Get_Question_By_QUESTION_ID(oParams_Get_Question_By_QUESTION_ID);

            //Console.WriteLine(oQuestion.DESCRIPTION);


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



        }
    }
}
