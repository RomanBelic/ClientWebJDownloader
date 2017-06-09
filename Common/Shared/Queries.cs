using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Shared
{
    public class Queries
    {
        public static readonly string Select_User_ByLoginPass =
                                                   @"SELECT u.*, t.NameStr FROM " + Constants.BaseJDL.UserTable + @" u
                                                     INNER JOIN " + Constants.BaseJDL.UserTypeTable + @" t ON t.Id = u.IdType 
                                                     WHERE u.Login=@Login AND u.Pass=@Pass";

        public static readonly string Select_User_ByLogin =
                                                   @"SELECT u.*, t.NameStr FROM " + Constants.BaseJDL.UserTable + @" u
                                                     INNER JOIN " + Constants.BaseJDL.UserTypeTable + @" t ON t.Id = u.IdType 
                                                     WHERE u.Login=@Login";

        public static readonly string Select_User_ById =
                                                   @"SELECT u.*, t.NameStr FROM " + Constants.BaseJDL.UserTable + @" u
                                                     INNER JOIN " + Constants.BaseJDL.UserTypeTable + @" t ON t.Id = u.IdType 
                                                     WHERE u.Id=@Id";

        public static readonly string Delete_User = "DELETE FROM " + Constants.BaseJDL.UserTable + " WHERE Id=@Id";

        public static readonly string Select_Link = "SELECT l.* FROM " + Constants.BaseJDL.LinkTable + " l WHERE l.Url=@Url AND l.IdUser=@IdUser";
        public static readonly string Select_ListLinkUser = "SELECT l.* FROM " + Constants.BaseJDL.LinkTable + " l WHERE IdUser=@IdUser Order By l.DateCreated DESC";
        public static readonly string Delete_Link = "DELETE FROM " + Constants.BaseJDL.LinkTable + " WHERE Id=@Id";

        public static readonly string Select_ListUserType = "SELECT t.* FROM " + Constants.BaseJDL.UserTypeTable + " t WHERE t.Id != 3 Order By t.NameStr";
        public static readonly string Select_UserType = "SELECT t.* FROM " + Constants.BaseJDL.UserTypeTable + " t WHERE t.Id=@Id";
    }
}
