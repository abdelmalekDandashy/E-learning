using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BLC;
[Route("api/[controller]")]
[ApiController]
public partial class DataController : ControllerBase
{
#region Members
#endregion
#region Extract_Ticket
private string Extract_Ticket()
{
#region Declaration And Initialization Section.
string str_Ticket = string.Empty;
#endregion
if(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null)
{
str_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
#region Return Section.
return str_Ticket;
#endregion
}
#endregion
#region IsValidWebTicket
private bool IsValidWebTicket(string i_Input)
{
#region Declaration And Initialization Section.
bool Is_Valid = false;
BLCInitializer oBLCInitializer = new BLCInitializer();
#endregion
#region Body Section.
BLC.BLC oBLC_Default = new BLC.BLC();
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
Is_Valid = oBLC.IsValidTicket(i_Input);
}
#endregion
#region Return Section.
return Is_Valid;
#endregion
}
#endregion
#region Delete_Answer
[HttpPost]
[Route("Delete_Answer")]
public Result_Delete_Answer Delete_Answer(Params_Delete_Answer i_Params_Delete_Answer)
{
#region Declaration And Initialization Section.
string i_Ticket = string.Empty;
Result_Delete_Answer oResult_Delete_Answer = new Result_Delete_Answer();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oBLC.Delete_Answer(i_Params_Delete_Answer);
oResult_Delete_Answer.My_Params_Delete_Answer = i_Params_Delete_Answer;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Delete_Answer.ExceptionMsg = string.Format("Delete_Answer : {0}", ex.Message);
}
else
{
oResult_Delete_Answer.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Delete_Answer;
#endregion
}
#endregion
#region Delete_Category
[HttpPost]
[Route("Delete_Category")]
public Result_Delete_Category Delete_Category(Params_Delete_Category i_Params_Delete_Category)
{
#region Declaration And Initialization Section.
string i_Ticket = string.Empty;
Result_Delete_Category oResult_Delete_Category = new Result_Delete_Category();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oBLC.Delete_Category(i_Params_Delete_Category);
oResult_Delete_Category.My_Params_Delete_Category = i_Params_Delete_Category;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Delete_Category.ExceptionMsg = string.Format("Delete_Category : {0}", ex.Message);
}
else
{
oResult_Delete_Category.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Delete_Category;
#endregion
}
#endregion
#region Delete_Question
[HttpPost]
[Route("Delete_Question")]
public Result_Delete_Question Delete_Question(Params_Delete_Question i_Params_Delete_Question)
{
#region Declaration And Initialization Section.
string i_Ticket = string.Empty;
Result_Delete_Question oResult_Delete_Question = new Result_Delete_Question();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oBLC.Delete_Question(i_Params_Delete_Question);
oResult_Delete_Question.My_Params_Delete_Question = i_Params_Delete_Question;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Delete_Question.ExceptionMsg = string.Format("Delete_Question : {0}", ex.Message);
}
else
{
oResult_Delete_Question.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Delete_Question;
#endregion
}
#endregion
#region Delete_Student
[HttpPost]
[Route("Delete_Student")]
public Result_Delete_Student Delete_Student(Params_Delete_Student i_Params_Delete_Student)
{
#region Declaration And Initialization Section.
string i_Ticket = string.Empty;
Result_Delete_Student oResult_Delete_Student = new Result_Delete_Student();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oBLC.Delete_Student(i_Params_Delete_Student);
oResult_Delete_Student.My_Params_Delete_Student = i_Params_Delete_Student;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Delete_Student.ExceptionMsg = string.Format("Delete_Student : {0}", ex.Message);
}
else
{
oResult_Delete_Student.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Delete_Student;
#endregion
}
#endregion
#region Delete_Teacher
[HttpPost]
[Route("Delete_Teacher")]
public Result_Delete_Teacher Delete_Teacher(Params_Delete_Teacher i_Params_Delete_Teacher)
{
#region Declaration And Initialization Section.
string i_Ticket = string.Empty;
Result_Delete_Teacher oResult_Delete_Teacher = new Result_Delete_Teacher();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oBLC.Delete_Teacher(i_Params_Delete_Teacher);
oResult_Delete_Teacher.My_Params_Delete_Teacher = i_Params_Delete_Teacher;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Delete_Teacher.ExceptionMsg = string.Format("Delete_Teacher : {0}", ex.Message);
}
else
{
oResult_Delete_Teacher.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Delete_Teacher;
#endregion
}
#endregion
#region Edit_Answer
[HttpPost]
[Route("Edit_Answer")]
public Result_Edit_Answer Edit_Answer(Answer i_Answer)
{
#region Declaration And Initialization Section.
string i_Ticket = string.Empty;
Result_Edit_Answer oResult_Edit_Answer = new Result_Edit_Answer();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oBLC.Edit_Answer(i_Answer);
oResult_Edit_Answer.My_Answer = i_Answer;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Edit_Answer.ExceptionMsg = string.Format("Edit_Answer : {0}", ex.Message);
}
else
{
oResult_Edit_Answer.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Edit_Answer;
#endregion
}
#endregion
#region Edit_Category
[HttpPost]
[Route("Edit_Category")]
public Result_Edit_Category Edit_Category(Category i_Category)
{
#region Declaration And Initialization Section.
string i_Ticket = string.Empty;
Result_Edit_Category oResult_Edit_Category = new Result_Edit_Category();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oBLC.Edit_Category(i_Category);
oResult_Edit_Category.My_Category = i_Category;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Edit_Category.ExceptionMsg = string.Format("Edit_Category : {0}", ex.Message);
}
else
{
oResult_Edit_Category.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Edit_Category;
#endregion
}
#endregion
#region Edit_Category_favorite
[HttpPost]
[Route("Edit_Category_favorite")]
public Result_Edit_Category_favorite Edit_Category_favorite(Category_favorite i_Category_favorite)
{
#region Declaration And Initialization Section.
string i_Ticket = string.Empty;
Result_Edit_Category_favorite oResult_Edit_Category_favorite = new Result_Edit_Category_favorite();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oBLC.Edit_Category_favorite(i_Category_favorite);
oResult_Edit_Category_favorite.My_Category_favorite = i_Category_favorite;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Edit_Category_favorite.ExceptionMsg = string.Format("Edit_Category_favorite : {0}", ex.Message);
}
else
{
oResult_Edit_Category_favorite.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Edit_Category_favorite;
#endregion
}
#endregion
#region Edit_Question
[HttpPost]
[Route("Edit_Question")]
public Result_Edit_Question Edit_Question(Question i_Question)
{
#region Declaration And Initialization Section.
string i_Ticket = string.Empty;
Result_Edit_Question oResult_Edit_Question = new Result_Edit_Question();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oBLC.Edit_Question(i_Question);
oResult_Edit_Question.My_Question = i_Question;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Edit_Question.ExceptionMsg = string.Format("Edit_Question : {0}", ex.Message);
}
else
{
oResult_Edit_Question.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Edit_Question;
#endregion
}
#endregion
#region Edit_Student
[HttpPost]
[Route("Edit_Student")]
public Result_Edit_Student Edit_Student(Student i_Student)
{
#region Declaration And Initialization Section.
string i_Ticket = string.Empty;
Result_Edit_Student oResult_Edit_Student = new Result_Edit_Student();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oBLC.Edit_Student(i_Student);
oResult_Edit_Student.My_Student = i_Student;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Edit_Student.ExceptionMsg = string.Format("Edit_Student : {0}", ex.Message);
}
else
{
oResult_Edit_Student.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Edit_Student;
#endregion
}
#endregion
#region Edit_Teacher
[HttpPost]
[Route("Edit_Teacher")]
public Result_Edit_Teacher Edit_Teacher(Teacher i_Teacher)
{
#region Declaration And Initialization Section.
string i_Ticket = string.Empty;
Result_Edit_Teacher oResult_Edit_Teacher = new Result_Edit_Teacher();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oBLC.Edit_Teacher(i_Teacher);
oResult_Edit_Teacher.My_Teacher = i_Teacher;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Edit_Teacher.ExceptionMsg = string.Format("Edit_Teacher : {0}", ex.Message);
}
else
{
oResult_Edit_Teacher.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Edit_Teacher;
#endregion
}
#endregion
#region Edit_Teacher_favorite
[HttpPost]
[Route("Edit_Teacher_favorite")]
public Result_Edit_Teacher_favorite Edit_Teacher_favorite(Teacher_favorite i_Teacher_favorite)
{
#region Declaration And Initialization Section.
string i_Ticket = string.Empty;
Result_Edit_Teacher_favorite oResult_Edit_Teacher_favorite = new Result_Edit_Teacher_favorite();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oBLC.Edit_Teacher_favorite(i_Teacher_favorite);
oResult_Edit_Teacher_favorite.My_Teacher_favorite = i_Teacher_favorite;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Edit_Teacher_favorite.ExceptionMsg = string.Format("Edit_Teacher_favorite : {0}", ex.Message);
}
else
{
oResult_Edit_Teacher_favorite.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Edit_Teacher_favorite;
#endregion
}
#endregion
#region Get_Answer_By_Criteria
[HttpPost]
[Route("Get_Answer_By_Criteria")]
public Result_Get_Answer_By_Criteria Get_Answer_By_Criteria(Params_Get_Answer_By_Criteria i_Params_Get_Answer_By_Criteria)
{
#region Declaration And Initialization Section.
List<Answer>  oReturnValue = new List<Answer> ();
string i_Ticket = string.Empty;
Result_Get_Answer_By_Criteria oResult_Get_Answer_By_Criteria = new Result_Get_Answer_By_Criteria();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oReturnValue = oBLC.Get_Answer_By_Criteria(i_Params_Get_Answer_By_Criteria);
oResult_Get_Answer_By_Criteria.My_Result = oReturnValue;
oResult_Get_Answer_By_Criteria.My_Params_Get_Answer_By_Criteria = i_Params_Get_Answer_By_Criteria;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Get_Answer_By_Criteria.ExceptionMsg = string.Format("Get_Answer_By_Criteria : {0}", ex.Message);
}
else
{
oResult_Get_Answer_By_Criteria.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Get_Answer_By_Criteria;
#endregion
}
#endregion
#region Get_Answer_By_OWNER_ID
[HttpPost]
[Route("Get_Answer_By_OWNER_ID")]
public Result_Get_Answer_By_OWNER_ID Get_Answer_By_OWNER_ID(Params_Get_Answer_By_OWNER_ID i_Params_Get_Answer_By_OWNER_ID)
{
#region Declaration And Initialization Section.
List<Answer>  oReturnValue = new List<Answer> ();
string i_Ticket = string.Empty;
Result_Get_Answer_By_OWNER_ID oResult_Get_Answer_By_OWNER_ID = new Result_Get_Answer_By_OWNER_ID();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oReturnValue = oBLC.Get_Answer_By_OWNER_ID(i_Params_Get_Answer_By_OWNER_ID);
oResult_Get_Answer_By_OWNER_ID.My_Result = oReturnValue;
oResult_Get_Answer_By_OWNER_ID.My_Params_Get_Answer_By_OWNER_ID = i_Params_Get_Answer_By_OWNER_ID;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Get_Answer_By_OWNER_ID.ExceptionMsg = string.Format("Get_Answer_By_OWNER_ID : {0}", ex.Message);
}
else
{
oResult_Get_Answer_By_OWNER_ID.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Get_Answer_By_OWNER_ID;
#endregion
}
#endregion
#region Get_Answer_By_OWNER_ID_Adv
[HttpPost]
[Route("Get_Answer_By_OWNER_ID_Adv")]
public Result_Get_Answer_By_OWNER_ID_Adv Get_Answer_By_OWNER_ID_Adv(Params_Get_Answer_By_OWNER_ID i_Params_Get_Answer_By_OWNER_ID)
{
#region Declaration And Initialization Section.
List<Answer>  oReturnValue = new List<Answer> ();
string i_Ticket = string.Empty;
Result_Get_Answer_By_OWNER_ID_Adv oResult_Get_Answer_By_OWNER_ID_Adv = new Result_Get_Answer_By_OWNER_ID_Adv();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oReturnValue = oBLC.Get_Answer_By_OWNER_ID_Adv(i_Params_Get_Answer_By_OWNER_ID);
oResult_Get_Answer_By_OWNER_ID_Adv.My_Result = oReturnValue;
oResult_Get_Answer_By_OWNER_ID_Adv.My_Params_Get_Answer_By_OWNER_ID = i_Params_Get_Answer_By_OWNER_ID;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Get_Answer_By_OWNER_ID_Adv.ExceptionMsg = string.Format("Get_Answer_By_OWNER_ID_Adv : {0}", ex.Message);
}
else
{
oResult_Get_Answer_By_OWNER_ID_Adv.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Get_Answer_By_OWNER_ID_Adv;
#endregion
}
#endregion
#region Get_Answer_By_STUDENT_ID_List
[HttpPost]
[Route("Get_Answer_By_STUDENT_ID_List")]
public Result_Get_Answer_By_STUDENT_ID_List Get_Answer_By_STUDENT_ID_List(Params_Get_Answer_By_STUDENT_ID_List i_Params_Get_Answer_By_STUDENT_ID_List)
{
#region Declaration And Initialization Section.
List<Answer>  oReturnValue = new List<Answer> ();
string i_Ticket = string.Empty;
Result_Get_Answer_By_STUDENT_ID_List oResult_Get_Answer_By_STUDENT_ID_List = new Result_Get_Answer_By_STUDENT_ID_List();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oReturnValue = oBLC.Get_Answer_By_STUDENT_ID_List(i_Params_Get_Answer_By_STUDENT_ID_List);
oResult_Get_Answer_By_STUDENT_ID_List.My_Result = oReturnValue;
oResult_Get_Answer_By_STUDENT_ID_List.My_Params_Get_Answer_By_STUDENT_ID_List = i_Params_Get_Answer_By_STUDENT_ID_List;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Get_Answer_By_STUDENT_ID_List.ExceptionMsg = string.Format("Get_Answer_By_STUDENT_ID_List : {0}", ex.Message);
}
else
{
oResult_Get_Answer_By_STUDENT_ID_List.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Get_Answer_By_STUDENT_ID_List;
#endregion
}
#endregion
#region Get_Category_By_OWNER_ID
[HttpPost]
[Route("Get_Category_By_OWNER_ID")]
public Result_Get_Category_By_OWNER_ID Get_Category_By_OWNER_ID(Params_Get_Category_By_OWNER_ID i_Params_Get_Category_By_OWNER_ID)
{
#region Declaration And Initialization Section.
List<Category>  oReturnValue = new List<Category> ();
string i_Ticket = string.Empty;
Result_Get_Category_By_OWNER_ID oResult_Get_Category_By_OWNER_ID = new Result_Get_Category_By_OWNER_ID();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oReturnValue = oBLC.Get_Category_By_OWNER_ID(i_Params_Get_Category_By_OWNER_ID);
oResult_Get_Category_By_OWNER_ID.My_Result = oReturnValue;
oResult_Get_Category_By_OWNER_ID.My_Params_Get_Category_By_OWNER_ID = i_Params_Get_Category_By_OWNER_ID;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Get_Category_By_OWNER_ID.ExceptionMsg = string.Format("Get_Category_By_OWNER_ID : {0}", ex.Message);
}
else
{
oResult_Get_Category_By_OWNER_ID.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Get_Category_By_OWNER_ID;
#endregion
}
#endregion
#region Get_Question_By_CATEGORY_ID_List
[HttpPost]
[Route("Get_Question_By_CATEGORY_ID_List")]
public Result_Get_Question_By_CATEGORY_ID_List Get_Question_By_CATEGORY_ID_List(Params_Get_Question_By_CATEGORY_ID_List i_Params_Get_Question_By_CATEGORY_ID_List)
{
#region Declaration And Initialization Section.
List<Question>  oReturnValue = new List<Question> ();
string i_Ticket = string.Empty;
Result_Get_Question_By_CATEGORY_ID_List oResult_Get_Question_By_CATEGORY_ID_List = new Result_Get_Question_By_CATEGORY_ID_List();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oReturnValue = oBLC.Get_Question_By_CATEGORY_ID_List(i_Params_Get_Question_By_CATEGORY_ID_List);
oResult_Get_Question_By_CATEGORY_ID_List.My_Result = oReturnValue;
oResult_Get_Question_By_CATEGORY_ID_List.My_Params_Get_Question_By_CATEGORY_ID_List = i_Params_Get_Question_By_CATEGORY_ID_List;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Get_Question_By_CATEGORY_ID_List.ExceptionMsg = string.Format("Get_Question_By_CATEGORY_ID_List : {0}", ex.Message);
}
else
{
oResult_Get_Question_By_CATEGORY_ID_List.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Get_Question_By_CATEGORY_ID_List;
#endregion
}
#endregion
#region Get_Question_By_Criteria
[HttpPost]
[Route("Get_Question_By_Criteria")]
public Result_Get_Question_By_Criteria Get_Question_By_Criteria(Params_Get_Question_By_Criteria i_Params_Get_Question_By_Criteria)
{
#region Declaration And Initialization Section.
List<Question>  oReturnValue = new List<Question> ();
string i_Ticket = string.Empty;
Result_Get_Question_By_Criteria oResult_Get_Question_By_Criteria = new Result_Get_Question_By_Criteria();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oReturnValue = oBLC.Get_Question_By_Criteria(i_Params_Get_Question_By_Criteria);
oResult_Get_Question_By_Criteria.My_Result = oReturnValue;
oResult_Get_Question_By_Criteria.My_Params_Get_Question_By_Criteria = i_Params_Get_Question_By_Criteria;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Get_Question_By_Criteria.ExceptionMsg = string.Format("Get_Question_By_Criteria : {0}", ex.Message);
}
else
{
oResult_Get_Question_By_Criteria.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Get_Question_By_Criteria;
#endregion
}
#endregion
#region Get_Question_By_OWNER_ID
[HttpPost]
[Route("Get_Question_By_OWNER_ID")]
public Result_Get_Question_By_OWNER_ID Get_Question_By_OWNER_ID(Params_Get_Question_By_OWNER_ID i_Params_Get_Question_By_OWNER_ID)
{
#region Declaration And Initialization Section.
List<Question>  oReturnValue = new List<Question> ();
string i_Ticket = string.Empty;
Result_Get_Question_By_OWNER_ID oResult_Get_Question_By_OWNER_ID = new Result_Get_Question_By_OWNER_ID();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oReturnValue = oBLC.Get_Question_By_OWNER_ID(i_Params_Get_Question_By_OWNER_ID);
oResult_Get_Question_By_OWNER_ID.My_Result = oReturnValue;
oResult_Get_Question_By_OWNER_ID.My_Params_Get_Question_By_OWNER_ID = i_Params_Get_Question_By_OWNER_ID;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Get_Question_By_OWNER_ID.ExceptionMsg = string.Format("Get_Question_By_OWNER_ID : {0}", ex.Message);
}
else
{
oResult_Get_Question_By_OWNER_ID.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Get_Question_By_OWNER_ID;
#endregion
}
#endregion
#region Get_Question_By_OWNER_ID_Adv
[HttpPost]
[Route("Get_Question_By_OWNER_ID_Adv")]
public Result_Get_Question_By_OWNER_ID_Adv Get_Question_By_OWNER_ID_Adv(Params_Get_Question_By_OWNER_ID i_Params_Get_Question_By_OWNER_ID)
{
#region Declaration And Initialization Section.
List<Question>  oReturnValue = new List<Question> ();
string i_Ticket = string.Empty;
Result_Get_Question_By_OWNER_ID_Adv oResult_Get_Question_By_OWNER_ID_Adv = new Result_Get_Question_By_OWNER_ID_Adv();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oReturnValue = oBLC.Get_Question_By_OWNER_ID_Adv(i_Params_Get_Question_By_OWNER_ID);
oResult_Get_Question_By_OWNER_ID_Adv.My_Result = oReturnValue;
oResult_Get_Question_By_OWNER_ID_Adv.My_Params_Get_Question_By_OWNER_ID = i_Params_Get_Question_By_OWNER_ID;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Get_Question_By_OWNER_ID_Adv.ExceptionMsg = string.Format("Get_Question_By_OWNER_ID_Adv : {0}", ex.Message);
}
else
{
oResult_Get_Question_By_OWNER_ID_Adv.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Get_Question_By_OWNER_ID_Adv;
#endregion
}
#endregion
#region Get_Question_By_QUESTION_ID
[HttpPost]
[Route("Get_Question_By_QUESTION_ID")]
public Result_Get_Question_By_QUESTION_ID Get_Question_By_QUESTION_ID(Params_Get_Question_By_QUESTION_ID i_Params_Get_Question_By_QUESTION_ID)
{
#region Declaration And Initialization Section.
Question oReturnValue = new Question();
string i_Ticket = string.Empty;
Result_Get_Question_By_QUESTION_ID oResult_Get_Question_By_QUESTION_ID = new Result_Get_Question_By_QUESTION_ID();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oReturnValue = oBLC.Get_Question_By_QUESTION_ID(i_Params_Get_Question_By_QUESTION_ID);
oResult_Get_Question_By_QUESTION_ID.My_Result = oReturnValue;
oResult_Get_Question_By_QUESTION_ID.My_Params_Get_Question_By_QUESTION_ID = i_Params_Get_Question_By_QUESTION_ID;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Get_Question_By_QUESTION_ID.ExceptionMsg = string.Format("Get_Question_By_QUESTION_ID : {0}", ex.Message);
}
else
{
oResult_Get_Question_By_QUESTION_ID.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Get_Question_By_QUESTION_ID;
#endregion
}
#endregion
#region Get_Question_By_STUDENT_ID_List
[HttpPost]
[Route("Get_Question_By_STUDENT_ID_List")]
public Result_Get_Question_By_STUDENT_ID_List Get_Question_By_STUDENT_ID_List(Params_Get_Question_By_STUDENT_ID_List i_Params_Get_Question_By_STUDENT_ID_List)
{
#region Declaration And Initialization Section.
List<Question>  oReturnValue = new List<Question> ();
string i_Ticket = string.Empty;
Result_Get_Question_By_STUDENT_ID_List oResult_Get_Question_By_STUDENT_ID_List = new Result_Get_Question_By_STUDENT_ID_List();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oReturnValue = oBLC.Get_Question_By_STUDENT_ID_List(i_Params_Get_Question_By_STUDENT_ID_List);
oResult_Get_Question_By_STUDENT_ID_List.My_Result = oReturnValue;
oResult_Get_Question_By_STUDENT_ID_List.My_Params_Get_Question_By_STUDENT_ID_List = i_Params_Get_Question_By_STUDENT_ID_List;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Get_Question_By_STUDENT_ID_List.ExceptionMsg = string.Format("Get_Question_By_STUDENT_ID_List : {0}", ex.Message);
}
else
{
oResult_Get_Question_By_STUDENT_ID_List.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Get_Question_By_STUDENT_ID_List;
#endregion
}
#endregion
#region Get_Student_By_OWNER_ID
[HttpPost]
[Route("Get_Student_By_OWNER_ID")]
public Result_Get_Student_By_OWNER_ID Get_Student_By_OWNER_ID(Params_Get_Student_By_OWNER_ID i_Params_Get_Student_By_OWNER_ID)
{
#region Declaration And Initialization Section.
List<Student>  oReturnValue = new List<Student> ();
string i_Ticket = string.Empty;
Result_Get_Student_By_OWNER_ID oResult_Get_Student_By_OWNER_ID = new Result_Get_Student_By_OWNER_ID();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oReturnValue = oBLC.Get_Student_By_OWNER_ID(i_Params_Get_Student_By_OWNER_ID);
oResult_Get_Student_By_OWNER_ID.My_Result = oReturnValue;
oResult_Get_Student_By_OWNER_ID.My_Params_Get_Student_By_OWNER_ID = i_Params_Get_Student_By_OWNER_ID;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Get_Student_By_OWNER_ID.ExceptionMsg = string.Format("Get_Student_By_OWNER_ID : {0}", ex.Message);
}
else
{
oResult_Get_Student_By_OWNER_ID.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Get_Student_By_OWNER_ID;
#endregion
}
#endregion
#region Get_Teacher_By_CATEGORY_ID_List
[HttpPost]
[Route("Get_Teacher_By_CATEGORY_ID_List")]
public Result_Get_Teacher_By_CATEGORY_ID_List Get_Teacher_By_CATEGORY_ID_List(Params_Get_Teacher_By_CATEGORY_ID_List i_Params_Get_Teacher_By_CATEGORY_ID_List)
{
#region Declaration And Initialization Section.
List<Teacher>  oReturnValue = new List<Teacher> ();
string i_Ticket = string.Empty;
Result_Get_Teacher_By_CATEGORY_ID_List oResult_Get_Teacher_By_CATEGORY_ID_List = new Result_Get_Teacher_By_CATEGORY_ID_List();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oReturnValue = oBLC.Get_Teacher_By_CATEGORY_ID_List(i_Params_Get_Teacher_By_CATEGORY_ID_List);
oResult_Get_Teacher_By_CATEGORY_ID_List.My_Result = oReturnValue;
oResult_Get_Teacher_By_CATEGORY_ID_List.My_Params_Get_Teacher_By_CATEGORY_ID_List = i_Params_Get_Teacher_By_CATEGORY_ID_List;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Get_Teacher_By_CATEGORY_ID_List.ExceptionMsg = string.Format("Get_Teacher_By_CATEGORY_ID_List : {0}", ex.Message);
}
else
{
oResult_Get_Teacher_By_CATEGORY_ID_List.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Get_Teacher_By_CATEGORY_ID_List;
#endregion
}
#endregion
#region Get_Teacher_By_OWNER_ID
[HttpPost]
[Route("Get_Teacher_By_OWNER_ID")]
public Result_Get_Teacher_By_OWNER_ID Get_Teacher_By_OWNER_ID(Params_Get_Teacher_By_OWNER_ID i_Params_Get_Teacher_By_OWNER_ID)
{
#region Declaration And Initialization Section.
List<Teacher>  oReturnValue = new List<Teacher> ();
string i_Ticket = string.Empty;
Result_Get_Teacher_By_OWNER_ID oResult_Get_Teacher_By_OWNER_ID = new Result_Get_Teacher_By_OWNER_ID();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oReturnValue = oBLC.Get_Teacher_By_OWNER_ID(i_Params_Get_Teacher_By_OWNER_ID);
oResult_Get_Teacher_By_OWNER_ID.My_Result = oReturnValue;
oResult_Get_Teacher_By_OWNER_ID.My_Params_Get_Teacher_By_OWNER_ID = i_Params_Get_Teacher_By_OWNER_ID;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Get_Teacher_By_OWNER_ID.ExceptionMsg = string.Format("Get_Teacher_By_OWNER_ID : {0}", ex.Message);
}
else
{
oResult_Get_Teacher_By_OWNER_ID.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Get_Teacher_By_OWNER_ID;
#endregion
}
#endregion
}

