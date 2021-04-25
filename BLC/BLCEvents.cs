using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using BLC;
namespace BLC
{
public partial class BLC
{

#region Enum_API_Method
public enum Enum_API_Method
{
Get_Answer_By_OWNER_ID,
Edit_Answer,
Get_Answer_By_Criteria,
Delete_Answer,
Get_Answer_By_STUDENT_ID_List,
Edit_Question,
Get_Question_By_CATEGORY_ID_List,
Get_Question_By_STUDENT_ID_List,
Get_Question_By_QUESTION_ID,
Delete_Question,
Get_Question_By_Criteria,
Get_Question_By_OWNER_ID,
Edit_Category_favorite,
Get_Category_By_OWNER_ID,
Get_Student_By_OWNER_ID,
Get_Teacher_By_CATEGORY_ID_List,
Get_Teacher_By_OWNER_ID,
Edit_Teacher_favorite,
Get_User_By_OWNER_ID,
Delete_User,
Edit_User
}
#endregion

#region Prepare_BLCInitializer
public BLCInitializer Prepare_BLCInitializer(string i_Ticket, Enum_API_Method i_Enum_API_Method)
{
#region Declaration And Initialization Section.
BLCInitializer oBLCInitializer = new BLCInitializer();
BLC oBLC_Default = new BLC();
string str_CUSTOM_BLC_INIT = string.Empty;
#endregion
#region Body Section.
if (this.OnPreEvent_BLC_Init != null)
{
oBLCInitializer = this.OnPreEvent_BLC_Init(i_Ticket, i_Enum_API_Method);
return oBLCInitializer;
}
else
{
oBLCInitializer.UserID = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
}
#endregion
#region Return Section.
return oBLCInitializer;
#endregion
}
#endregion

#region General Pre/Post events
public delegate void PreEvent_Handler_General(string i_MethodName);
public delegate void PostEvent_Handler_General(string i_MethodName);
public event PreEvent_Handler_General OnPreEvent_General;
public event PostEvent_Handler_General OnPostEvent_General;
#endregion
#region General Pre/Post BLC_Init
public delegate BLCInitializer PreEvent_Handler_BLC_Init(string i_Ticket, Enum_API_Method i_Enum_API_Method);
public delegate BLCInitializer PostEvent_Handler_BLC_Init(string i_Ticket, Enum_API_Method i_Enum_API_Method);
public event PreEvent_Handler_BLC_Init OnPreEvent_BLC_Init;
public event PostEvent_Handler_BLC_Init OnPostEvent_BLC_Init;
#endregion
public  delegate void PreEvent_Handler_Edit_Answer(Answer i_Answer,Enum_EditMode i_Enum_EditMode);
public  delegate void  PostEvent_Handler_Edit_Answer(Answer i_Answer,Enum_EditMode i_Enum_EditMode);
public event PreEvent_Handler_Edit_Answer OnPreEvent_Edit_Answer;
public event PostEvent_Handler_Edit_Answer OnPostEvent_Edit_Answer;
public  delegate void PreEvent_Handler_Edit_User(User i_User,Enum_EditMode i_Enum_EditMode);
public  delegate void  PostEvent_Handler_Edit_User(User i_User,Enum_EditMode i_Enum_EditMode);
public event PreEvent_Handler_Edit_User OnPreEvent_Edit_User;
public event PostEvent_Handler_Edit_User OnPostEvent_Edit_User;
public  delegate void PreEvent_Handler_Edit_Question(Question i_Question,Enum_EditMode i_Enum_EditMode);
public  delegate void  PostEvent_Handler_Edit_Question(Question i_Question,Enum_EditMode i_Enum_EditMode);
public event PreEvent_Handler_Edit_Question OnPreEvent_Edit_Question;
public event PostEvent_Handler_Edit_Question OnPostEvent_Edit_Question;
public  delegate void PreEvent_Handler_Edit_Student(Student i_Student,Enum_EditMode i_Enum_EditMode);
public  delegate void  PostEvent_Handler_Edit_Student(Student i_Student,Enum_EditMode i_Enum_EditMode);
public event PreEvent_Handler_Edit_Student OnPreEvent_Edit_Student;
public event PostEvent_Handler_Edit_Student OnPostEvent_Edit_Student;
public  delegate void PreEvent_Handler_Edit_Teacher(Teacher i_Teacher,Enum_EditMode i_Enum_EditMode);
public  delegate void  PostEvent_Handler_Edit_Teacher(Teacher i_Teacher,Enum_EditMode i_Enum_EditMode);
public event PreEvent_Handler_Edit_Teacher OnPreEvent_Edit_Teacher;
public event PostEvent_Handler_Edit_Teacher OnPostEvent_Edit_Teacher;
}
}
