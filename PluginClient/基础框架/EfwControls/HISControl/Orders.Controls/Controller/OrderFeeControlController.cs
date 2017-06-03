using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfwControls.HISControl.Orders.Controls.IView;

namespace EfwControls.HISControl.Orders.Controls.Controller
{
    /// <summary>
    /// 医嘱费用控件控制器
    /// </summary>
    public class OrderFeeControlController
    {
        /// <summary>
        /// 医嘱费用控件接口
        /// </summary>
        private IOrderFeeControlView m_IOrderFeeControlView;

        /// <summary>
        /// 医嘱费用控件数据操作接口
        /// </summary>
        private IOrderFeeDbHelper m_IOrderFeeDbHelper;

        /// <summary>
        /// 控件接口初始化
        /// </summary>
        /// <param name="_view"></param>
        public OrderFeeControlController(IOrderFeeControlView _view)
        {
            // 初始化接口
            m_IOrderFeeControlView = _view;
            // 初始化数据访问
            m_IOrderFeeDbHelper = new IPDOrderFeeDbHelper();
        }

        /// <summary>
        /// 绑定医嘱关联费用数据
        /// </summary>
        public DataTable LoadOrderFeeGridData()
        {
            // 获取医嘱关联费用列表
            return m_IOrderFeeDbHelper.LoadOrderFeeData(m_IOrderFeeControlView.PatListID, m_IOrderFeeControlView.GroupID);
            //m_IOrderFeeControlView.bind_OrderRelationFeeList(OrderFeeList);
        }

        /// <summary>
        /// 验证医嘱是否已转抄，已转抄的医嘱不允许补录费用
        /// </summary>
        /// <param name="patListID">病人ID</param>
        /// <param name="groupID">组号ID</param>
        /// <returns>true：已转抄</returns>
        public bool CheckOrderStatus(int patListID, int groupID)
        {
            return m_IOrderFeeDbHelper.CheckOrderStatus(patListID, groupID);
        }

        /// <summary>
        /// 初始化弹出网格数据
        /// </summary>
        /// <returns>网格弹出框数据列表</returns>
        public DataTable GetDocFeeItemList()
        {
            return m_IOrderFeeDbHelper.GetDocFeeItemList();
        }

        /// <summary>
        /// 保存医嘱费用数据
        /// </summary>
        /// <param name="FeeDt">待保存的医嘱费用数据</param>
        /// <returns>保存成功或失败</returns>
        public bool SaveFeeItemData(DataTable FeeDt)
        {
            if (m_IOrderFeeDbHelper.SaveFeeItemData(FeeDt, m_IOrderFeeControlView.PatListID, m_IOrderFeeControlView.GroupID))
            {
                m_IOrderFeeDbHelper.MessageShow("医嘱费用数据保存成功！");
                return true;
            }
            return false;
        }

        /// <summary>
        /// 删除选中医嘱费用数据
        /// </summary>
        /// <param name="GenerateID">选中医嘱费用数据ID</param>
        public void DelFeeItemData(int GenerateID)
        {
            m_IOrderFeeDbHelper.DelFeeItemData(GenerateID);
        }

        /// <summary>
        /// 提示Msg事件
        /// </summary>
        /// <param name="Msg">Msg</param>
        public void MessageShow(string Msg)
        {
            m_IOrderFeeDbHelper.MessageShow(Msg);
        }
    }
}