#region Action_Result
public partial class Action_Result
{
#region Properties.
public string ExceptionMsg { get; set; }
#endregion
#region Constructor
public Action_Result()
{
#region Declaration And Initialization Section.
#endregion
#region Body Section.
this.ExceptionMsg = string.Empty;
#endregion
}
#endregion
}
#endregion
#region Result_Delete_Answer
public partial class Result_Delete_Answer : Action_Result
{
#region Properties.
public Params_Delete_Answer My_Params_Delete_Answer { get; set; }
#endregion
}
#endregion
#region Result_Delete_Category
public partial class Result_Delete_Category : Action_Result
{
#region Properties.
public Params_Delete_Category My_Params_Delete_Category { get; set; }
#endregion
}
#endregion
#region Result_Delete_Question
public partial class Result_Delete_Question : Action_Result
{
#region Properties.
public Params_Delete_Question My_Params_Delete_Question { get; set; }
#endregion
}
#endregion
#region Result_Delete_Student
public partial class Result_Delete_Student : Action_Result
{
#region Properties.
public Params_Delete_Student My_Params_Delete_Student { get; set; }
#endregion
}
#endregion
#region Result_Delete_Teacher
public partial class Result_Delete_Teacher : Action_Result
{
#region Properties.
public Params_Delete_Teacher My_Params_Delete_Teacher { get; set; }
#endregion
}
#endregion
#region Result_Edit_Answer
public partial class Result_Edit_Answer : Action_Result
{
#region Properties.
public Answer My_Answer { get; set; }
#endregion
}
#endregion
#region Result_Edit_Category
public partial class Result_Edit_Category : Action_Result
{
#region Properties.
public Category My_Category { get; set; }
#endregion
}
#endregion
#region Result_Edit_Category_favorite
public partial class Result_Edit_Category_favorite : Action_Result
{
#region Properties.
public Category_favorite My_Category_favorite { get; set; }
#endregion
}
#endregion
#region Result_Edit_Question
public partial class Result_Edit_Question : Action_Result
{
#region Properties.
public Question My_Question { get; set; }
#endregion
}
#endregion
#region Result_Edit_Student
public partial class Result_Edit_Student : Action_Result
{
#region Properties.
public Student My_Student { get; set; }
#endregion
}
#endregion
#region Result_Edit_Teacher
public partial class Result_Edit_Teacher : Action_Result
{
#region Properties.
public Teacher My_Teacher { get; set; }
#endregion
}
#endregion
#region Result_Edit_Teacher_favorite
public partial class Result_Edit_Teacher_favorite : Action_Result
{
#region Properties.
public Teacher_favorite My_Teacher_favorite { get; set; }
#endregion
}
#endregion
#region Result_Get_Answer_By_Criteria
public partial class Result_Get_Answer_By_Criteria : Action_Result
{
#region Properties.
public List<Answer>  My_Result { get; set; }
public Params_Get_Answer_By_Criteria My_Params_Get_Answer_By_Criteria { get; set; }
#endregion
}
#endregion
#region Result_Get_Answer_By_OWNER_ID
public partial class Result_Get_Answer_By_OWNER_ID : Action_Result
{
#region Properties.
public List<Answer>  My_Result { get; set; }
public Params_Get_Answer_By_OWNER_ID My_Params_Get_Answer_By_OWNER_ID { get; set; }
#endregion
}
#endregion
#region Result_Get_Answer_By_OWNER_ID_Adv
public partial class Result_Get_Answer_By_OWNER_ID_Adv : Action_Result
{
#region Properties.
public List<Answer>  My_Result { get; set; }
public Params_Get_Answer_By_OWNER_ID My_Params_Get_Answer_By_OWNER_ID { get; set; }
#endregion
}
#endregion
#region Result_Get_Answer_By_STUDENT_ID_List
public partial class Result_Get_Answer_By_STUDENT_ID_List : Action_Result
{
#region Properties.
public List<Answer>  My_Result { get; set; }
public Params_Get_Answer_By_STUDENT_ID_List My_Params_Get_Answer_By_STUDENT_ID_List { get; set; }
#endregion
}
#endregion
#region Result_Get_Category_By_OWNER_ID
public partial class Result_Get_Category_By_OWNER_ID : Action_Result
{
#region Properties.
public List<Category>  My_Result { get; set; }
public Params_Get_Category_By_OWNER_ID My_Params_Get_Category_By_OWNER_ID { get; set; }
#endregion
}
#endregion
#region Result_Get_Question_By_CATEGORY_ID_List
public partial class Result_Get_Question_By_CATEGORY_ID_List : Action_Result
{
#region Properties.
public List<Question>  My_Result { get; set; }
public Params_Get_Question_By_CATEGORY_ID_List My_Params_Get_Question_By_CATEGORY_ID_List { get; set; }
#endregion
}
#endregion
#region Result_Get_Question_By_Criteria
public partial class Result_Get_Question_By_Criteria : Action_Result
{
#region Properties.
public List<Question>  My_Result { get; set; }
public Params_Get_Question_By_Criteria My_Params_Get_Question_By_Criteria { get; set; }
#endregion
}
#endregion
#region Result_Get_Question_By_OWNER_ID
public partial class Result_Get_Question_By_OWNER_ID : Action_Result
{
#region Properties.
public List<Question>  My_Result { get; set; }
public Params_Get_Question_By_OWNER_ID My_Params_Get_Question_By_OWNER_ID { get; set; }
#endregion
}
#endregion
#region Result_Get_Question_By_OWNER_ID_Adv
public partial class Result_Get_Question_By_OWNER_ID_Adv : Action_Result
{
#region Properties.
public List<Question>  My_Result { get; set; }
public Params_Get_Question_By_OWNER_ID My_Params_Get_Question_By_OWNER_ID { get; set; }
#endregion
}
#endregion
#region Result_Get_Question_By_QUESTION_ID
public partial class Result_Get_Question_By_QUESTION_ID : Action_Result
{
#region Properties.
public Question My_Result { get; set; }
public Params_Get_Question_By_QUESTION_ID My_Params_Get_Question_By_QUESTION_ID { get; set; }
#endregion
}
#endregion
#region Result_Get_Question_By_STUDENT_ID_List
public partial class Result_Get_Question_By_STUDENT_ID_List : Action_Result
{
#region Properties.
public List<Question>  My_Result { get; set; }
public Params_Get_Question_By_STUDENT_ID_List My_Params_Get_Question_By_STUDENT_ID_List { get; set; }
#endregion
}
#endregion
#region Result_Get_Student_By_OWNER_ID
public partial class Result_Get_Student_By_OWNER_ID : Action_Result
{
#region Properties.
public List<Student>  My_Result { get; set; }
public Params_Get_Student_By_OWNER_ID My_Params_Get_Student_By_OWNER_ID { get; set; }
#endregion
}
#endregion
#region Result_Get_Teacher_By_CATEGORY_ID_List
public partial class Result_Get_Teacher_By_CATEGORY_ID_List : Action_Result
{
#region Properties.
public List<Teacher>  My_Result { get; set; }
public Params_Get_Teacher_By_CATEGORY_ID_List My_Params_Get_Teacher_By_CATEGORY_ID_List { get; set; }
#endregion
}
#endregion
#region Result_Get_Teacher_By_OWNER_ID
public partial class Result_Get_Teacher_By_OWNER_ID : Action_Result
{
#region Properties.
public List<Teacher>  My_Result { get; set; }
public Params_Get_Teacher_By_OWNER_ID My_Params_Get_Teacher_By_OWNER_ID { get; set; }
#endregion
}
#endregion
