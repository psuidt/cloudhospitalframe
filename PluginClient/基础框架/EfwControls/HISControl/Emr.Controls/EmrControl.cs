using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using EfwControls.HISControl.Emr.Controls.Controller;
using EfwControls.HISControl.Emr.Controls.Entity;
using EfwControls.HISControl.Emr.Controls.IView;

namespace EfwControls.HISControl.Emr.Controls
{
    public partial class EmrControl : UserControl, IEmrControlView
    {
        public string EmrStoreId { get; set; }
        public EmrControlController controller;
        public EmrControl()
        {
            InitializeComponent();
            controller = new EmrControlController(this);
            writerControl1.CommandControler = writerCommandControler1;
            writerCommandControler1.Start();
        }
        public void OpenfileMongoDb(string _id)
        {
            //打开数据库中指定文件
            // System.IO.Stream stream = new System.IO.MemoryStream();
            StreamReader stream = controller.OpenFile(_id);
            writerControl1.ExecuteCommand("FileOpen", false, stream);
        }

        private EmrContrlType _emrContrlType = EmrContrlType.病历模板;
        [Description("医嘱类别")]
        public EmrContrlType EmrContrlType
        {
            get { return _emrContrlType; }
            set
            {
                _emrContrlType = value;
                if (_emrContrlType == EmrContrlType.病历模板)
                {
                    tabAudit.Visible = false;

                    //文件
                    //文件操作
                    btnImportOther.Visible = true;//导入其他模板
                    btnExport.Visible = true;//导出
                    btnImport.Visible = true;//导入
                    btnPreview.Visible = false;//预览
                    btnSaveAs.Visible = false;//另存为
                    btnEmrSubmit.Visible = false;//病历提交
                    btnEmrSubmitAll.Visible = false;//全部提交
                    btnAudit.Visible = false;//审核签名
                    btnBindFresh.Visible = false;//绑定刷新
                    btnEmrPlace.Visible = false;//病历归档
                    btnAuditAll.Visible = false;//批量审核
                    btnOpen.Visible = false;//打开
                    btnSaveAsModel.Visible = false;//另存模板
                    //文件打印
                    btnPrintBatch.Visible = false;//批量打印
                    btnCleanPrint.Visible = false;//清洁打印


                    ribBarFile.Size= new System.Drawing.Size(220, 82);
                    rabBarFilePrint.Size= new System.Drawing.Size(200, 82);

                    //编辑
                    btnProtection.Visible = true;//内容保护
                    btnSaveAsKnowledge.Visible = true;//存为知识库
                    btnConvertFont.Visible = false;//转普通文字
                    ridBarEditOper.Size= new System.Drawing.Size(272, 82);

                    //视图
                    btnViewDesign.Visible = false;//设计模式
                    btnViewSmallBtn.Visible = true;//小按钮模式
                    btnViewTable.Visible = false;//表单模式
                    btnViewWeb.Visible = false;//网页预览
                    btnViewReading.Visible = false;//阅读模式
                    btnViewClean.Visible = false;//清洁模式
                    btnViewMark.Visible = false;//留痕模式
                    btnDocGridLine.Visible = true;//文档网格线
                    ridBarViewFormat.Size= new System.Drawing.Size(327, 82);

                    writerControl1.ExecuteCommand(StandardCommandNames.DesignMode, false, null);

                    //插入
                    //媒体
                    btnInsertMedia.Visible = false;//视频
                    ridClinicData.Visible = false;//临床信息
                    ridInsertMedia.Size = new System.Drawing.Size(120, 82);
                }
                else
                {
                    tabAudit.Visible = true;//审核签名
                    //文件
                    //文件操作
                    btnImportOther.Visible = false;//导入其他模板
                    btnExport.Visible = false;//导出
                    btnImport.Visible = false;//导入
                    btnPreview.Visible = true;//预览
                    btnSaveAs.Visible = true;//另存为
                    btnEmrSubmit.Visible = true;//病历提交
                    btnEmrSubmitAll.Visible = true;//全部提交
                    btnAudit.Visible = true;//审核签名
                    btnBindFresh.Visible = true;//绑定刷新
                    btnEmrPlace.Visible = true;//病历归档
                    btnAuditAll.Visible = true;//批量审核
                    btnOpen.Visible = true;//打开
                    btnSaveAsModel.Visible = true;//另存模板
                    //文件打印
                    btnPrintBatch.Visible = true;//批量打印
                    btnCleanPrint.Visible = true;//清洁打印

                    ribBarFile.Size = new System.Drawing.Size(615, 82);
                    rabBarFilePrint.Size = new System.Drawing.Size(370, 82);

                    //编辑
                    btnProtection.Visible = false;//知识保护
                    btnSaveAsKnowledge.Visible = false;//存为知识库
                    btnConvertFont.Visible = true;//转普通文字
                    ridBarEditOper.Size = new System.Drawing.Size(231, 82);

                    //视图
                    btnViewDesign.Visible = false;//设计模式
                    btnViewSmallBtn.Visible = false;//小按钮模式
                    btnViewTable.Visible = false;//表单模式
                    btnViewWeb.Visible = true;//网页预览
                    btnViewReading.Visible = true;//阅读模式
                    btnViewClean.Visible = true;//清洁模式
                    btnViewMark.Visible = true;//留痕模式
                    btnDocGridLine.Visible = false; //文档网格线
                    ridBarViewFormat.Size = new System.Drawing.Size(408, 82);

                    //插入
                    //媒体
                    btnInsertMedia.Visible = true;//视频
                    ridClinicData.Visible = true;//临床信息
                    ridInsertMedia.Size = new System.Drawing.Size(164, 82);
                }
            }
        }


        private void SetContextMenu()
        {
            //this.myEditControl.ContextMenuStrip = null;
            //return;

            if (Math.Abs(writerControl1.Selection.Length) == 1)
            {
                XTextElement element = this.writerControl1.Selection.ContentElements[0];
                if (element is XTextImageElement)
                {
                    this.writerControl1.ContextMenuStrip = this.cmImage;
                    return;
                }
            }
            bool isInCell = false;
            if (writerControl1.Selection.Cells != null && writerControl1.Selection.Cells.Count > 0)
            {
                isInCell = true;
            }
            else
            {
                XTextContainerElement c = null;
                int index = 0;
                writerControl1.Document.Content.GetCurrentPositionInfo(out c, out index);
                if (c is XTextTableCellElement || c.OwnerCell != null)
                {
                    isInCell = true;
                }
            }
            if (isInCell)
            {
                writerControl1.ContextMenuStrip = cmTableCell;
                return;
            }
            writerControl1.ContextMenuStrip = cmEdit;
        }

        private void writerControl1_SelectionChanged(object eventSender, DCSoft.Writer.WriterEventArgs args)
        {
            SetContextMenu();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.IO.StreamWriter stream = new System.IO.StreamWriter(ms, Encoding.UTF8);
           
            writerControl1.ExecuteCommand("FileSave", true, stream);
            ms.Position = 0;
            EmrStoreId = controller.SaveFile(ms);
        }
    }
}
