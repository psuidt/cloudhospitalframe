using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfwControls.HISControl.Prescription.Controls.Entity;
using System.Data;

namespace EfwControls.HISControl.Prescription.Controls
{
    public interface IPrescripttionDbHelper
    {
        //0-所有 1-西药 2-中药  3-处方可开的物品 4-收费项目
        List<CardDataSourceDrugItem> GetDrugItem(int type, int pageNo, int pageSize, string filter);

        //根据药品ID，获取药品数据
        CardDataSourceDrugItem GetDrugItem(int ItemId);

        List<CardDataSourceUsage> GetUsage();

        List<CardDataSourceFrequency> GetFrequency();

        List<CardDataSourceEntrust> GetEntrust();

        //stockId 药品ID  type 0.剂量单位 1.总量单位
        List<CardDataSourceUnit> GetUnit(int stockId, int type);

        //加载处方模板分类
        DataTable LoadTemplateList(int deptId, int doctorId, int mealCls);
        //加载处方模板明细
        DataTable LoadTemplateDetail(int tplId);
        /// <summary>
        /// 加载处方模板头信息
        /// </summary>
        /// <returns></returns>
        List<OPD_PresMouldHead> LoadTemplateHead(int intLevel, int presType);
        //获取处方模板
        List<Entity.Prescription> GetPresTemplate(int type, int tplId);
        //获取处方模板行
        //Entity.Prescription GetPresTemplateRow(int type,int tpldetailId);
        //获取处方模板行
        List<Entity.Prescription> GetPresTemplateRow(int type, int[] tpldetailIds);
        //另存为处方模板
        void AsSavePresTemplate(int pId, int level, string mName, int presType, int deptId, int doctorId, List<Entity.Prescription> data);

        //是否收费处方
        bool IsCostPres(List<Entity.Prescription> list);

        //检查药品库存是否足够
        bool IsDrugStore(Entity.Prescription pres);
        //检查药品库存是否足够
        bool IsDrugStore(List<Entity.Prescription> list, List<Entity.Prescription> errlist);

        //得到药品处方数据
        List<Entity.Prescription> GetPrescriptionData(int patListId, int presType);

        bool SavePrescriptionData(int patListId, List<Entity.Prescription> list, int presType);

        bool DeletePrescriptionData(int presListId);

        bool DeletePrescriptionData(int patListId, int presType, int PresNo);

        bool UpdatePresNoAndGroupId(List<Entity.Prescription> data);

        bool UpdatePresSelfDrugFlag(int presListId, int Flag);

        bool UpdatePresReimbursementFlag(List<Entity.Prescription> data, int Flag);

        /// <summary>
        /// 获取皮试用药药品ID
        /// </summary>
        /// <returns></returns>
        int GetActDrugID();
        /// <summary>
        /// 保存本院执行次数
        /// </summary>
        /// <param name="presListId">病人Id</param>
        /// <param name="menuText">说明</param>
        /// <param name="execTimes">执行次数</param>
        bool UpdatePresInjectTimes(int presListId, string menuText, int execTimes);

        /// <summary>
        /// 处方退费
        /// </summary>
        /// <param name="presHeadID">处方头ID</param>
        /// <param name="presNO">处方号</param>
        void RefundPresFee(int presHeadID,int presNO);
        /// <summary>
        /// 选中药房ID
        /// </summary>
        int SelectedDrugRoomID { get; set; }
        /// <summary>
        /// 刷新药品数据
        /// </summary>
        void RefreshDrugData();
    }
}
