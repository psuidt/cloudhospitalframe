using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;

namespace EfwControls.HISControl.Prescription.Controls
{
    public interface IPrescription
    {
        int CurrPatListId { get; }
        DataTable PresGridDataSource { get; }
        int GridRowIndex { get; }

        void AddContextMenu(List<ToolStripMenuItem> menuList);
        void InitDbHelper(IPrescripttionDbHelper iPresDbHelper);
        void LoadPatData(int patListID, int presDeptCode, string presDeptName, int presDoctorId, string presDoctorName);
        void PrescriptionChange();
        void PrescriptionEdit();
        void PrescriptionDelete();
        void PrescriptionMergeGroup();
        void PrescriptionNew();
        void PrescriptionPrint();
        void PrescriptionRefresh();
        void PrescriptionSave();
        void PrescriptionLoadTemplate(int tplId);
        void PrescriptionLoadTemplateRow(int[] tpldetailId);
        void PrescriptionLoadList(List<Entity.Prescription> data);
    }
}
