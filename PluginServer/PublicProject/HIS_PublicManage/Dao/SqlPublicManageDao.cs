using EFWCoreLib.CoreFrame.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HIS_PublicManage.ObjectModel;
using EFWCoreLib.CoreFrame.Common;

namespace HIS_PublicManage.Dao
{
    public class SqlPublicManageDao : AbstractDao, IPublicManageDao
    {

        #region 病人信息相关
        /// <summary>
        /// 麻醉方式ClassId=1014
        /// </summary>
        /// <returns></returns>
        public DataTable GetAnesthesia()
        {
            string strsql = @"SELECT Code ,Name ,Pym ,Wbm ,Szm ,Memo FROM BaseDictContent WHERE ClassId=1014 AND DelFlag=0 ORDER BY SortOrder ASC ";
            //strsql = string.Format(strsql, oleDb.WorkId);
            return oleDb.GetDataTable(strsql);
        }
        /// <summary>
        /// 获取血型ClassId=1009
        /// </summary>
        /// <returns></returns>
        public DataTable GetBloodType()
        {
            string strsql = @"SELECT Code ,Name ,Pym ,Wbm ,Szm ,Memo FROM BaseDictContent WHERE ClassId=1009 AND DelFlag=0 ORDER BY SortOrder ASC ";
            //strsql = string.Format(strsql, oleDb.WorkId);
            return oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 地区编码ClassId=1004
        /// </summary>
        /// <returns></returns>
        public DataTable GetDistriceCoding()
        {
            string strsql = @"SELECT Code ,Name ,Pym ,Wbm ,Szm ,Memo FROM BaseDictContent WHERE ClassId=1004 AND DelFlag=0 ORDER BY SortOrder ASC ";
            //strsql = string.Format(strsql, oleDb.WorkId);
            return oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 教育程度ClassId=1016
        /// </summary>
        /// <returns></returns>
        public DataTable GetEducation()
        {
            string strsql = @"SELECT Code ,Name ,Pym ,Wbm ,Szm ,Memo FROM BaseDictContent WHERE ClassId=1016 AND DelFlag=0 ORDER BY SortOrder ASC ";
            //strsql = string.Format(strsql, oleDb.WorkId);
            return oleDb.GetDataTable(strsql);
        }


        /// <summary>
        /// 病人情况ClassId=1017
        /// </summary>
        /// <returns></returns>
        public DataTable GetIPSituation()
        {
            string strsql = @"SELECT Code ,Name ,Pym ,Wbm ,Szm ,Memo FROM BaseDictContent WHERE ClassId=1017 AND DelFlag=0 ORDER BY SortOrder ASC ";
            //strsql = string.Format(strsql, oleDb.WorkId);
            return oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 婚姻状况ClassId=1006
        /// </summary>
        /// <returns></returns>
        public DataTable GetMatrimony()
        {
            string strsql = @"SELECT Code ,Name ,Pym ,Wbm ,Szm ,Memo FROM BaseDictContent WHERE ClassId=1006 AND DelFlag=0 ORDER BY SortOrder ASC ";
            //strsql = string.Format(strsql, oleDb.WorkId);
            return oleDb.GetDataTable(strsql);
        }
        /// <summary>
        /// 获取民族ClassId=1003
        /// </summary>
        /// <returns></returns>
        public DataTable GetNation()
        {
            string strsql = @"SELECT Code ,Name ,Pym ,Wbm ,Szm ,Memo FROM BaseDictContent WHERE ClassId=1003 AND DelFlag=0 ORDER BY SortOrder ASC ";
            //strsql = string.Format(strsql, oleDb.WorkId);
            return oleDb.GetDataTable(strsql);
        }
        /// <summary>
        /// 获取国籍ClassId=1002
        /// </summary>
        /// <returns></returns>
        public DataTable GetNationality()
        {
            string strsql = @"SELECT Code ,Name ,Pym ,Wbm ,Szm ,Memo FROM BaseDictContent WHERE ClassId=1002 AND DelFlag=0 ORDER BY SortOrder ASC ";
            //strsql = string.Format(strsql, oleDb.WorkId);
            return oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 获取职业ClassId=1005
        /// </summary>
        /// <returns></returns>
        public DataTable GetOccupation()
        {
            string strsql = @"SELECT Code ,Name ,Pym ,Wbm ,Szm ,Memo FROM BaseDictContent WHERE ClassId=1005 AND DelFlag=0 ORDER BY SortOrder ASC ";
            //strsql = string.Format(strsql, oleDb.WorkId);
            return oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 获取关系ClassId=1007
        /// </summary>
        /// <returns></returns>
        public DataTable GetRelation()
        {
            string strsql = @"SELECT Code ,Name ,Pym ,Wbm ,Szm ,Memo FROM BaseDictContent WHERE ClassId=1007 AND DelFlag=0 ORDER BY SortOrder ASC ";
            //strsql = string.Format(strsql, oleDb.WorkId);
            return oleDb.GetDataTable(strsql);
        }
        /// <summary>
        /// 获取性别ClassId=1001
        /// </summary>
        /// <returns></returns>
        public DataTable GetSex()
        {
            string strsql = @"SELECT Code ,Name ,Pym ,Wbm ,Szm ,Memo FROM BaseDictContent WHERE ClassId=1001 AND DelFlag=0 ORDER BY SortOrder ASC ";
            //strsql = string.Format(strsql, oleDb.WorkId);
            return oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 获取护理级别ClassId=1039
        /// </summary>
        /// <returns></returns>
        public DataTable GetNusingLevel()
        {
            string strsql = @"SELECT Code ,Name ,Pym ,Wbm ,Szm ,Memo FROM BaseDictContent WHERE ClassId=1039 AND DelFlag=0 ORDER BY SortOrder ASC ";
            return oleDb.GetDataTable(strsql);
        }
        /// <summary>
        /// 获取饮食级别ClassId=1040
        /// </summary>
        /// <returns></returns>
        public DataTable GetDietType()
        {
            string strsql = @"SELECT Code ,Name ,Pym ,Wbm ,Szm ,Memo FROM BaseDictContent WHERE ClassId=1040 AND DelFlag=0 ORDER BY SortOrder ASC ";
            return oleDb.GetDataTable(strsql);
        }

        #endregion

        #region 科室数据相关
        public DataTable GetAllDept()
        {
            string strsql = @"SELECT a.DeptId,a.Name,ISNULL(a.Pym,'') Pym,ISNULL(a.Wbm,'') Wbm,ISNULL(a.Szm,'') Szm,ISNULL(a.Memo,'') Memo FROM BaseDept a LEFT JOIN BaseDeptDetails b 
                                ON a.DeptId=b.DeptID
                                WHERE a.WorkId={0} AND a.DelFlag=0 
                                ORDER BY a.SortOrder ASC";
            strsql = string.Format(strsql, oleDb.WorkId);
            return oleDb.GetDataTable(strsql);
        }
        public DataTable GetOPClinicalDept()
        {
            string strsql = @"SELECT a.DeptId,a.Name,ISNULL(a.Pym,'') Pym,ISNULL(a.Wbm,'') Wbm,ISNULL(a.Szm,'') Szm,ISNULL(a.Memo,'') Memo FROM BaseDept a LEFT JOIN BaseDeptDetails b 
                                ON a.DeptId=b.DeptID
                                WHERE a.WorkId={0} AND a.DelFlag=0 AND b.OutUsed=1
                                ORDER BY a.SortOrder ASC";
            strsql = string.Format(strsql, oleDb.WorkId);
            return oleDb.GetDataTable(strsql);
        }
        public DataTable GetIPClinicalDept()
        {
            string strsql = @"SELECT a.DeptId,a.Name,ISNULL(a.Pym,'') Pym,ISNULL(a.Wbm,'') Wbm,ISNULL(a.Szm,'') Szm,ISNULL(a.Memo,'') Memo FROM BaseDept a LEFT JOIN BaseDeptDetails b 
                                ON a.DeptId=b.DeptID
                                WHERE a.WorkId={0} AND a.DelFlag=0 AND b.InUsed=1
                                ORDER BY a.SortOrder ASC";
            strsql = string.Format(strsql, oleDb.WorkId);
            return oleDb.GetDataTable(strsql);
        }
        public DataTable GetDrugDept()
        {
            string strsql = @"SELECT a.DeptId,a.Name,ISNULL(a.Pym,'') Pym,ISNULL(a.Wbm,'') Wbm,ISNULL(a.Szm,'') Szm,ISNULL(a.Memo,'') Memo FROM BaseDept a LEFT JOIN BaseDeptDetails b 
                                ON a.DeptId=b.DeptID
                                WHERE a.WorkId={0} AND a.DelFlag=0 AND (b.PharmacyUsed=1 OR b.DrugUsed=1 OR b.MaterialsUsed=1)
                                ORDER BY a.SortOrder ASC";
            strsql = string.Format(strsql, oleDb.WorkId);
            return oleDb.GetDataTable(strsql);
        }
        public DataTable GetPharmacyDept()
        {
            string strsql = @"SELECT a.DeptId,a.Name,ISNULL(a.Pym,'') Pym,ISNULL(a.Wbm,'') Wbm,ISNULL(a.Szm,'') Szm,ISNULL(a.Memo,'') Memo FROM BaseDept a LEFT JOIN BaseDeptDetails b 
                                ON a.DeptId=b.DeptID
                                WHERE a.WorkId={0} AND a.DelFlag=0 AND b.PharmacyUsed=1
                                ORDER BY a.SortOrder ASC";
            strsql = string.Format(strsql, oleDb.WorkId);
            return oleDb.GetDataTable(strsql);
        }
        public DataTable GetMaterialsDept()
        {
            string strsql = @"SELECT a.DeptId,a.Name,ISNULL(a.Pym,'') Pym,ISNULL(a.Wbm,'') Wbm,ISNULL(a.Szm,'') Szm,ISNULL(a.Memo,'') Memo FROM BaseDept a LEFT JOIN BaseDeptDetails b 
                                ON a.DeptId=b.DeptID
                                WHERE a.WorkId={0} AND a.DelFlag=0 AND b.MaterialsUsed=1
                                ORDER BY a.SortOrder ASC";
            strsql = string.Format(strsql, oleDb.WorkId);
            return oleDb.GetDataTable(strsql);
        }

        public DataTable GetDrugStorageDept()
        {
            string strsql = @"SELECT a.DeptId,a.Name,ISNULL(a.Pym,'') Pym,ISNULL(a.Wbm,'') Wbm,ISNULL(a.Szm,'') Szm,ISNULL(a.Memo,'') Memo FROM BaseDept a LEFT JOIN BaseDeptDetails b 
                                ON a.DeptId=b.DeptID
                                WHERE a.WorkId={0} AND a.DelFlag=0 AND b.DrugUsed=1
                                ORDER BY a.SortOrder ASC";
            strsql = string.Format(strsql, oleDb.WorkId);
            return oleDb.GetDataTable(strsql);
        }

        public DataTable GetWardDept()
        {
            string strsql = @"SELECT WardID DeptId,WardName Name,Pym,Wbm,Szm,Memo FROM BaseWard
                                WHERE DelFlag=0 AND WorkID={0}
                                ORDER BY SortOrder";
            strsql = string.Format(strsql, oleDb.WorkId);
            return oleDb.GetDataTable(strsql);
        }
        #endregion

        #region 用户数据相关
        public DataTable GetEmpAll(int iWorkId)
        {
            if (iWorkId == -1)
            {
                iWorkId = oleDb.WorkId;
            }
            string strsql = @"SELECT b.EmpId,b.Name,b.Pym,b.Wbm,b.Szm FROM BaseUser a LEFT JOIN BaseEmployee b 
                                ON a.EmpID=b.EmpId
                                WHERE a.WorkId={0} AND a.Lock=0 AND b.DelFlag=0";
            strsql = string.Format(strsql, iWorkId);
            return oleDb.GetDataTable(strsql);
        }
        public DataTable GetDoctor(int iWorkId)
        {
            if (iWorkId == -1)
            {
                iWorkId = oleDb.WorkId;
            }

            string strsql = @"SELECT b.EmpId,b.Name,b.Pym,b.Wbm,b.Szm,dbo.fnGetDictName(1022,a.DoctorPost) JobTitle FROM BaseUser a LEFT JOIN BaseEmployee b 
                                ON a.EmpID=b.EmpId
                                WHERE a.WorkId={0} AND a.Lock=0 AND b.DelFlag=0 AND a.UserType=2";
            strsql = string.Format(strsql, iWorkId);
            return oleDb.GetDataTable(strsql);
        }
        public DataTable GetDoctorAndDept(int iWorkId)
        {
            if (iWorkId == -1)
            {
                iWorkId = oleDb.WorkId;
            }

            string strsql = @"SELECT b.EmpId,b.Name,b.Pym,b.Wbm,b.Szm,dbo.fnGetDictName(1022,a.DoctorPost) JobTitle,c.DeptId FROM BaseUser a LEFT JOIN BaseEmployee b 
                                ON a.EmpID=b.EmpId
                                 left join BaseEmpDept c on b.EmpId=c.EmpId
                                WHERE a.WorkId={0} AND a.Lock=0 AND b.DelFlag=0 AND a.UserType=2";
            strsql = string.Format(strsql, iWorkId);
            return oleDb.GetDataTable(strsql);
        }
        public DataTable GetNurse(int iWorkId)
        {
            if (iWorkId == -1)
            {
                iWorkId = oleDb.WorkId;
            }

            string strsql = @"SELECT b.EmpId,b.Name,b.Pym,b.Wbm,b.Szm FROM BaseUser a LEFT JOIN BaseEmployee b 
                                ON a.EmpID=b.EmpId
                                WHERE a.WorkId={0} AND a.Lock=0 AND b.DelFlag=0 AND a.UserType=3";
            strsql = string.Format(strsql, iWorkId);
            return oleDb.GetDataTable(strsql);
        }
        public DataTable GetCashier(int iWorkId)
        {
            if (iWorkId == -1)
            {
                iWorkId = oleDb.WorkId;
            }

            string strsql = @"SELECT b.EmpId,b.Name,b.Pym,b.Wbm,b.Szm FROM BaseUser a LEFT JOIN BaseEmployee b 
                                ON a.EmpID=b.EmpId
                                WHERE a.WorkId={0} AND a.Lock=0 AND b.DelFlag=0 AND a.UserType=1";
            strsql = string.Format(strsql, iWorkId);
            return oleDb.GetDataTable(strsql);
        }

        public DataTable GetPharmacist(int iWorkId)
        {
            if (iWorkId == -1)
            {
                iWorkId = oleDb.WorkId;
            }

            string strsql = @"SELECT b.EmpId,b.Name,b.Pym,b.Wbm,b.Szm FROM BaseUser a LEFT JOIN BaseEmployee b 
                                ON a.EmpID=b.EmpId
                                WHERE a.WorkId={0} AND a.Lock=0 AND b.DelFlag=0 AND a.UserType=4";
            strsql = string.Format(strsql, iWorkId);
            return oleDb.GetDataTable(strsql);
        }


        #endregion

        #region 获取名称
        public DataTable GetWorkers()
        {
            string strsql = @"SELECT  WorkId ,
                                        WorkNo ,
                                        WorkName ,
                                        Memo  FROM BaseWorkers WHERE DelFlag=0";
            return oleDb.GetDataTable(strsql);
        }
        public DataTable GetPatType()
        {
            string strsql = @"SELECT  PatTypeID ,
                                        PatTypeCode ,
                                        PatTypeName ,
                                        PYCode ,
                                        WBCode  FROM Basic_PatType
                                WHERE DelFlag=0
                                ORDER BY SortOrder ASC";
            return oleDb.GetDataTable(strsql);
        }

        public DataTable GetDisease()
        {
            string strsql = @" SELECT  
                                     ICDCode ,
                                     Name ,
                                     PYCode ,
                                     WBCode ,
                                     Type  FROM Basic_Disease";
            return oleDb.GetDataTable(strsql);
        }

        public string GetEmpName(int empId)
        {
            string strsql = @"SELECT ISNULL(Name,'') Name FROM BaseEmployee WHERE EmpId={0}";
            strsql = string.Format(strsql, empId);
            return ConvertExtend.ToString(oleDb.GetDataResult(strsql), "");
        }

        public string GetDeptName(int deptId)
        {
            string strsql = @"SELECT ISNULL(Name,'') Name FROM BaseDept WHERE DeptId={0}";
            strsql = string.Format(strsql, deptId);
            return ConvertExtend.ToString(oleDb.GetDataResult(strsql), "");
        }

        public string GetWardName(int wardId)
        {
            string strsql = @"SELECT ISNULL(WardName,'') WardName FROM BaseWard WHERE WardID={0}";
            strsql = string.Format(strsql, wardId);
            return ConvertExtend.ToString(oleDb.GetDataResult(strsql), "");
        }

        public string GetWorkName(int workId)
        {
            string strsql = @"SELECT ISNULL(WorkName,'') WorkName FROM BaseWorkers WHERE WorkId={0}";
            strsql = string.Format(strsql, workId);
            return ConvertExtend.ToString(oleDb.GetDataResult(strsql), "");
        }

        public string GetDictContent(int classId, string code)
        {
            string strsql = @"SELECT top 1 ISNULL(Name,'') Name FROM BaseDictContent WHERE ClassId={0} AND Code='{1}'";
            strsql = string.Format(strsql, classId, code);
            return ConvertExtend.ToString(oleDb.GetDataResult(strsql), "");
        }

        public string GetPatTypeName(int patTypeId)
        {
            string strsql = @"SELECT ISNULL(PatTypeName,'') PatTypeName FROM Basic_PatType WHERE PatTypeID={0}";
            strsql = string.Format(strsql, patTypeId);
            return ConvertExtend.ToString(oleDb.GetDataResult(strsql), "");
        }
        #endregion

        #region 费用数据源
        public DataTable GetFeeItemData(int[] itemclass)
        {
            if (itemclass.Length > 0)
            {
                string str = string.Join(",", itemclass);
                string strsql = @"SELECT * FROM ViewFeeItem_List where ItemClass in ({0}) AND WorkId={1}";
                strsql = string.Format(strsql, str, oleDb.WorkId);
                return oleDb.GetDataTable(strsql);
            }
            return new DataTable();
        }
        public DataTable GetSimpleFeeItemData(int itemclass)
        {
            string strsql = @"SELECT * FROM ViewFeeItem_SimpleList where ItemClass={0} AND WorkId={1}";
            strsql = string.Format(strsql, itemclass, oleDb.WorkId);
            return oleDb.GetDataTable(strsql);
        }

        public DataTable GetExamItemDetailDt(int ExamItemID)
        {
            string strsql = @"select * from Basic_ExamItemFee where ExamItemID={0} AND WorkId={1}";
            strsql = string.Format(strsql, ExamItemID, oleDb.WorkId);
            return oleDb.GetDataTable(strsql);
        }

        public DataTable GetSimpleFeeItemData(int[] itemclass)
        {
            if (itemclass.Length > 0)
            {
                string str = string.Join(",", itemclass);
                string strsql = @"SELECT * FROM ViewFeeItem_SimpleList where ItemClass in ({0}) AND WorkId={1}";
                strsql = string.Format(strsql, str, oleDb.WorkId);
                return oleDb.GetDataTable(strsql);
            }
            return new DataTable();
        }


        #endregion

        public DataTable GetDictData(int classId)
        {
            string strsql = @"SELECT Code ,Name ,Pym ,Wbm ,Szm ,Memo FROM BaseDictContent WHERE ClassId={0} AND DelFlag=0 ORDER BY SortOrder ASC ";
            strsql = string.Format(strsql, classId);
            return oleDb.GetDataTable(strsql);
        }

        public DataTable GetStatItem()
        {
            string strsql = @"SELECT StatID,StatName,NumCode,PyCode,WbCode FROM Basic_CenterStatItem WHERE DelFlag=0";
            return oleDb.GetDataTable(strsql);
        }

        public bool IsExistSNType(int snType, int deptId, string type)
        {
            string strsql = @"SELECT COUNT(SNType) FROM Basic_SerialNumberSource WHERE SNType={0} AND WorkID={1} AND DeptId={2} AND RTRIM(BusinessType)='{3}'";
            strsql = string.Format(strsql, snType, oleDb.WorkId, deptId, type);
            return ConvertExtend.ToInt32(oleDb.GetDataResult(strsql), -1) > 0;
        }

        public bool IsTodaySNType(int snType, int deptId, string type)
        {
            string strsql = @"SELECT COUNT(SNType) FROM Basic_SerialNumberSource WHERE SNType={0} AND CONVERT(varchar(100), CurrDate, 23)=CONVERT(varchar(100), GETDATE(), 23) AND WorkID={1} AND DeptId={2} AND RTRIM(BusinessType)='{3}'";
            strsql = string.Format(strsql, snType, oleDb.WorkId, deptId, type);
            return ConvertExtend.ToInt32(oleDb.GetDataResult(strsql), -1) > 0;
            //return Convert.ToInt32(oleDb.GetDataResult(strsql)) > 0;
        }

        public int InsertSerialNumber(int snType, int deptId, string type)
        {
            string strsql = @"INSERT INTO Basic_SerialNumberSource( SNType ,BusinessType ,DeptId ,CurrDate ,CurrSequence ,WorkID)
                                VALUES  ( {0} ,'{3}' ,{2} ,GETDATE() ,1 ,{1})";
            strsql = string.Format(strsql, snType, oleDb.WorkId, deptId, type);
            oleDb.DoCommand(strsql);
            return 1;
        }

        public int UpdateTodaySerialNumber(int snType, int deptId, string type)
        {
            string strsql = @"UPDATE Basic_SerialNumberSource SET CurrSequence=CurrSequence+1
                                WHERE SNType={0} AND WorkID={1} AND DeptId={2} AND RTRIM(BusinessType)='{3}'";
            strsql = string.Format(strsql, snType, oleDb.WorkId, deptId, type);
            oleDb.DoCommand(strsql);
            strsql = @"SELECT CurrSequence FROM Basic_SerialNumberSource WHERE SNType={0} AND WorkID={1} AND DeptId={2} AND RTRIM(BusinessType)='{3}'";
            strsql = string.Format(strsql, snType, oleDb.WorkId, deptId, type);
            //return Convert.ToInt32(oleDb.GetDataResult(strsql));
            return ConvertExtend.ToInt32(oleDb.GetDataResult(strsql), -1);
        }

        public int UpdateNoTodaySerialNumber(int snType, int deptId, string type)
        {
            string strsql = @"UPDATE Basic_SerialNumberSource SET CurrDate=GETDATE(),CurrSequence=1
                                WHERE SNType={0} AND WorkID={1} AND DeptId={2} AND RTRIM(BusinessType)='{3}'";
            strsql = string.Format(strsql, snType, oleDb.WorkId, deptId, type);
            oleDb.DoCommand(strsql);
            return 1;
        }

        public DataTable GetUnit()
        {
            string strsql = @"SELECT UnitID ,UnitName ,PYCode ,WBCode FROM DG_UnitDic";
            return oleDb.GetDataTable(strsql);
        }

        public string GetSystemConfigValue(int deptID, string paraID)
        {
            string strsql = @"SELECT top 1 Value FROM Basic_SystemConfig 
                                where ParaID='{0}' AND DeptID={1} AND (WorkID={2} OR WorkID=0) 
                                order BY WorkID DESC";
            strsql = string.Format(strsql, paraID, deptID, oleDb.WorkId);
            return ConvertExtend.ToString(oleDb.GetDataResult(strsql), "");
        }


        public DataTable GetMedicareDic()
        {
            string strsql = @" select MedicareID,MedicareName,PYCode,WBCode,WorkID FROM DG_MedicareDic";
            return oleDb.GetDataTable(strsql);
        }

        public DataTable GetUserDept(int empId, int IsOut)
        {
            string strsql = @"SELECT a.DeptId,a.Name,ISNULL(a.Pym,'') Pym,ISNULL(a.Wbm,'') Wbm,ISNULL(a.Szm,'') Szm,ISNULL(a.Memo,'') Memo 
                                FROM BaseDept a LEFT JOIN BaseEmpDept b ON a.DeptId=b.DeptId
                                LEFT JOIN BaseDeptDetails c ON a.DeptId=c.DeptID
                                WHERE b.EmpId={0} AND a.DelFlag=0 
                                AND (({1}=0 AND c.OutUsed=1) OR ({1}=1 AND c.InUsed=1))
                                ORDER BY a.SortOrder ASC";
            strsql = string.Format(strsql, empId, IsOut);
            return oleDb.GetDataTable(strsql);
        }

        public DataTable GetUserWard(int empId)
        {
            string strsql = @"SELECT a.WardID ID,WardName Name,Pym,Wbm,Szm,Memo 
                                FROM BaseWard a LEFT JOIN BaseEmpWard b ON a.WardID=b.WardID
                                WHERE DelFlag=0 AND EmpID={0}
                                ORDER BY SortOrder";
            strsql = string.Format(strsql, empId);
            return oleDb.GetDataTable(strsql);
        }

        public string GetExecuteCode(int frequencyID)
        {
            string strsql = @"SELECT ExecuteCode FROM Basic_Frequency WHERE FrequencyID=" + frequencyID;
            return ConvertExtend.ToString(oleDb.GetDataResult(strsql), "");
        }

        #region "业务消息数据相关"

        /// <summary>
        /// 验证消息类型是否被停用
        /// </summary>
        /// <param name="msgCode">消息代码</param>
        /// <param name="workId">机构ID</param>
        /// <returns></returns>
        public DataTable GetMsgType(string msgCode, int workId)
        {
            string strSql = @"SELECT Status,Id,Code,Limittime FROM BaseMessageType WHERE Code = '{0}' AND WorkID = {1}";
            strSql = string.Format(strSql, msgCode, workId);
            return oleDb.GetDataTable(strSql);
        }

        /// <summary>
        /// 获取业务消息中包含的病人信息
        /// </summary>
        /// <param name="patListID">病人登记信息</param>
        /// <returns></returns>
        public DataTable GetPatientInfo(int patListID)
        {
            string strSql = @"SELECT  A.CurrDeptID ,
                        A.PatName ,
                        A.SerialNumber ,
                        A.BedNo,
		                B.Name AS DeptName
                        FROM    IP_PatList A
                        LEFT JOIN BaseDept B ON A.CurrDeptID=B.DeptId WHERE A.PatListID={0}";
            strSql = string.Format(strSql, patListID);
            return oleDb.GetDataTable(strSql);
        }

        /// <summary>
        /// 获取业务消息包含的药品统领信息
        /// </summary>
        /// <param name="billID">药品统领ID</param>
        /// <returns></returns>
        public DataTable GetDrugBillDetailData(int billID, MessageType msgType)
        {
            string strSql = string.Empty;
            if (msgType == MessageType.药品统领)
            {
                strSql = @"SELECT  A.BillHeadID ,A.PresDeptID,A.ExecDeptID,
                        dbo.fnGetDeptName(A.ExecDeptID) AS ExecDeptName ,
                        dbo.fnGetDeptName(A.PresDeptID) AS PresDeptName,
		                B.BillTypeName
                        FROM    IP_DrugBillHead A
                        LEFT JOIN IP_DrugBillType B ON A.BillTypeID=B.BillTypeID
                        WHERE BillHeadID = {0}";
                strSql = string.Format(strSql, billID);
            }
            else if (msgType == MessageType.药房缺药)
            {
                strSql = @"SELECT  dbo.fnGetDeptName(B.ExecDeptID)AS ExecDeptName,dbo.fnGetDeptName(B.PresDeptID) AS PresDeptName,A.ItemName
                            ,B.BillHeadID,B.PresDeptID,B.ExecDeptID FROM    dbo.IP_DrugBillDetail A
                            LEFT JOIN dbo.IP_DrugBillHead B ON A.BillHeadID=B.BillHeadID
                            WHERE   BillDetailID = {0}";
                strSql = string.Format(strSql, billID);
            }
            return oleDb.GetDataTable(strSql);
        }

        /// <summary>
        /// 获取门诊病人基本信息
        /// </summary>
        /// <param name="patListId">病人ID</param>
        /// <returns></returns>
        public DataTable GetOpPatlist(int patListId)
        {
            string strSql = string.Format(@"SELECT PatName,CureDeptID,dbo.fnGetDeptName(CureDeptID) AS DeptName,dbo.fnGetEmpName(CureEmpID) 
                                        AS DortorName FROM dbo.OP_PatList WHERE PatListID={0}", patListId);
            return oleDb.GetDataTable(strSql);
        }

        /// <summary>
        /// 取消一键消息订阅
        /// </summary>
        /// <param name="megTypeId">消息类型ID</param>
        /// <param name="empIdList">用户ID列表</param>
        /// <returns></returns>
        public bool CancelOneKeySubscribeMsg(int megTypeId, int empIdList)
        {
            string strSql = string.Format("DELETE FROM BaseMessageTypeUser WHERE MessageTypeId = {0} AND EmpId = {1}", megTypeId, empIdList);
            return oleDb.DoCommand(strSql) > 0;
        }
        #endregion


    }
}
