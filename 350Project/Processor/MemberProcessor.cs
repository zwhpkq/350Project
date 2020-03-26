﻿using _350Project.DataAccess;
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

        public static int CreateARecord(float Height, float Weight, int age, int neck, int waist, int hip, string gender, bool bmimethod, int membershipid) {
            DateTime time = DateTime.Now;
            float BMI = Weight / ((Height / 100)* (Height / 100));
            float BMR = 0f;
            float BFP = 0f;
            if (gender == "Male") {
                BMR = 10f * Weight + 6.25f * Height - 5f * age + 5f;
                if (bmimethod)
                {
                    BFP = 1.2f * BMI + 0.23f * age - 16.2f;
                }
                else {
                    BFP = 495f / (float)(1.0324f - 0.19077f * Math.Log10(waist - neck) + 0.15456f * Math.Log10(Height)) - 450f;
                }
            }
            else {
                BMR = 10f * Weight + 6.25f * Height - 5f * age - 161f;
                if (bmimethod)
                {
                    BFP = 1.2f * BMI + 0.23f * age - 5.4f;
                }
                else
                {
                    BFP = 495f / (float)(1.29579f - 0.35004 * Math.Log10(waist + hip - neck) + 0.221f * Math.Log10(Height)) - 450f;
                }
            }

            BMI = (float)Math.Round(BMI,2);
            BMR = (float)Math.Round(BMR, 2);
            BFP = (float)Math.Round(BFP, 2);

            RecordModel recordModel = new RecordModel
            {
                record_time = time.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                height = (float)Math.Round(Height, 0),
                weight = (float)Math.Round(Weight, 0),
                bmi = BMI,
                bmr = BMR,
                Fat_Percent = BFP,
                Fat_Mass = (float)Math.Round(BFP * Weight, 2)
            };

            string sql = @"insert into dbo.Bodyinfo (record_time,Membership_ID,height ,weight,bmi,bmr,Fat_Percent,Fat_Mass) values ( @record_time,'"+ membershipid+"'," +
                " @height,@weight, @bmi, @bmr, @Fat_Percent, @Fat_Mass)";

            return SqlAccess.SaveData(sql, recordModel);


        }
    }
}