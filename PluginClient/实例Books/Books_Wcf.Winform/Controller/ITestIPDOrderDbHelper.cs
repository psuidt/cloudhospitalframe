using EfwControls.HISControl.Orders.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfwControls.HISControl.Orders.Controls.Entity;
using System.Data;
using EFWCoreLib.WcfFrame.ClientController;
using EFWCoreLib.WcfFrame.DataSerialize;

namespace Books_Wcf.Winform.Controller
{
    public class ITestIPDOrderDbHelper : WcfClientController,IOrderDbHelper
    {
        public void AsSavePresTemplate(int level, string mName, int presType, int deptId, int doctorId, List<OrderRecord> data)
        {
            throw new NotImplementedException();
        }

        public int GetActDrugID()
        {
            throw new NotImplementedException();
        }

        public DataTable getDisease()
        {
            throw new NotImplementedException();
        }

        public CardDataSourceDrugItem GetDrugItem(int ItemId)
        {
            throw new NotImplementedException();
        }

        public DataTable  GetDrugItem(int orderCategory, int pageNo, int pageSize, string filter)
        {
            //List<CardDataSourceDrugItem> list = new List<CardDataSourceDrugItem>();
            //ServiceResponseData retdata = InvokeWcfService("Books.Service", "bookWcfController", "GetDrugItemData");
            //DataTable dt = retdata.GetData<DataTable>(0);
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    CardDataSourceDrugItem mDrugItem = new CardDataSourceDrugItem();
            //    mDrugItem.ItemId = Convert.ToInt32(dt.Rows[i]["ItemId"]);
            //    mDrugItem.ItemName = dt.Rows[i]["ItemName"].ToString();
            //    mDrugItem.Standard = dt.Rows[i]["Standard"].ToString();
            //    mDrugItem.StatID =Convert.ToInt32( dt.Rows[i]["StatID"]);
            //    mDrugItem.ExecDeptId = Convert.ToInt32(dt.Rows[i]["ExecDeptId"]);
            //    mDrugItem.ExecDeptName = dt.Rows[i]["ExecDeptName"].ToString();
            //    mDrugItem.Pym = dt.Rows[i]["Pym"].ToString();
            //    mDrugItem.Wbm = dt.Rows[i]["Wbm"].ToString();
            //    mDrugItem.SellPrice = Convert.ToDecimal(dt.Rows[i]["SellPrice"].ToString());
            //    mDrugItem.StoreAmount = Convert.ToDecimal(dt.Rows[i]["StoreAmount"]);
            //    mDrugItem.ItemClass = Convert.ToInt32(dt.Rows[i]["ItemClass"]);            
            //    list.Add(mDrugItem);
            //}
            //return list;
            return new DataTable();
        }

        public List<CardDataSourceEntrust> GetEntrust()
        {
            List<CardDataSourceEntrust> lists = new List<CardDataSourceEntrust>();
            return lists;
        }

        public int GetExecCount(int type, int frequencyId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<CardDataSourceFrequency> GetFrequency()
        {
            List<CardDataSourceFrequency> lists = new List<CardDataSourceFrequency>();
            return lists;
        }

        public int GetGroupMax(int patlistid, int orderCategory)
        {
            throw new NotImplementedException();
        }

        public DataTable getIpDept()
        {
            throw new NotImplementedException();
        }

        public DataTable getNotExsistOrders(int patlistid)
        {
            throw new NotImplementedException();
        }

        public DataTable GetOrders(int orderCategory, int status, int patlistid, int deptid)
        {
            ServiceResponseData retdata = InvokeWcfService("Books.Service", "bookWcfController", "GetOrders");
            DataTable dt = retdata.GetData<DataTable>(0);
            return dt;
        }

        public DataTable getOutSituation()
        {
            throw new NotImplementedException();
        }

        public List<OrderRecord> GetPresTemplate(int type, int tplId)
        {
            throw new NotImplementedException();
        }

        public List<OrderRecord> GetPresTemplateRow(int type, int[] tpldetailIds)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRefreshEntrust()
        {
            throw new NotImplementedException();
        }

        public int GetStatus(int orderid)
        {
            //throw new NotImplementedException();
            return 0;
        }

        public List<CardDataSourceUnit> GetUnit(int itemId, int type)
        {
            throw new NotImplementedException();
        }

        public List<CardDataSourceUsage> GetUsage()
        {
            List<CardDataSourceUsage> lists = new List<CardDataSourceUsage>();
            return lists;
            
        }

        public bool IsDrugStore(OrderRecord pres)
        {
            throw new NotImplementedException();
        }

        public bool IsDrugStore(List<OrderRecord> list, List<OrderRecord> errlist)
        {
            return true;
        }

        public DataTable LoadTemplateDetail(int tplId)
        {
            throw new NotImplementedException();
        }

        public DataTable LoadTemplateList(int deptId, int doctorId, int mealCls)
        {
            throw new NotImplementedException();
        }

        public bool OperatorOrder(List<OrderRecord> orderRecords, int operatorType)
        {
            throw new NotImplementedException();
        }

        public bool OperatorOrder(List<OrderRecord> orderRecords, int operatorType, int operatorEmpId)
        {
            throw new NotImplementedException();
        }

        public DataSet OrderDataInit(int orderCategory, int pageNo, int pageSize, string filter)
        {
            throw new NotImplementedException();
        }

        public bool OutHospOrder(int CurrPatListId, List<OrderRecord> list, DateTime OutDate, string outDiseaseName, string outDiseaseCode, string outSituation, int PresDoctorId, OrderRecord spciOrderRecord)
        {
            throw new NotImplementedException();
        }

        public bool Save(List<OrderRecord> list)
        {
            throw new NotImplementedException();
        }

        public bool TransDeptOrder(int patlistid, List<OrderRecord> list, DateTime transDate, int transDeptId, int operatorid, OrderRecord spciRecord)
        {
            throw new NotImplementedException();
        }
    }
}
