﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Profile;

namespace WISLEY.Views.Gacha
{
    public partial class Gachas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Session["error"] = "You must be logged in to create a group!";
                Response.Redirect(Page.ResolveUrl("~/Views/Auth/login.aspx"));
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Profile/profile.aspx");
        }

        protected void Button1x_F_Click(object sender, EventArgs e)
        {
            

            //RNG
            int Min = 1;
            int Max = 8;
            int[] Summon = new int[1];

            Random randNum = new Random();
            for (int i = 0; i < Summon.Length; i++)
            {
                Summon[i] = randNum.Next(Min, Max);
            }

            Session["SSResults"] = string.Join(",", Summon.ToArray());

            Session["SSTitle"] = "Featured units 1x Summon";
            Response.Redirect("GachaSummon.aspx");

        }

        protected void Button11x_F_Click(object sender, EventArgs e)
        {
            //RNG
            int Min = 1;
            int Max = 8;
            int[] Summon = new int[11];

            Random randNum = new Random();
            for (int i = 0; i < Summon.Length; i++)
            {
                Summon[i] = randNum.Next(Min, Max);
            }

            Session["SSResults"] = string.Join(",", Summon.ToArray());


            Session["SSTitle"] = "Featured units 11x Summon";
            Response.Redirect("GachaSummon.aspx");

            
        }

        protected void Button1x_R_Click(object sender, EventArgs e)
        {
            

            //RNG
            int Min = 1;
            int Max = 8;
            int[] Summon = new int[1];

            Random randNum = new Random();
            for (int i = 0; i < Summon.Length; i++)
            {
                Summon[i] = randNum.Next(Min, Max);
            }

            Session["SSResults"] = string.Join(",", Summon.ToArray());

            Session["SSTitle"] = "Beginner special 1x Summon";
            Response.Redirect("GachaSummon.aspx");
        }

        protected void Button11x_R_Click(object sender, EventArgs e)
        {
            

            //RNG
            int Min = 1;
            int Max = 8;
            int[] Summon = new int[11];

            Random randNum = new Random();
            for (int i = 0; i < Summon.Length; i++)
            {
                Summon[i] = randNum.Next(Min, Max);
            }

            Session["SSResults"] = string.Join(",",Summon.ToArray());

            Session["SSTitle"] = "Beginner special 11x Summon";
            Response.Redirect("GachaSummon.aspx");

        }

        protected void ButtonI_F(object sender, EventArgs e)
        {
            Session["SSSummon"] = "Featured Summon";
            Response.Redirect("GachaDetails.aspx");
        }

        protected void ButtonI_R(object sender, EventArgs e)
        {
            Session["SSSummon"] = "Regular Summon";
            Response.Redirect("GachaDetails.aspx");
        }
    }
}