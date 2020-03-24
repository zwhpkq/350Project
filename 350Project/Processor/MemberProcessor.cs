using _350Project.DataAccess;
using _350Project.Models;
using System;
using System.Collections.Generic;

namespace _350Project.Processor
{
    public static class MemberProcessor
    {
        public static int CreateMember(string nickname, string pass_word, string firstname, string lastname, int plan, string gender, string email)
        {
            MemberSubmitModel data = new MemberSubmitModel
            {
                UserName = nickname,
                Password = pass_word,
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                Gender = gender,
                Plan = plan

            };

            string plan_sql = @"select Id,Year,Month,Day,Price From dbo.Plan where Id = @plan";

            List<PlanModel> plans = SqlAccess.LoadData<PlanModel>(plan_sql);

            data.EndTime = GetTimestamp(DateTime.Now.AddYears(plans[0].Year).AddMonths(plans[0].Month).AddDays(plans[0].Day));

            string sql = @"insert into dbo.Members (Member_ID,Member_nick, Member_Password, First_Name, Last_Name,
                    Member_Plan, Member_Start, Member_end, Member_Gender, Member_Email) values (null, @UserName, @Password, @FirstName,
                    @LastName, @Plan, null, @EndTime @Gender, @Email)";

            return SqlAccess.SaveData(sql, data);
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }
    }
}