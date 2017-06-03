using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_PublicManage.Dao
{
    /// <summary>
    /// 药房公共接口
    /// </summary>
    public class SqlDrugStoreInfoDao: AbstractDao,IDrugStoreInfoDao
    {
        /// <summary>
        /// 药房公共接口
        /// <param name="code">发票号或会员卡号</param>
        /// <param name="execDeptID">执行科室Id</param>
        /// <param name="distributeFlag">发药标志</param>
        /// <returns>结算数据集</returns>
        /// </summary>     
        public DataTable QueryPatientInfo(string code,int execDeptID,int distributeFlag)
        {
            string strSql = string.Empty;
            if (code.Trim() == "")
            {
                strSql = @"SELECT  Top 100 b.PatListID ,
                                        b.CardNO ,
                                        b.PatName ,
                                        b.PatSex ,
                                        b.Age ,
                                        b.VisitNO,
                                        c.Name AS MedicalDeptName ,
                                        a.InvoiceNO ,
                                        a.CostHeadID ,
                                        Sum(a.TotalFee) as TotalFee,
                                        a.ChargeDate
                                FROM    OP_FeeItemHead a
                                        INNER JOIN OP_PatList b ON a.PatListID = b.PatListID
                                        LEFT JOIN BaseDept c ON b.CureDeptID = c.DeptId
                                WHERE   a.ChargeStatus = 0
								        AND a.ChargeFlag=1
                                        AND a.RegFlag = 0		
		                                AND a.WorkID={0}
										AND a.ExecDeptID={1}
										AND a.distributeFlag={2}
                                        GROUP BY b.PatListID , b.CardNO , b.PatName ,b.PatSex ,
                                    b.Age , c.Name  , a.InvoiceNO ,  a.CostHeadID , a.ChargeDate,b.VisitNO 
		                                order by a.ChargeDate desc";
                strSql = string.Format(strSql, oleDb.WorkId, execDeptID, distributeFlag);
            }
            else
            {
                strSql = @"SELECT Top 100 b.PatListID ,
                                    b.CardNO ,
                                    b.PatName ,
                                    b.PatSex ,
                                    b.Age ,
                                    b.VisitNO,
                                    c.Name AS MedicalDeptName ,
                                    a.InvoiceNO ,
                                    a.CostHeadID ,
                                    SUM(a.TotalFee) AS TotalFee,
                                    a.ChargeDate
                            FROM    OP_FeeItemHead a
                                    INNER JOIN OP_PatList b ON a.PatListID = b.PatListID
                                    LEFT JOIN BaseDept c ON b.CureDeptID = c.DeptId
                            WHERE   a.ChargeStatus = 0
                                    AND a.ChargeFlag = 1
                                    AND a.RegFlag = 0
                                    AND ( b.CardNO = '{0}'
                                          OR a.InvoiceNO = '{0}'
                                          OR b.PatName like '%{0}%' 
                                          OR b.VisitNO='{0}' 
                                        )
                                    AND a.WorkID = {1}
                                    AND a.ExecDeptID = {2}
                                    AND a.distributeFlag = {3}
                            GROUP BY b.PatListID , b.CardNO , b.PatName ,b.PatSex ,
                                    b.Age , c.Name  , a.InvoiceNO ,  a.CostHeadID , a.ChargeDate,b.VisitNO 
                            ORDER BY a.ChargeDate desc";
                strSql = string.Format(strSql, code, oleDb.WorkId, execDeptID, distributeFlag);
            }
            return oleDb.GetDataTable(strSql);
        }

        /// <summary>
        /// 获取收费主表
        /// </summary>
        /// <param name="invoiceNO">发票号</param>
        /// <param name="deptId">科室Id</param>
        /// <returns>收费头表数据集</returns>
        public DataTable GetFeeItemHead(string invoiceNO,int deptId)
        {
            string strSql = @"SELECT a.ExecDeptID,a.PatListID,a.TotalFee,a.PatName,b.PatSex,
                                     b.DiseaseName,b.Age,a.PresEmpID,a.PresEmpID,c.Name AS PresEmpName,a.PresDeptID, d.Name AS PresDeptName,
	                                 a.FeeNo,a.InvoiceNO,a.ChargeDate,a.ChargeEmpID,e.Name AS ChargeEmpName,a.CostHeadID,a.FeeItemHeadID,a.PresType,
	                                 a.PresAmount,a.TotalFee,a.DocPresHeadID,a.DocPresNO
                    FROM OP_FeeItemHead a LEFT JOIN OP_PatList b ON a.PatListID=b.PatListID
                         LEFT JOIN BaseEmployee c ON c.EmpId=a.PresEmpID
	                     LEFT JOIN BaseDept d ON d.DeptId=a.PresDeptID
	                     LEFT JOIN dbo.BaseEmployee e ON a.ChargeEmpID=e.EmpId
                    WHERE a.PresType <> '0' and a.ChargeStatus=0 AND a.ChargeFlag=1 AND a.InvoiceNO='{0}' AND a.WorkID={1} and a.ExecDeptID={2}";
            strSql = string.Format(strSql, invoiceNO, oleDb.WorkId, deptId);
            return oleDb.GetDataTable(strSql);
        }

        /// <summary>
        /// 获取费用明细
        /// </summary>
        /// <param name="feeItemHeadID">费用主表Id</param>
        /// <returns>费用明细</returns>
        public DataTable GetFeeItemDetail(int feeItemHeadId)
        {
            string strSql = @"SELECT    a.PresDetailID,c.CTypeID,b.DrugID,c.Spec,c.ChemName,d.ProductName,c.MiniUnitID,
                                        a.MiniUnit,a.PackUnit,a.UnitNO,a.Amount,a.RetailPrice,a.StockPrice,a.TotalFee,0 as UseAmount,
                                       f.ChannelName as UseWay,
                                        g.FrequencyName as Frequency,
                                        '' as UseUnit,
                                        '' as Orders,
                                        a.FeeItemHeadID,
										PackAmount=(
										CAST(CONVERT(int,(a.Amount/a.UnitNo)) AS varchar(10))+a.PackUnit+
										CASE CONVERT(int,(a.Amount%a.UnitNo)) WHEN 0 THEN '' ELSE CAST(CONVERT(int,(a.Amount%a.UnitNo)) AS varchar(10))+a.MiniUnit END
										) 
                                FROM    OP_FeeItemDetail a
                                        LEFT JOIN DG_HospMakerDic  b ON a.ItemID=b.DrugID
                                        LEFT JOIN DG_CenterSpecDic c  ON b.CenteDrugID=c.CenteDrugID
		                                LEFT JOIN DG_ProductDic d ON b.ProductID=d.ProductID
										LEFT JOIN dbo.OPD_PresDetail e ON a.DocPresDetailID=e.PresDetailID
										LEFT JOIN dbo.Basic_Channel f ON e.ChannelID=f.ID	
										LEFT JOIN dbo.Basic_Frequency g ON e.FrequencyID=g.FrequencyID		
                                WHERE a.FeeItemHeadID={0}";
            strSql = string.Format(strSql, feeItemHeadId);
            return oleDb.GetDataTable(strSql);
        }

        /// <summary>
        /// 获取执行单信息
        /// </summary>
        public DataTable GetExecuteBills()
        {
            string strSql = @"SELECT b.ChannelID FROM Basic_ExecuteBills a 
                                        INNER JOIN Basic_ExecuteBillChannel b 
                                        ON a.ID=b.ExecBillID WHERE a.BillName='输液单'";
            strSql = string.Format(strSql);
            return oleDb.GetDataTable(strSql);
        }

        /// <summary>
        /// 取得退药明细
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>退药明细</returns>
        public DataTable GetRefundDetail(Dictionary<string, string> condition)
        {
            string strSql = @" 
                                SELECT  DISTINCT a.ReHeadID ,
                                        a.RefundDocID ,
                                        a.RefundDate ,
                                        b.DistributeFlag ,
                                        b.RefundFlag ,
                                        a.RefundPayFlag ,
                                        a.Flag ,
                                        a.PatListID ,
                                        a.PatName ,
                                        a.InvoiceNum ,
                                        b.ReDetailID ,
                                        b.FeeItemHeadID ,
                                        b.FeeItemDetailID ,
                                        b.ItemID ,
                                        b.ItemName ,
                                        b.RefundAmount , 
                                        b.RefundFee,
                                        c.ExecDeptID ,
                                        c.PatListID ,
                                        c.TotalFee ,
                                        c.PatName ,
                                        c.PatSex ,
                                        c.DiseaseName ,
                                        c.Age ,
                                        c.PresEmpID ,
                                        c.PresEmpName ,
                                        c.PresDeptID ,
                                        c.PresDeptName ,
                                        c.FeeNo ,
                                        c.InvoiceNO ,
                                        c.ChargeDate ,
                                        c.ChargeEmpID ,
                                        c.ChargeEmpName ,
                                        c.CostHeadID ,
                                        c.PresType ,
                                        c.PresAmount ,
                                        d.CTypeID ,
                                        d.DrugID ,
                                        d.Spec ,
                                        d.ChemName ,
                                        d.ProductName ,
                                        d.MiniUnitID ,
                                        d.MiniUnit ,
                                        d.PackUnit ,
                                        d.UnitNO ,
                                        d.Amount ,
                                        d.RetailPrice ,
                                        d.StockPrice ,
                                        d.TotalFee ,
                                        d.UseAmount ,
                                        d.UseWay ,
                                        d.Frequency ,
                                        d.UseUnit ,
                                        d.Orders,
										PackAmount=(
										CAST(CONVERT(int,(b.RefundAmount/d.UnitNo)) AS varchar(10))+d.PackUnit+
										CASE CONVERT(int,(b.RefundAmount%d.UnitNo)) WHEN 0 THEN '' ELSE CAST(CONVERT(int,(b.RefundAmount%d.UnitNo)) AS varchar(10))+d.MiniUnit END
										) 
                                FROM    OP_FeeRefundHead a
                                        LEFT JOIN OP_FeeRefundDetail b ON a.ReHeadID = b.ReHeadID
                                        LEFT JOIN ( SELECT  a1.ExecDeptID ,
                                                            a1.PatListID ,
                                                            a1.TotalFee ,
                                                            a1.PatName ,
                                                            b1.PatSex ,
                                                            b1.DiseaseName ,
                                                            b1.Age ,
                                                            a1.PresEmpID ,
                                                            c1.Name AS PresEmpName ,
                                                            a1.PresDeptID ,
                                                            d1.Name AS PresDeptName ,
                                                            a1.FeeNo ,
                                                            a1.InvoiceNO ,
                                                            a1.ChargeDate ,
                                                            a1.ChargeEmpID ,
                                                            e1.Name AS ChargeEmpName ,
                                                            a1.CostHeadID ,
                                                            a1.FeeItemHeadID ,
                                                            a1.PresType ,
                                                            a1.PresAmount
                                                    FROM    OP_FeeItemHead a1
                                                            LEFT JOIN OP_PatList b1 ON a1.PatListID = b1.PatListID
                                                            LEFT JOIN BaseEmployee c1 ON c1.EmpId = a1.PresEmpID
                                                            LEFT JOIN BaseDept d1 ON d1.DeptId = a1.PresDeptID
                                                            LEFT JOIN dbo.BaseEmployee e1 ON a1.ChargeEmpID = e1.EmpId
                                                    WHERE   a1.PresType <>'0'
                                                           
                                                            AND a1.ChargeFlag = 1
                                                            AND a1.distributeFlag = 1
                                                  ) AS c ON c.FeeItemHeadID = b.FeeItemHeadID
                                        LEFT JOIN ( SELECT  a2.PresDetailID ,
                                                            c2.CTypeID ,
                                                            b2.DrugID ,
                                                            c2.Spec ,
                                                            c2.ChemName ,
                                                            d2.ProductName ,
                                                            c2.MiniUnitID ,
                                                            a2.MiniUnit ,
                                                            a2.PackUnit ,
                                                            a2.UnitNO ,
                                                            a2.Amount ,
                                                            a2.RetailPrice ,
                                                            a2.StockPrice ,
                                                            a2.TotalFee ,
                                                            0 AS UseAmount ,
                                                            '' AS UseWay ,
                                                            '' AS Frequency ,
                                                            '' AS UseUnit ,
                                                            '' AS Orders ,
                                                            a2.FeeItemHeadID
                                                    FROM    OP_FeeItemDetail a2
                                                            LEFT JOIN DG_HospMakerDic b2 ON a2.ItemID = b2.DrugID
                                                            LEFT JOIN DG_CenterSpecDic c2 ON b2.CenteDrugID = c2.CenteDrugID
                                                            LEFT JOIN DG_ProductDic d2 ON b2.ProductID = d2.ProductID
                                                  ) d ON d.PresDetailID = b.FeeItemDetailID
                                                         AND d.FeeItemHeadID = b.FeeItemHeadID
                                WHERE a.Flag=0 and b.RefundAmount>0 and a.WorkID={0}";
            strSql = string.Format(strSql, oleDb.WorkId);
            StringBuilder strWhere = new StringBuilder();
            foreach (var pair in condition)
            {
                if (pair.Key != "")
                {
                    strWhere.AppendFormat(" AND {0}={1} ", pair.Key, pair.Value);
                }
                else
                {
                    strWhere.AppendFormat("AND {0}", pair.Value);
                }
            }
            strSql = strSql + strWhere.ToString();
            return oleDb.GetDataTable(strSql);
        }

        /// <summary>
        /// 获取费用明细
        /// </summary>
        /// <param name="feeItemHeadIds">多个处方头ID字符串'(1,2,3)'</param>
        /// <returns>费用明细</returns>
        public DataTable GetFeeItemDetail(string feeItemHeadIds)
        {
            string strSql = @"SELECT    a.PresDetailID,c.CTypeID,b.DrugID,c.Spec,c.ChemName,d.ProductName,c.MiniUnitID,
                                        a.MiniUnit,a.PackUnit,a.UnitNO,a.Amount,a.RetailPrice,a.StockPrice,a.TotalFee,0 as UseAmount,
                                        '' as UseWay,
                                        '' as Frequency,
                                        '' as UseUnit,
                                        '' as Orders,
                                        a.FeeItemHeadID
                                FROM    OP_FeeItemDetail a
                                        LEFT JOIN DG_HospMakerDic  b ON a.ItemID=b.DrugID
                                        LEFT JOIN DG_CenterSpecDic c  ON b.CenteDrugID=c.CenteDrugID
		                                LEFT JOIN DG_ProductDic d ON b.ProductID=d.ProductID		
                                WHERE a.FeeItemHeadID in {0}";
            strSql = string.Format(strSql, feeItemHeadIds);
            return oleDb.GetDataTable(strSql);
        }

        /// <summary>
        /// 退费消息表中是否存在
        /// </summary>
        /// <param name="invoiceNo">发票号</param>
        /// <returns></returns>
        public bool HasRefund(string invoiceNo)
        {
            string strSql = @"SELECT COUNT(*) FROM OP_FeeRefundHead WHERE InvoiceNum='{0}' AND RefundPayFlag=0 AND Flag=0";
            strSql = string.Format(strSql, invoiceNo);
            int iRtn =Convert.ToInt32(oleDb.GetDataResult(strSql));
            if (iRtn > 0)
                return true;
            else
                return false;

        }

        /// <summary>
        /// 判断库房是否处于盘点状态
        /// </summary>
        /// <param name="deptId">库房ID</param>
        /// <param name="deptType">药剂科室类型0药房1药库</param>
        /// <returns>返回True是系统正在盘点，false正常运营</returns>
        public bool IsCheckStatus(int deptId, int deptType)
        {
            string strSql = @"SELECT CheckStatus FROM  DG_DeptDic WHERE DeptID={0} and DeptType={1} AND WorkID={2}";
            strSql = string.Format(strSql, deptId, deptType, oleDb.WorkId);
            int intRtn = Convert.ToInt32(oleDb.GetDataResult(strSql));
            if (intRtn > 0)
                return true;
            else
                return false;
        }

        #region 住院统领发药接口
        /// <summary>
        /// 取得统领单头表
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>统领头表</returns>
        public DataTable GetIPDrugBillHead(Dictionary<string, string> condition)
        {
            string strSql = @"SELECT  a.BillHeadID,
                                      a.BillClass,
                                      a.BillTypeID,
	                                  b.BillTypeName,
                                      a.PresDeptID,
	                                  c.Name AS PresDeptName,
                                      a.ExecDeptID,
	                                  d.Name AS ExecDeptName,
                                      a.MakeDate,
                                      a.MakeEmpID,
                                      a.MakeEmpName      
                                  FROM IP_DrugBillHead a  LEFT JOIN IP_DrugBillType b ON a.BillTypeID=b.BillTypeID
                                       LEFT JOIN BaseDept c ON a.PresDeptID=c.DeptId
	                                   LEFT JOIN dbo.BaseDept d ON a.ExecDeptID=d.DeptId
                                  WHERE 1=1 AND a.WorkID={0} AND EXISTS 
                                 (SELECT * FROM IP_DrugBillDetail w WHERE w.BillHeadID=a.BillHeadID
                                  AND w.DispDrugFlag=0  AND w.NoDrugFlag=0 AND w.Amount<>0)";
            strSql = string.Format(strSql, oleDb.WorkId);
            StringBuilder strWhere = new StringBuilder();
            foreach (var pair in condition)
            {
                if (pair.Key != "")
                {
                    strWhere.AppendFormat(" AND {0}={1} ", pair.Key, pair.Value);
                }
                else
                {
                    strWhere.AppendFormat("AND {0}", pair.Value);
                }
            }
            strSql = strSql + strWhere.ToString();
            return oleDb.GetDataTable(strSql);
        }

        /// <summary>
        /// 取得统领单明细表
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>统领明细表</returns>
        public DataTable GetIPDrugBillDetail(Dictionary<string, string> condition)
        {
            string strSql = @"SELECT  1 AS chk,
                                a.BillDetailID ,
                                a.BillHeadID ,
                                a.ItemID AS DrugID ,
                                a.ItemName AS ChemName,
                                a.Spec AS DrugSpec ,
                                a.BedNO ,
                                a.SerialNumber AS InpatientNO,
                                a.PatListID ,
                                a.PatName ,
                                a.PatDeptID ,
                                a.PatDoctorID ,
		                        doc.Name AS PresDocName,
                                a.Amount AS DispAmount,
                                a.DoseAmount AS Dosage,
		                        c.MiniUnitID AS UnitID,
                                a.Unit AS UnitName,
                                c.PackAmount AS UnitAmount ,
                                m.DosageName AS DoseName ,
                                a.InPrice ,
                                a.SellPrice ,
                                a.StockFee ,
                                a.SellFee ,
                                a.FeeRecordID ,
                                a.CostEmpID ,
                                a.CostDate ,
                                a.OrderType ,
                                a.OrderID ,
                                a.OrderGroupID AS GroupNO,
                                a.DispHeadID ,
                                a.DispDrugFlag ,
                                a.NoDrugFlag ,
                                a.SpecDicID AS DrugSpecID,
		                        c.CTypeID,
		                        d.ProductName,
	                            0 AS UseAmount,
		                        '' AS UseWay,
		                        '' AS Frequency,
		                        '' AS UseUnit,
		                        c.PackUnit,
		                        '' AS Orders,
		                        k.ExecDeptID AS DeptID,
		                        dbo.fnGetDictName(1001,p.Sex) AS Sex,
                                k.BillTypeID,
                                k.PresDeptID,
                                k.MakeEmpName,
                                dbo.fnGetDeptName(k.PresDeptID) AS PresDeptName,
                                j.BillTypeName
                        FROM    IP_DrugBillHead k LEFT JOIN   IP_DrugBillDetail a ON a.BillHeadID=k.BillHeadID
                                LEFT JOIN DG_HospMakerDic b ON a.ItemID = b.DrugID
                                LEFT JOIN DG_CenterSpecDic c ON b.CenteDrugID = c.CenteDrugID
                                LEFT JOIN DG_ProductDic d ON b.ProductID = d.ProductID
		                        LEFT JOIN BaseEmployee doc ON doc.EmpId=a.PatDoctorID
		                        LEFT JOIN IP_PatList p ON p.PatListID=a.PatListID
                                LEFT JOIN IP_DrugBillType j ON j.BillTypeID=k.BillTypeID
                                LEFT JOIN DG_DosageDic m ON c.DosageID=m.DosageID
                        WHERE   a.NoDrugFlag=0 and a.WorkID={0} AND a.Amount<>0 ";
            strSql = string.Format(strSql, oleDb.WorkId);
            StringBuilder strWhere = new StringBuilder();
            foreach (var pair in condition)
            {
                if (pair.Key != "")
                {
                    strWhere.AppendFormat(" AND {0}={1} ", pair.Key, pair.Value);
                }
                else
                {
                    strWhere.AppendFormat("AND {0}", pair.Value);
                }
            }
            strSql = strSql + strWhere.ToString();
            return oleDb.GetDataTable(strSql);
        }

        /// <summary>
        /// 取得已发药表头
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public DataTable GetDispIPBillHead(Dictionary<string, string> condition)
        {
            string strSql = @"SELECT a.DispHeadID,
                                      a.BillNO,
                                      a.RetailFee,
                                      a.DispenserID,
                                      a.PharmacistID,
                                      a.DispTime,
                                      a.RefFlag,
                                      a.BusiType,
                                      a.DeptID,
	                                  b.Name AS DeptName,
                                      a.WorkID,
	                                  a.ExecDeptID,
	                                  a.BillTypeID,
	                                  c.BillTypeName
                                  FROM DS_IPDispHead a LEFT JOIN BaseDept b ON a.DeptID=b.DeptId
                                        LEFT JOIN IP_DrugBillType c ON a.BillTypeID=c.BillTypeID
                                  WHERE 1=1 AND a.WorkID={0}";
            strSql = string.Format(strSql, oleDb.WorkId);
            StringBuilder strWhere = new StringBuilder();
            foreach (var pair in condition)
            {
                if (pair.Key != "")
                {
                    strWhere.AppendFormat(" AND {0}={1} ", pair.Key, pair.Value);
                }
                else
                {
                    strWhere.AppendFormat("AND {0}", pair.Value);
                }
            }
            strSql = strSql + strWhere.ToString();
            return oleDb.GetDataTable(strSql);
        }

        /// <summary>
        /// 取得统领单明细表-打印
        /// </summary>
        /// <param name="iDispHeadID">头Id</param>
        /// <returns>统领明细表</returns>
        public DataTable GetIPDrugBillDetailPrint(int iDispHeadID)
        {
            string strSql = @"SELECT a.BedNO ,
                                a.SerialNumber AS InpatientNO,
                                a.PatListID ,
                                a.PatName ,
                                a.PatDeptID ,
		                        doc.Name AS PresDocName,
								p.Age,
								dbo.fnGetDictName(1001,p.Sex) AS Sex,

                                a.ItemID AS DrugID ,
                                a.ItemName AS ChemName,
                                a.Spec AS DrugSpec , 
                                --CAST(a.DoseAmount AS VARCHAR(5))+ISNULL(ipdor.DosageUnit,'') AS Dosage,    
                                CAST(a.PackAmount AS VARCHAR(10))+ISNULL(a.Unit,'') AS Dosage,                             
                                a.SellPrice ,
								a.Amount AS DispAmount,
								a.Unit AS UnitName,
                                a.SellFee ,
								dsiph.BillNO,

                                a.OrderType ,
                                a.OrderGroupID AS GroupNO,
							    ipdor.Frequency,
                                ipdor.ChannelName,
		                        k.ExecDeptID AS DeptID,		
                                dbo.fnGetDeptName(k.ExecDeptID) AS ExecDeptName,                 
                                k.BillTypeID,
								k.MakeDate,
                                k.MakeEmpName,
                                dbo.fnGetDeptName(k.PresDeptID) AS PresDeptName,
                                j.BillTypeName,
                                j.ReportId
                        FROM    IP_DrugBillHead k 
                                INNER JOIN  IP_DrugBillDetail a ON a.BillHeadID=k.BillHeadID
								INNER JOIN DS_IPDispHead dsiph ON a.DispHeadID=dsiph.DispHeadID
                                LEFT JOIN dbo.IPD_OrderRecord ipdor ON ipdor.OrderID=a.OrderID                                
                                LEFT JOIN DG_HospMakerDic b ON a.ItemID = b.DrugID
                                LEFT JOIN DG_CenterSpecDic c ON b.CenteDrugID = c.CenteDrugID
                                LEFT JOIN DG_ProductDic d ON b.ProductID = d.ProductID
		                        LEFT JOIN BaseEmployee doc ON doc.EmpId=a.PatDoctorID
		                        LEFT JOIN IP_PatList p ON p.PatListID=a.PatListID
                                LEFT JOIN IP_DrugBillType j ON j.BillTypeID=k.BillTypeID
                        WHERE   a.NoDrugFlag=0 
							AND a.DispDrugFlag=1
                            and a.WorkID = {0}
                            and a.DispHeadID = {1} 
                            and a.Amount<>0 ";
            strSql = string.Format(strSql, oleDb.WorkId, iDispHeadID);
            return oleDb.GetDataTable(strSql);
        }


        #endregion
        #region 药品有效库存判断，有效库存操作
        public decimal GetStorage(int drugID, int DeptID)
        {
            string strSql = @"SELECT ValidAmount FROM  DS_ValidStorage WHERE DrugID={0} and DeptID={1}";
            strSql = string.Format(strSql, drugID, DeptID);
            object obj =oleDb.GetDataResult(strSql);
            return Convert.ToDecimal(obj == null ? 0 : obj);
        }
        public bool UpdateStorage(int drugID, int DeptID, decimal updateAmount)
        {            
            string strSql = @"update DS_ValidStorage set ValidAmount=ValidAmount+" + updateAmount+"  WHERE DrugID={0} and DeptID={1}";
            strSql = string.Format(strSql, drugID, DeptID);
           int intRtn= oleDb.DoCommand(strSql);
            return intRtn > 0 ? true : false;
        }
        #endregion
    }
}

