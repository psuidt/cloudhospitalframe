using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfwControls.HISControl.PrescriptionTmp.Controls.Entity;
using System.Data;

namespace EfwControls.HISControl.PrescriptionTmp.Controls
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
        //获取处方模板
        List<Entity.Prescription> GetPresTemplate(int type,int tplId);
        //获取处方模板行
        //Entity.Prescription GetPresTemplateRow(int type,int tpldetailId);
        //获取处方模板行
        List<Entity.Prescription> GetPresTemplateRow(int type, int[] tpldetailIds);
        //另存为处方模板
        void AsSavePresTemplate(int level, string mName, int presType, int deptId, int doctorId, List<Entity.Prescription> data);

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

       
        //void CloseWindows();
    }
}
