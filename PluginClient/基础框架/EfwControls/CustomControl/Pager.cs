using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace EfwControls.CustomControl
{

    public enum pageSizeType
    {
        Size10 = 0, Size20 = 1, Size50 = 2, Size100 = 3, Size200 = 4
    }

    public delegate void PagerEventHandler(object sender, int pageNo, int pageSize);

    /// <summary>
    /// 分页控件呈现
    /// 两种分页模式：
    /// 1.传入全部数据，控件本身对数据进行分页
    /// 2.只传入一页的数据和总记录数，传出PageNo和PageSize
    /// </summary>
    public partial class Pager : UserControl
    {
        public Pager()
        {
            InitializeComponent();
            Height = 28;
        }

        private void showpage(int totalCount, pageSizeType pagesize, int currPage)
        {
            int _totalCount = totalCount;
            int _currentPage = currPage < 1 ? 1 : currPage;
            int _pagesize = getpagesize(pagesize);
            int _totalPage = _totalCount % _pagesize == 0 ? _totalCount / _pagesize : _totalCount / _pagesize + 1;
            _totalPage = _totalPage < 1 ? 1 : _totalPage;

            labtotalCount.Text = string.Format("共{0}条", _totalCount);
            labtotalPage.Text = string.Format("/{0}", _totalPage);
            pageCount.SelectedIndexChanged -= pageCount_SelectedIndexChanged;
            pageCount.SelectedIndex = (int)_pageSizeType;
            pageCount.SelectedIndexChanged += pageCount_SelectedIndexChanged;

            //currentpage.ValueChanged -= page_ValueChanged;
            currentpage.Value = _currentPage;
            //currentpage.ValueChanged += page_ValueChanged;

            //pageCount.Enabled = true;
            headpage.Enabled = true;
            previouspage.Enabled = true;
            nextpage.Enabled = true;
            lastpage.Enabled = true;
            //currentpage.Enabled = true;
            refresh.Enabled = true;

            if (_currentPage == 1)
            {
                headpage.Enabled = false;
                previouspage.Enabled = false;
            }
            if (_currentPage == _totalPage)
            {
                nextpage.Enabled = false;
                lastpage.Enabled = false;
            }
            if (_totalPage == 1)
            {
                headpage.Enabled = false;
                previouspage.Enabled = false;
                nextpage.Enabled = false;
                lastpage.Enabled = false;

                //currentpage.Enabled = false;
            }

            PagerSource();
        }

        private int getpagesize(pageSizeType pagesize)
        {
            switch (pagesize)
            {
                case pageSizeType.Size10:
                    return 10;
                case pageSizeType.Size20:
                    return 20;
                case pageSizeType.Size50:
                    return 50;
                case pageSizeType.Size100:
                    return 100;
                case pageSizeType.Size200:
                    return 200;
                default:
                    return 10;
            }
        }

        /// <summary>
        /// 每页显示记录数
        /// </summary>
        private pageSizeType _pageSizeType = pageSizeType.Size10;
        private int _pageNo = 1;
        private int _totalRecord = 0;
        private int _pageSize = 10;

        /// <summary>
        /// 每页显示记录数
        /// </summary>
        public pageSizeType PageSizeType
        {
            get { return _pageSizeType; }
            set
            {
                _pageSizeType = value;
            }
        }
        /// <summary>
        /// 页面大小
        /// </summary>
        public int pageSize
        {
            get { return getpagesize(_pageSizeType);  }
            set {
                _pageSize = value;
                switch (_pageSize)
                {
                    case 10:
                        _pageSizeType = pageSizeType.Size10;
                        break;
                    case 20:
                        _pageSizeType = pageSizeType.Size20;
                        break;
                    case 50:
                        _pageSizeType = pageSizeType.Size50;
                        break;
                    case 100:
                        _pageSizeType = pageSizeType.Size100;
                        break;
                    case 200:
                        _pageSizeType = pageSizeType.Size200;
                        break;
                    default:
                        _pageSizeType = pageSizeType.Size10;
                        break;
                }
            }
        }

        /// <summary>
        /// 要取的页面，默认为1页
        /// </summary>
        public int pageNo
        {
            get { return _pageNo; }
            set
            {
                if (value > 0 && value <= totalPage)
                {
                    _pageNo = value;
                    if (PageNoChanged != null)
                    {
                        if (isPage == false)
                        {
                            PageNoChanged(this, _pageNo, pageSize);
                        }
                    }
                    showpage(_totalRecord, _pageSizeType, _pageNo);
                }
            }
        }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int totalRecord
        {
            get { return _totalRecord; }
            set
            {
                _totalRecord = value;
            }
        }

        /// <summary>
        /// 总页数
        /// </summary>
        public int totalPage
        {
            get { return totalRecord % pageSize == 0 ? totalRecord / pageSize : totalRecord / pageSize + 1; }
        }

        public int startNum
        {
            get { return (pageNo - 1) * pageSize + 1; }
        }

        public int endNum
        {
            get
            {
                return (startNum + pageSize - 1) > totalRecord ? totalRecord : (startNum + pageSize - 1);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            showpage(_totalRecord, _pageSizeType, _pageNo);
        }



        private void page_ValueChanged(object sender, EventArgs e)
        {
            switch ((sender as Control).Name)
            {
                case "headpage":
                    _pageNo = 1;
                    break;
                case "previouspage":
                    _pageNo = _pageNo - 1;
                    break;
                case "nextpage":
                    _pageNo = _pageNo + 1;
                    break;
                case "lastpage":
                    _pageNo = totalPage;
                    break;
                case "refresh":
                    break;

                case "currentpage":
                    int val = (sender as DevComponents.Editors.IntegerInput).Value;
                    val = val < 1 ? 1 : val;
                    val = val > totalPage ? totalPage : val;
                    _pageNo = val;
                    break;
            }
            if (PageNoChanged != null)
            {
                if (isPage == false)
                {
                    PageNoChanged(this, _pageNo, pageSize);
                }
            }
            showpage(_totalRecord, _pageSizeType, _pageNo);
        }

        private void pageCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pageNo = 1;
            _pageSizeType = (pageSizeType)pageCount.SelectedIndex;
            if (PageNoChanged != null)
            {
                if (isPage == false)
                {
                    PageNoChanged(this, _pageNo, pageSize);
                }
            }
            showpage(_totalRecord, _pageSizeType, _pageNo);
        }


        private DataGridView _grid;
        [Description("绑定数据控件")]
        [DefaultValue("")]
        public DataGridView BindDataControl
        {
            get { return _grid; }
            set { _grid = value; }
        }

        private DataTable _source=null;
        /// <summary>
        /// 如果是后台分页，请先设置totalRecord属性的值，在给DataSource赋值
        /// </summary>
        [RefreshProperties(RefreshProperties.Repaint)]
        [DefaultValue("")]
        [AttributeProvider(typeof(IListSource))]
        public DataTable DataSource
        {
            get { return _source; }
            set
            {
                _source = value;
                if (_source != null)
                {
                    //_pageNo = 1;
                    if (IsPage == true)//内部分页
                    {
                        _pageNo = 1;
                        _totalRecord = _source.Rows.Count;
                    }
                    else//后台分页
                    {
                        //_totalRecord 必须在之前设置好
                    }
                }
                else {
                    _totalRecord = 0;
                    _pageNo = 1;
                }

                showpage(_totalRecord, _pageSizeType, _pageNo);
            }
        }

        private void PagerSource()
        {
            if (_source != null)
            {
                this._grid.AutoGenerateColumns = false;
                //_grid.DataSource = null;
                if (isPage == false)
                    _grid.DataSource = _source;
                else
                {
                    _grid.DataSource = GetPagerSource(_source);
                }
            }
            else
            {
                if (_grid != null)
                    _grid.DataSource = null;
            }
        }

        private object GetPagerSource(DataTable dt)
        {

            DataTable _dt = dt.Clone();
            if (dt.Rows.Count > 0)
            {
                for (int i = startNum - 1; i < (dt.Rows.Count - startNum + 1 < pageSize ? dt.Rows.Count : endNum); i++)
                {
                    _dt.Rows.Add(dt.Rows[i].ItemArray);
                }
            }
            return _dt;
        }
        /// <summary>
        /// 是否内部分页
        /// </summary>
        private bool isPage = true;
        [Description("设置是否内部分页，IsPage=false时结合PagerEventHandler事件使用")]
        public bool IsPage
        {
            get { return isPage; }
            set { isPage = value; }
        }
        [Description("翻页的事件，结合IsPage=false属性使用")]
        public event PagerEventHandler PageNoChanged;

        public void SetPagerDataSource(int totalcount, DataTable datasource)
        {
            _totalRecord = totalcount;
            DataSource = datasource;
        }

        public void SetReadOnly(bool _readonly)
        {
            if (_readonly == false)
            {
                headpage.Visible = true;
                previouspage.Visible = true;
                nextpage.Visible = true;
                lastpage.Visible = true;
                refresh.Visible = true;

                pageCount.Enabled = true;
                currentpage.Enabled = true;
            }
            else
            {
                headpage.Visible = false;
                previouspage.Visible = false;
                nextpage.Visible = false;
                lastpage.Visible = false;
                refresh.Visible = false;

                pageCount.Enabled = false;
                currentpage.Enabled = false;
            }
        }

        private void Pager_SizeChanged(object sender, EventArgs e)
        {
            Height = 28;
        }

        private void currentpage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                page_ValueChanged(sender, e);
                this.Focus();
                currentpage.Focus();
            }
        }
    }
   
}
