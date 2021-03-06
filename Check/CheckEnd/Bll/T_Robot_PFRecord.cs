﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace CheckEnd.Bll
{
    class T_Robot_PFRecord
    {
        #region 数据库连接字符串获取
        public static string Connstr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        #endregion

        DBUtility.SqlHelper sqlHelper = new DBUtility.SqlHelper();
        /// <summary>
        /// 读取机器人大枪合格信息
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public DataTable GetPFResult(string barcode)
        {
            DataTable dt;
            string sql = string.Format("SELECT IsOK  FROM T_Robot_PFRecord where MasterBarCode='{0}' ", barcode);
            dt = sqlHelper.ExecuteDataTable(Connstr, sql);
            return dt;
        }

        public DataTable GetFBResult(string barcode,string productNum)
        {
            string lor = "";
            if (barcode.Substring(0,1)=="A")
            {
                lor = "FLB3";
            }
            else if (barcode.Substring(0, 1) == "E")
            {
                lor = "FRB3";
            }

            string sql =
                $"  select PFIndex,WorkbayName from V_PF_Data where ProductionNumber='{productNum}' and IsOK='OK' and WorkbayName='{lor}'";
            var dt = sqlHelper.ExecuteDataTable(Connstr, sql);
            return dt;

        }



    }
}
