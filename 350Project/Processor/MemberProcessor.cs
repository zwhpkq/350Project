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
                Member_nick = nickname,
                Member_Password = pass_word,
                First_Name = firstname,
                Last_Name = lastname,
                Member_Email = email,
                Member_Gender = gender,
                Member_Plan = plan

            };

            string plan_sql = @"select Plan_Id, plan_Year ,plan_Month,plan_Day,Price From dbo.Plans";

            List<PlanModel> plans = SqlAccess.LoadData<PlanModel>(plan_sql);

            DateTime Time = DateTime.Now;
            Time = Time.AddYears(plans[plan-1].plan_Year);
            Time = Time.AddMonths(plans[plan-1].plan_Month);
            Time = Time.AddDays(plans[plan-1].plan_Day);

            data.Member_End = Time.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string sql = @"insert into dbo.Members (Member_nick, Member_Password, First_Name, Last_Name,
                    Member_Plan, Member_End, Member_Gender, Member_Email) values ( @Member_nick, @Member_Password, @First_Name,
                    @Last_Name, @Member_Plan, @Member_End, @Member_Gender, @Member_Email)";

            return SqlAccess.SaveData(sql, data);
        }
    }
}