using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace BLC
{
    #region BLC
    public partial class BLC : IDisposable
    {
        #region Enumeration
        public enum Enum_Language
        {
            English = 0,
            French = 1,
            Arabic = 2
        }
        public enum Enum_BR_Codes
        {
            BR_9999,  // Invalid Credentials
            BR_0000,  // Uniqueness Violation                      
            BR_0001,  // Password should be at least 4 characters 
            BR_0002  //Password is not correct
        }
        public enum Enum_EditMode
        {
            Add,
            Update
        }
        public enum Enum_Environment
        {
            BHS = 0,
            MS  = 1
        }
        public enum Enum_GradeMode
        {
            Over_One_Hundred = 0,
            Assignment = 1
        }
        #endregion
        #region Members
        private string _ConnectionString = string.Empty;
        DALC.IDALC _AppContext = null;     
        #endregion
        #region Properties
	public Tools.Tools oTools { get; set; }
        public string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
            set
            {
                _ConnectionString = value;
            }
        }
        public long? UserID { get; set; }
        public Int32? OwnerID { get; set; }
        public Enum_Language Language { get; set; }
        public string Messages_FilePath { get; set; }
        public List<Message> Messages { get; set; }
        public Enum_Environment Environment { get; set; }
        
        #endregion       
        #region Constructor
        public BLC()
        {
            #region Declaration And Initialization Section.
            #endregion
            #region Body Section.
            #endregion
        }
        public BLC(BLCInitializer i_BLCInitializer)
        {
            #region Declaration And Initialization Section.    
            Tools.Tools oTools = new Tools.Tools(); 
            #endregion
            #region Body Section.
            // ---------------------
            ConnectionString = i_BLCInitializer.ConnectionString;
            UserID = i_BLCInitializer.UserID;
            OwnerID = i_BLCInitializer.OwnerID;
            Language = i_BLCInitializer.Language;
            Messages_FilePath = i_BLCInitializer.Messages_FilePath;
            _AppContext = new DALC.MSSQL_DALC(_ConnectionString);
            this.oTools = new Tools.Tools();
            // ---------------------

            // ---------------------
            LoadMessages();
            SubscribeToEvents();
            //Initialize_Audit_Mechanism();
            // ---------------------
                      

            #endregion
        }
        #endregion
        #region Subscribe To Events
        public void SubscribeToEvents()
        {
            #region Declaration And Initialization Section.
            this.OnPostEvent_Edit_User += BLC_OnPostEvent_Edit_User;
            this.OnPostEvent_Edit_Answer += BLC_OnPostEvent_Edit_Answer;

            this.OnPostEvent_Edit_Question += BLC_OnPostEvent_Edit_Question;
            this.OnPreEvent_Edit_Question += BLC_OnPreEvent_Edit_Question;

            this.OnPreEvent_Edit_User += BLC_OnPreEvent_Edit_User;
            this.OnPreEvent_Edit_Teacher += BLC_OnPreEvent_Edit_Teacher;
            this.OnPreEvent_Edit_Student += BLC_OnPreEvent_Edit_Student;

            this.OnPostEvent_Get_Question_By_OWNER_ID += BLC_OnPostEvent_Get_Question_By_OWNER_ID;
            #endregion
            #region Body Section.
            #endregion
        }

        private void BLC_OnPostEvent_Edit_User(User i_User, Enum_EditMode i_Enum_EditMode)
        {   

            
            Tools.Tools oTools = new Tools.Tools();
                Teacher i_Teacher = new Teacher();
                Student i_Student = new Student();


            if (i_User.USER_TYPE_CODE_ID == 3)
            {
                oTools.SetPropertiesDefaultValue(i_Student);

                i_Student.USER_ID = i_User.USER_ID;
                i_Student.STUDENT_ID = -1;
                i_Student.USER_TYPE_CODE_ID = i_User.USER_TYPE_CODE_ID;
                i_Student.IS_BLOCKED = false;
                this.Edit_Student(i_Student);
            }
             if (i_User.USER_TYPE_CODE_ID == 2)
            {
                oTools.SetPropertiesDefaultValue(i_Teacher);
                i_Teacher.TEACHER_ID = -1;
                i_Teacher.OWNER_ID = 1;
                i_Teacher.USER_ID = i_User.USER_ID;
                i_Teacher.USER_TYPE_CODE_ID = i_User.USER_TYPE_CODE_ID;
                i_Teacher.IS_BLOCKED = false;
                i_Teacher.IS_VALID = true;
                i_Teacher.CATEGORY_ID = i_User.IF_USER_TEACHER_ID;

                this.Edit_Teacher(i_Teacher);
            }


        }

        private void BLC_OnPostEvent_Get_Question_By_OWNER_ID(List<Question> i_Result, Params_Get_Question_By_OWNER_ID i_Params_Get_Question_By_OWNER_ID)
        {


            if (i_Result != null)
            {

                foreach (Question item in i_Result)
                { 
                   Params_Get_Student_By_STUDENT_ID oParams_Get_Student_By_STUDENT_ID = new Params_Get_Student_By_STUDENT_ID();
                   oParams_Get_Student_By_STUDENT_ID.STUDENT_ID  = item.STUDENT_ID;

                      var oStudent = this.Get_Student_By_STUDENT_ID_Adv(oParams_Get_Student_By_STUDENT_ID);
                    item.mystudent = oStudent;
                } 
                
                foreach (Question item in i_Result)
                { 
                   Params_Get_Category_By_CATEGORY_ID oParams_Get_Category_By_CATEGORY_ID = new Params_Get_Category_By_CATEGORY_ID();
                    oParams_Get_Category_By_CATEGORY_ID.CATEGORY_ID  = item.CATEGORY_ID;

                      var oCategory = this.Get_Category_By_CATEGORY_ID_Adv(oParams_Get_Category_By_CATEGORY_ID);
                    item.mycategory = oCategory;
                }



            }


            else
            {

            throw new NotImplementedException();

            }
           
        }




        #endregion
        #region IDisposable Members
        public void Dispose()
        {
            #region Body Section.
            #endregion
        }
        #endregion
        #region LoadMessages
        public void LoadMessages()
        {
            #region Declaration And Initialization Section.
            XElement oRoot = null;
            XElement oLanguage = null;
            #endregion
            #region Body Section.
            this.Messages = new List<Message>();

            if (!string.IsNullOrEmpty(this.Messages_FilePath))
            {
                oRoot = XElement.Load(this.Messages_FilePath);
                if (oRoot != null)
                {
                    switch (Language)
                    {
                        case Enum_Language.English:
                            oLanguage = oRoot.Element("ENGLISH");
                            break;
                        case Enum_Language.Arabic:
                            oLanguage = oRoot.Element("ARABIC");
                            break;
                        default:
                            oLanguage = oRoot.Element("ENGLISH");
                            break;
                    }

                    foreach (var oItem in oLanguage.Elements("MESSAGE"))
                    {
                        this.Messages.Add(new Message() { Code = oItem.Attribute("CODE").Value, Content = oItem.Attribute("CONTENT").Value });
                    }
                }
            }
            #endregion
        }
        #endregion
        #region GetMessageContent
        public string GetMessageContent(Enum_BR_Codes i_BR_Code)
        {
            #region Declaration And Initialization Section.
            string str_ReturnValue = string.Empty;
            #endregion
            #region Body Section.
            var oResult = this.Messages.First(x => x.Code == i_BR_Code.ToString());
            str_ReturnValue = oResult.Content;
            #endregion
            #region Return Section.
            return str_ReturnValue;
            #endregion
        }
        #endregion
        #region GetMessageContent
        public string GetMessageContent(Enum_BR_Codes i_BR_Code, Dictionary<string, string> i_PlaceHolders)
        {
            #region Declaration And Initialization Section.
            string str_ReturnValue = string.Empty;
            #endregion
            #region Body Section.
            var oResult = this.Messages.First(x => x.Code == i_BR_Code.ToString());
            str_ReturnValue = oResult.Content;

            foreach (var oItem in i_PlaceHolders)
            {
                str_ReturnValue = str_ReturnValue.Replace(oItem.Key, oItem.Value);
            }
            #endregion
            #region Return Section.
            return str_ReturnValue;
            #endregion
        }
        #endregion
        #region Events Implementation
        private void BLC_OnPreEvent_Edit_Question(Question i_Question, Enum_EditMode i_Enum_EditMode)
        {
            if (i_Question.DESCRIPTION.Length < 5)
            {
                Console.WriteLine("dreamer");
                throw new BLCException("question should be at least 5 characters MF");

            }
        }

        private void BLC_OnPostEvent_Edit_Question(Question i_Question, Enum_EditMode i_Enum_EditMode)
        {
            if (i_Question.DESCRIPTION.Length < 5)
            {
            throw new NotImplementedException();

            }
        }


        private void BLC_OnPostEvent_Edit_Answer(Answer i_Answer, Enum_EditMode i_Enum_EditMode)
        {

            Params_Get_Question_By_QUESTION_ID oParams_Get_Question_By_QUESTION_ID = new Params_Get_Question_By_QUESTION_ID();
            oParams_Get_Question_By_QUESTION_ID.QUESTION_ID = i_Answer.QUESTION_ID;
            var oQuestion = this.Get_Question_By_QUESTION_ID(oParams_Get_Question_By_QUESTION_ID);

            if (oQuestion != null)
            {
            oQuestion.IS_ANSWERED = true;

            this.Edit_Question(oQuestion);

            }
            else
            {

            throw new Exception("couldnt change question's is_answered to true");
            }
            //Question myQuestion = new Question();
            //oTools.SetPropertiesDefaultValue(oQuestion);

            //oQuestion.QUESTION_ID = i_Answer.QUESTION_ID;
            //oQuestion.CATEGORY_ID = oQuestion.CATEGORY_ID;
            //oQuestion.DESCRIPTION = oQuestion.DESCRIPTION;
            //oQuestion.STUDENT_ID = oQuestion.STUDENT_ID;
            //oQuestion.IS_ANSWERED = true;
            //oQuestion.IS_PUBLIC = oQuestion.IS_PUBLIC;
            //oQuestion.IS_SELF_CLOSED = oQuestion.IS_SELF_CLOSED;
            //oQuestion.OWNER_ID = oQuestion.OWNER_ID;
            //oQuestion.ENTRY_USER_ID = oQuestion.ENTRY_USER_ID;
            //oQuestion.TEACHER_ID = oQuestion.TEACHER_ID;
        }

        private void BLC_OnPreEvent_Edit_Student(Student i_Student, Enum_EditMode i_Enum_EditMode)
        {
        }

        private void BLC_OnPreEvent_Edit_Teacher(Teacher i_Teacher, Enum_EditMode i_Enum_EditMode)
        {
        }

        private void BLC_OnPreEvent_Edit_User(User i_User, Enum_EditMode i_Enum_EditMode)
        {
            if (i_Enum_EditMode == Enum_EditMode.Add)
            {

                #region checks for username
                //Checks if username is available
                var result = _AppContext.Get_User_By_USERNAME(i_User.USERNAME);

                //if username from DB == username coming from interface: do nothing
                if (result.Count != 0)
                {   
                    if (result[0].USERNAME == i_User.USERNAME)
                    {
                        Console.WriteLine("username already Exists");
                        throw new BLCException("username already Exists");
                    }
                    
                }

                //minimum lenght of username
                if (i_User.USERNAME.Length < 3)
                {
                    Console.WriteLine("usernma must be at least 3 characters ");
                    throw new BLCException("usernma must be at least 3 characters ");
                }


                //USERNAME regex (letters and numbers only)
                string usernamePattern = "^[a-zA-Z0-9]+$";
                Regex usernameRg = new Regex(usernamePattern);

                if (usernameRg.Matches(i_User.USERNAME).Count < 1)
                {
                    Console.WriteLine("invalid username, username should only contains letters, numbers");
                    throw new BLCException("invalid username, username should only contains letters, numbers");
                }
                #endregion
                #region checks for password
                //password regex (letters and numbers only)
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasMinimum8Chars = new Regex(@".{8,}");

                var isValidated = hasNumber.IsMatch(i_User.PASSWORD) && hasUpperChar.IsMatch(i_User.PASSWORD) && hasMinimum8Chars.IsMatch(i_User.PASSWORD);

                if (!isValidated)
                {
                    Console.WriteLine("invalid password synatx, password should be at least 8 characters, contains at least one uppercase letter, number and special character");
                    throw new BLCException("invalid password synatx, password should be at least 8 characters, contains at least one uppercase letter, number and special character");
                }
                #endregion
                #region checks for Email
                if (result.Count == 0)
                {
                    var EmailResult = _AppContext.UP_Get_User_By_Email(i_User.EMAIL);
                    Console.WriteLine(EmailResult);

                    if (EmailResult.Count != 0) {
                        throw new BLCException("Email already exists");
                    }
                }
                #endregion



            }






        }
        #endregion
    }
    #endregion
    #region BLCInitializer
    public class BLCInitializer
    {
        #region Properties
        public string ConnectionString { get; set; }
        public long? UserID { get; set; }
        public Int32? OwnerID { get; set; }
        public BLC.Enum_Language Language { get; set; }
        public string Messages_FilePath { get; set; }
        #endregion
    }
    #endregion
    #region Message
    public class Message
    {
        #region Properties
        public string Code { get; set; }
        public string Content { get; set; }
        #endregion
    }
    #endregion
    #region EnvCode Attribute
    #region EnvCode
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Constructor, AllowMultiple = true)]
    public class EnvCode : System.Attribute
    {
        #region Properties
        public BLC.Enum_Environment Environment { get; set; }
        public string MethodName { get; set; }
        #endregion
        #region Constructor
        public EnvCode(BLC.Enum_Environment i_Environment, string i_MethodName)
        {
            #region Body Section.
            Environment = i_Environment;
            MethodName = i_MethodName;
            #endregion
        }
        #endregion
        #region Behavior
        #region GetEnvCode
        public static MethodInfo GetEnvCode(Params_GetEnvCode i_Params_GetEnvCode)
        {
            #region Declaration And Initialization Section.
            MethodInfo[] oMethods = null;
            MethodInfo oMethodInfo = null;
            object[] oAttributes = null;
            EnvCode oEnvCode = null;

            bool Is_AlreadyFound = false;
            MethodInfo oMethodInfo_ReturnValue = null;
            #endregion
            #region Body Section.

            // ----------------------
            oMethods = i_Params_GetEnvCode.My_Type.GetMethods();
            // ----------------------

            // ----------------------
            for (int i = 0; i < oMethods.GetLength(0); i++)
            {
                // ----------------------
                if (Is_AlreadyFound == true)
                {
                    break;
                }
                // ----------------------

                // ----------------------
                oMethodInfo = oMethods[i];
                oAttributes = oMethodInfo.GetCustomAttributes(true);
                // ----------------------

                // ----------------------
                foreach (Attribute oAttribute in oAttributes)
                {
                    if (oAttribute is EnvCode)
                    {
                        oEnvCode = oAttribute as EnvCode;
                        if (oEnvCode != null)
                        {
                            if ((oEnvCode.Environment == i_Params_GetEnvCode.My_Environment) && (oEnvCode.MethodName == i_Params_GetEnvCode.My_MethodName))
                            {
                                oMethodInfo_ReturnValue = oMethodInfo;
                                Is_AlreadyFound = true;
                                break;
                            }
                        }
                    }
                }
                // ----------------------
            }
            // ----------------------
            #endregion
            #region Return Section.
            return oMethodInfo_ReturnValue;
            #endregion
        }
        #endregion
        #endregion
    }
    #endregion
    #region Params_GetEnvCode
    public class Params_GetEnvCode
    {
        #region Properties.
        public System.Type My_Type { get; set; }
        public BLC.Enum_Environment My_Environment { get; set; }
        public string My_MethodName { get; set; }
        #endregion
    }
    #endregion
    #endregion
}


